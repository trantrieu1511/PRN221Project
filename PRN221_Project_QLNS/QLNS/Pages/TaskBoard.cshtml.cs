using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLNS.Data;
using QLNS.Hubs;
using QLNS.Models;

namespace QLNS.Pages
{
    public class TaskBoardModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PRN221_Project_QLNSContext _context;
        private readonly NotificationHub notification;
        public TaskBoardModel(PRN221_Project_QLNSContext context, IHttpContextAccessor httpContextAccessor,NotificationHub notificationHub)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            notification = notificationHub;
        }
        [BindProperty]
        public Models.Task task1 { get; set; }
        public IList<Models.Task> Pending { get; set; }
        public IList<Models.Task> Progress { get; set; }
        public IList<Models.Task> Review { get; set; }
        public IList<Models.Task> Done { get; set; }
        public List<SelectListItem> Employees { get; set; }
        public async System.Threading.Tasks.Task OnGetAsync()
        {
            string user = _httpContextAccessor.HttpContext.Session.GetString("UserName") ?? "";
            int id = _httpContextAccessor.HttpContext.Session.GetInt32("id") ?? 0;
            int role = _httpContextAccessor.HttpContext.Session.GetInt32("role") ?? 0;
            string ismanager= _httpContextAccessor.HttpContext.Session.GetString("ismanager") ?? "";
            string isadmin = _httpContextAccessor.HttpContext.Session.GetString("isadmin") ?? "";
            if (role == 0)
            {
                this.RedirectToPage("/Login");
            }
            else
            {
                //Employees = await _context.Profiles.Select(_ => new SelectListItem
                //{

                //    Value = _.ProfileId.ToString(),
                //    Text = _.FirstName + " " + _.LastName + "/" + _.Email
                //}.).ToListAsync();
                Employees = await _context.Profiles.
                    Include(a => a.Account).Where(s => s.Account.Isadmin == false && s.Account.Ismanager == false).Select(_ => new SelectListItem
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
;
            Models.Notification n = new Models.Notification
            {
                Username = "lu",
                Message = "Pending New " + task.Name,
                MessageType = "Personal",
                NotificationDateTime = DateTime.Now,
            };
            _context.Tasks.Add(task);
         
          //  _context.SaveChanges();
              
               
                _context.Notifications.Add(n);
               await  _context.SaveChangesAsync();
         // await notification.Clients.All.SendAsync("Load");
            //await notification.Clients.All.SendAsync("LoadNotifition");
            //notification.SendNotificationToClient(n.Message, n.Username);
            return RedirectToPage("./Taskboard");
            

        }


        public async Task<IActionResult> OnPostEdit()
        {
            string user = _httpContextAccessor.HttpContext.Session.GetString("UserName") ?? "";
            int role = _httpContextAccessor.HttpContext.Session.GetInt32("role") ?? 0;
            if (role != 2)
            {
                return this.RedirectToPage("/Login");
            }
            else
            {
                int id = int.Parse(Request.Form["id"]);
                Models.Task task = _context.Tasks.Where(_ => _.TaskId ==id).FirstOrDefault();
                task.Name = Request.Form["name"];
                task.Description = Request.Form["description"];
                task.Deadline = DateTime.ParseExact(Request.Form["deadline"], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                task.Assigned = int.Parse(Request.Form["employee"]);
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return RedirectToPage("./Taskboard");
            }
        }
        public async Task<IActionResult> OnGetDeleteTask(int id)
        {
            string user = _httpContextAccessor.HttpContext.Session.GetString("UserName") ?? "";
            int role = _httpContextAccessor.HttpContext.Session.GetInt32("role") ?? 0;
            if (role != 2)
            {
                return this.RedirectToPage("/Login");
            }
            else
            {
                Models.Task task = _context.Tasks.Where(_ => _.TaskId == id).FirstOrDefault();
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return RedirectToPage("./Taskboard");
            }
        }
        public async Task<IActionResult> OnGetEditTaskStatus(int id, int status)
        {
            Models.Task task = _context.Tasks.Where(_ => _.TaskId == id).FirstOrDefault();
            task.Status = status;
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return RedirectToPage("./Taskboard");
        }
    }
}