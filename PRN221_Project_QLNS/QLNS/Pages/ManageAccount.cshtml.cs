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
    }
}
