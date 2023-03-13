using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;

namespace QLNS.Pages
{
    public class HomeModel : PageModel
    {
        public HomeModel()
        {

        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
