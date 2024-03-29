using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLNS.Data;
using QLNS.Hubs;
using QLNS.Models;
using System.Net;
using System.Net.Mail;

namespace QLNS.Pages
{
    public class TaskBoardModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PRN221_Project_QLNSContext _context;
        private readonly NotificationHub notification;
        public TaskBoardModel(PRN221_Project_QLNSContext context, IHttpContextAccessor httpContextAccessor, NotificationHub notificationHub)
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
        public async Task<IActionResult> OnGetAsync()
        {
            string user = _httpContextAccessor.HttpContext.Session.GetString("UserName") ?? "";
            int id = _httpContextAccessor.HttpContext.Session.GetInt32("id") ?? 0;
            int role = _httpContextAccessor.HttpContext.Session.GetInt32("role") ?? 0;
            string ismanager = _httpContextAccessor.HttpContext.Session.GetString("ismanager") ?? "";
            string isadmin = _httpContextAccessor.HttpContext.Session.GetString("isadmin") ?? "";
            if (role == 0)
            {
                return RedirectToPage("/Login");
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
                    if (role == 3)
                    {
                        Pending = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 0 && _.AssignedNavigation.Account.AccountId == id).ToListAsync();
                        Progress = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 1 && _.AssignedNavigation.Account.AccountId == id).ToListAsync();
                        Review = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 2 && _.AssignedNavigation.Account.AccountId == id).ToListAsync();
                        Done = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 3 && _.AssignedNavigation.Account.AccountId == id).ToListAsync();
                    }
                    else
                    {
                        Pending = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 0).ToListAsync();
                        Progress = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 1).ToListAsync();
                        Review = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 2).ToListAsync();
                        Done = await _context.Tasks.Include(_ => _.AssignedNavigation).Where(_ => _.Status == 3).ToListAsync();
                    }

                }

                //Automatically change task from progress to review when reach deadline (working on...)
                /*foreach (var item in Progress)
                {
                    if (item.Deadline <= DateTime.Now)
                    {
                        Models.Task t = new Models.Task
                        {

                        };
                        item.Status = 2; //Change task status to review
                        await _context.SaveChangesAsync();
                    }
                }*/

                return Page();
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

            Profile p = _context.Profiles.Include(p => p.Account).FirstOrDefault(p => p.ProfileId == int.Parse(Request.Form["employee"]));

            Models.Notification n = new Models.Notification
            {
                Username = p.Account.Username,
                Message = "Pending New " + task.Name,
                MessageType = "Personal",
                NotificationDateTime = DateTime.Now,
            };

            //Uncomment and then input your email account here to recieve notification about new task
            /*string from = "";
            string pass = "";

            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            Random r = new Random();
            int random = r.Next(1000, 9999);
            DateTime now2 = DateTime.Now;
            mail.To.Add(p.Email);
            mail.From = new MailAddress(from);
            mail.Subject = "PRN221";
            mail.Body = "New Pending Task:" + task.Deadline.ToString() + ". There's " + (task.Deadline - now2) + " day left to finish.";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);*/

            _context.Tasks.Add(task);

            //  _context.SaveChanges();

            _context.Notifications.Add(n);
            await _context.SaveChangesAsync();
            // await notification.Clients.All.SendAsync("Load");
            //   await notification.Clients.All.SendAsync("LoadMEDashboard");
            //await notification.Clients.All.SendAsync("LoadNotifition");
            //notification.SendNotificationToClient(n.Message, n.Username);

            //Uncomment the line below to use email notification
            //await smtp.SendMailAsync(mail);

            return RedirectToPage("./Taskboard");
        }


        public async Task<IActionResult> OnPostEdit()
        {

            int id = int.Parse(Request.Form["id"]);
            Models.Task task = _context.Tasks.Where(_ => _.TaskId == id).FirstOrDefault();
            task.Name = Request.Form["name"];
            task.Description = Request.Form["description"];
            task.Deadline = DateTime.ParseExact(Request.Form["deadline"], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            task.Assigned = int.Parse(Request.Form["employee"]);
            //   _context.Tasks.Update(task);
            Profile p = _context.Profiles.Include(p => p.Account).FirstOrDefault(p => p.ProfileId == int.Parse(Request.Form["employee"]));

            Models.Notification n = new Models.Notification
            {
                Username = p.Account.Username,
                Message = "Edit update " + task.Name,
                MessageType = "Personal",
                NotificationDateTime = DateTime.Now,
            };
            _context.Tasks.Update(task);
            _context.Notifications.Add(n);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Taskboard");

        }
        public async Task<IActionResult> OnGetDeleteTask(int id)
        {
            Models.Task task = _context.Tasks.Where(_ => _.TaskId == id).FirstOrDefault();

            Profile p = _context.Profiles.Include(p => p.Account).FirstOrDefault(p => p.ProfileId == task.Assigned);

            Models.Notification n = new Models.Notification
            {
                Username = p.Account.Username,
                Message = "Deleted " + task.Name,
                MessageType = "Personal",
                NotificationDateTime = DateTime.Now,
            };
            _context.Tasks.Remove(task);
            _context.Notifications.Add(n);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Taskboard");
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