using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Models;
using System.Globalization;

namespace QLNS.Pages
{
    public class EmployeeListModel : PageModel
    {
        private readonly PRN221_Project_QLNSContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public EmployeeListModel(PRN221_Project_QLNSContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        public IList<Profile> Profiles { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync(string name, string email)
        {
            Name = name;
            Email = email;
            int userAccID = _contextAccessor.HttpContext.Session.GetInt32("id") ?? 0;
            if (userAccID != 0)
            {
                int userProfileID = _context.Profiles.FirstOrDefault(_ => _.AccountId == userAccID).ProfileId;
                
                if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(email))
                {
                    Profiles = await _context.Profiles.
                        Where(_ => _.ReportTo == userProfileID &&
                        _.FirstName.ToLower().Contains(name.ToLower()) ||
                        _.LastName.ToLower().Contains(name.ToLower())).ToListAsync();
                }
                else if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
                {
                    Profiles = await _context.Profiles.
                       Where(_ => _.ReportTo == userProfileID &&
                       _.Email.ToLower().Contains(email.ToLower())).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
                {
                    Profiles = await _context.Profiles.
                        Where(_ => _.ReportTo == userProfileID &&
                        _.Email.ToLower().Contains(email.ToLower()) &&
                        _.FirstName.ToLower().Contains(name.ToLower()) ||
                        _.LastName.ToLower().Contains(name.ToLower())).ToListAsync();
                } 
                else if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(email))
                {
                    Profiles = await _context.Profiles.Where(_ => _.ReportTo == userProfileID).ToListAsync();
                }
            }
        }
        public async Task<IActionResult> OnPostAdd()
        {
            Account acc = new Account
            {
                Username = Request.Form["username"],
                Password = "123456",
                Isadmin = false,
                Ismanager = false
            };
            _context.Accounts.Add(acc);
            _context.SaveChanges();
            Account newAcc = _context.Accounts.OrderBy(_ => _.AccountId).Last();
            int userAccID = _contextAccessor.HttpContext.Session.GetInt32("id") ?? 0;
            int userProfileID = 0;
            if (userAccID != 0)
            {
                userProfileID = _context.Profiles.FirstOrDefault(_ => _.AccountId == userAccID).ProfileId;
            }
            Profile profile = new Profile
            {
                AccountId = newAcc.AccountId,
                FirstName = Request.Form["firstname"],
                LastName = Request.Form["lastname"],
                Email = Request.Form["email"],
                PhoneNumber = Request.Form["phone"],
                HireDate = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                Job = Request.Form["job"],
                ReportTo = userProfileID
            };
            _context.Profiles.Add(profile);
            _context.SaveChanges();
            return RedirectToPage("./EmployeeList");
        }
        public async Task<IActionResult> OnPostEdit()
        {
            int id = int.Parse(Request.Form["id"]);
            Profile profile = _context.Profiles.Where(_ => _.ProfileId == id).FirstOrDefault();

            profile.FirstName = Request.Form["firstname"];
            profile.LastName = Request.Form["lastname"];
            profile.Email = Request.Form["email"];
            profile.PhoneNumber = Request.Form["phone"];
            profile.Job = Request.Form["job"];

            _context.Profiles.Update(profile);
            _context.SaveChanges();
            return RedirectToPage("./EmployeeList");
        }
        public async Task<IActionResult> OnPostDelete()
        {
            int id = int.Parse(Request.Form["id"]);
            Profile profile = _context.Profiles.Where(_ => _.ProfileId == id).FirstOrDefault();
            Account acc = _context.Accounts.Where(_ => _.AccountId == profile.AccountId).FirstOrDefault();
            _context.Profiles.Remove(profile);
            _context.SaveChanges();
            _context.Accounts.Remove(acc);
            _context.SaveChanges();
            return RedirectToPage("./EmployeeList");
        }
    }
}
