using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Pages.Task
{
    public class DetailsModel : PageModel
    {
        private readonly QLNS.Data.PRN221_Project_QLNSContext _context;

        public DetailsModel(QLNS.Data.PRN221_Project_QLNSContext context)
        {
            _context = context;
        }

      public Models.Task Task { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FirstOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            else 
            {
                Task = task;
            }
            return Page();
        }
    }
}
