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
    public class IndexModel : PageModel
    {
        private readonly QLNS.Data.PRN221_Project_QLNSContext _context;

        public IndexModel(QLNS.Data.PRN221_Project_QLNSContext context)
        {
            _context = context;
        }

        public IList<Models.Task> Task { get;set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            if (_context.Tasks != null)
            {
                Task = await _context.Tasks
                .Include(t => t.AssignedNavigation).ToListAsync();
            }
        }
    }
}
