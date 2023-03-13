using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;

namespace QLNS.Pages
{
    public class IndexModel : PageModel //Login page
    {
        private readonly Prn221ProjectQlnsContext _context;

        public IndexModel(Prn221ProjectQlnsContext context)
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
                if (account.Isadmin)
                {
                    role = 1; //admin
                }
                else if (account.Ismanager)
                {
                    role = 2; //manager
                }
                else
                {
                    role = 3; //employee
                }
                HttpContext.Session.SetInt32("role", role);
                HttpContext.Session.SetInt32("id", account.ProfileId);
                HttpContext.Session.SetString("Username", Account.Username);
                return RedirectToPage("/Home");
            }
        }
    }
}