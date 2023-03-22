using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly PRN221_Project_QLNSContext _context;

        public ProfileModel(PRN221_Project_QLNSContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Profile Profile { get; set; }
        public Profile Manager { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync(int? id)
        {
            Profile = await _context.Profiles.FirstOrDefaultAsync(_ => _.AccountId == id);
            Manager = await _context.Profiles.FirstOrDefaultAsync(_ => _.ProfileId == Profile.ReportTo);
        }
        public async Task<IActionResult> OnPostEdit()
        {
            _context.Profiles.Update(Profile);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Profile", new {id = Profile.AccountId});
        }
    }
}
