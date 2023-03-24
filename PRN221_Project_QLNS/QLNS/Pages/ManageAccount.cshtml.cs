using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Pages
{
    public class ManageAccountModel : PageModel
    {
        private readonly PRN221_Project_QLNSContext _context;

		public ManageAccountModel(PRN221_Project_QLNSContext context)
		{
			_context = context;
		}

		public IList<Account> Accounts { get; set; }

		public async System.Threading.Tasks.Task OnGetAsync()
		{
			Accounts = await _context.Accounts.ToListAsync();
		}
        //public async Task<IActionResult> OnPostDelete()
        //{
        //    int id = int.Parse(Request.Form["id"]);
        //    Account acc = _context.Accounts.Where(_ => _.AccountId == id).FirstOrDefault();
        //    Profile profile = _context.Profiles.Where(_ => _.AccountId == id).
        //    _context.Profiles.Remove(profile);
        //    _context.SaveChanges();
        //    _context.Accounts.Remove(acc);
        //    _context.SaveChanges();
        //    return RedirectToPage("./EmployeeList");
        //}
    }
}
