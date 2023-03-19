using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Pages
{
    public class TaskBoardModel : PageModel
    {
        private readonly PRN221_Project_QLNSContext _context;

        public TaskBoardModel(PRN221_Project_QLNSContext context)
        {
            _context = context;
        }

        public IList<Models.Task> Pending { get; set; }
        public IList<Models.Task> Progress { get; set; }
        public IList<Models.Task> Review { get; set; }
        public IList<Models.Task> Done { get; set; }
        public List<SelectListItem> Employees { get; set; }
        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Employees = await _context.Profiles.Select(_ => new SelectListItem
            {
                Value = _.ProfileId.ToString(),
                Text = _.FirstName + " " + _.LastName + "/" + _.Email
            }).ToListAsync();
            if (_context.Tasks != null)
            {
                Pending = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 0).ToListAsync();
                Progress = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 1).ToListAsync();
                Review = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 2).ToListAsync();
                Done = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 3).ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostAdd()
        {
            Models.Task task = new Models.Task
            {
                Name = Request.Form["name"],
                Description = Request.Form["description"],
                Deadline = DateTime.ParseExact(Request.Form["deadline"], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                Status = 0,
                Assigned = int.Parse(Request.Form["employee"]),
            };
            _context.Tasks.Add(task);   
            _context.SaveChanges();
            return RedirectToPage("./Taskboard");
        }
        public async Task<IActionResult> OnPostEdit()
        {
            Models.Task task = _context.Tasks.Where(_ => _.TaskId == Request.Form["id"]).FirstOrDefault();
            task.Name = Request.Form["name"];
            task.Description = Request.Form["description"];
            task.Deadline = DateTime.ParseExact(Request.Form["deadline"], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            task.Assigned = int.Parse(Request.Form["employee"]);
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return RedirectToPage("./Taskboard");
        }
        public async Task<IActionResult> DeleteTask(int id)
        {
            Models.Task task = _context.Tasks.Where(_ => _.TaskId == id).FirstOrDefault();
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToPage("./Taskboard");
        }
        public async Task<IActionResult> EditTaskStatus(int id, int status)
        {
            Models.Task task = _context.Tasks.Where(_ => _.TaskId == id).FirstOrDefault();
            task.Status = status;
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return RedirectToPage("./Taskboard");
        }
    }
}
