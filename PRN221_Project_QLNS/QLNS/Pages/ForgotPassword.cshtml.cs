using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;

namespace QLNS.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        public string To { get; set; }
        public async System.Threading.Tasks.Task OnPost()
        {
            string from = "";
            string pass = "";
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            Random r = new Random();
            int random = r.Next(1000, 9999);
            mail.To.Add(To);
            mail.From = new MailAddress(from);
            mail.Subject = "PRN221";
            mail.Body = "Code:" + random;
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            await smtp.SendMailAsync(mail);
        }
    }
}
