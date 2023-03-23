using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Pages.Task
{
    public class CreateModel : PageModel
    {
        private readonly QLNS.Data.PRN221_Project_QLNSContext _context;

        public CreateModel(QLNS.Data.PRN221_Project_QLNSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Assigned"] = new SelectList(_context.Profiles, "ProfileId", "ProfileId");
            return Page();
        }

        [BindProperty]
        public Models.Task Task { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tasks == null || Task == null)
            {
                return Page();
            }
            Models.Notification n = new Models.Notification
            {
                Username = "khanhndn0811",
                Message = "Pending New " + Task.Name,
                MessageType = "Personal",
                NotificationDateTime = DateTime.Now,
            };
            _context.Tasks.Add(Task);
        //    await _context.SaveChangesAsync();
          
            _context.Notifications.Add(n);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
