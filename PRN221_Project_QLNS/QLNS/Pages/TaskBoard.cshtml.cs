using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Pages
{
    public class TaskBoardModel : PageModel
    {
        private readonly Prn221ProjectQlnsContext _context;

        public TaskBoardModel(Prn221ProjectQlnsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Models. Task> Pending { get; set; }
        [BindProperty]
        public List<Models.Task> Progress { get; set; }
        [BindProperty]
        public List<Models.Task> Review { get; set; }
        [BindProperty]
        public List<Models.Task> Done { get; set; }

        public void OnGet()
        {
            Pending = _context.Tasks.Where(_ => _.Status == 0).ToList();

;        }
    }
}
