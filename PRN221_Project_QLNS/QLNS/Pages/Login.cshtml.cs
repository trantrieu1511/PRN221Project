using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;

namespace QLNS.Pages
{
	public class LoginModel : PageModel
	{
		private readonly PRN221_Project_QLNSContext _context;

		public LoginModel(PRN221_Project_QLNSContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Models.Account Account { get; set; }

		public IActionResult OnGet()
		{
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == Account.Username && a.Password == Account.Password);

			if (account == null)
			{
				ViewData["message"] = "Account is not available. Check your username/ password and try again.";
				return Page();
			}
			else
			{
				int role = 0; //nguoi dung chua dang nhap vao he thong

				HttpContext.Session.SetInt32("id", account.AccountId);
				HttpContext.Session.SetString("Username", Account.Username);
				if (account.Isadmin)
				{
					role = 1; //admin
					HttpContext.Session.SetInt32("role", role);
					return RedirectToPage("Dashboard");
				}
				else if (account.Ismanager)
				{
					role = 2; //manager
					HttpContext.Session.SetInt32("role", role);
					return RedirectToPage("EmployeeDashboard");
				}
				else
				{
					role = 3; //employee
					HttpContext.Session.SetInt32("role", role);
					return RedirectToPage("EmployeeDashboard");
				}

			}
		}
	}
}