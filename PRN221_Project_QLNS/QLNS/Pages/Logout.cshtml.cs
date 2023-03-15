using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace PRN221_Assigment2.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.SetInt32("role", 0);
            HttpContext.Session.SetInt32("id", 0);
            HttpContext.Session.SetString("Username", "");
            return this.RedirectToPage("/Login");
        }
    }
}
