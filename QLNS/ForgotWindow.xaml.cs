using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLNS
{
    /// <summary>
    /// Interaction logic for ForgotWindow.xaml
    /// </summary>
    public partial class ForgotWindow : Window
    {
        private int randomnumber;
        public ForgotWindow()
        {
            InitializeComponent();
        }

        private void btnForgot_Click(object sender, RoutedEventArgs e)
        {
            string to=txtEmail.Text;
            string from = "";
            string pass = "";
            MailMessage mail = new MailMessage();
           SmtpClient smtp= new SmtpClient("smtp.gmail.com");
            Random r= new Random();
            int random = r.Next(1000,9999);
            randomnumber = random;
            //MessageBox.Show(random.ToString());
            mail.To.Add(to);
            mail.From=new MailAddress(from);
            mail.Subject = "PRN221";
            mail.Body = "Code:" + random;
            smtp.EnableSsl= true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try {
                smtp.Send(mail);
                MessageBox.Show("Email sent Succ");
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
