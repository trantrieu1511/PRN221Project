using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Pages.Notification
{
    public class DetailsModel : PageModel
    {
        private readonly QLNS.Data.PRN221_Project_QLNSContext _context;

        public DetailsModel(QLNS.Data.PRN221_Project_QLNSContext context)
        {
            _context = context;
        }

      public Models.Notification Notification { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications.FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }
            else 
            {
                Notification = notification;
            }
            return Page();
        }
    }
}
