using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using QLNS.Data;
using QLNS.Hubs;

namespace QLNS.Pages
{
    public class EmployeeDashboardModel : PageModel
    {

        private readonly PRN221_Project_QLNSContext _context;
        private readonly NotificationHub _signalR;

        public EmployeeDashboardModel(PRN221_Project_QLNSContext context, NotificationHub signalR)
        {
            _context = context;
            _signalR = signalR;
        }

        public int TotalTask { get; set; }
        public int PendingTask { get; set; }

        public void OnGet()
        {
            TotalTask = _context.Tasks.ToList().Count;
            PendingTask = _context.Tasks.Where(_ => _.Status == 0).ToList().Count;
        }
    }
}
