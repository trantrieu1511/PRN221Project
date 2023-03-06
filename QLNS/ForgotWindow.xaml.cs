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
using System.Windows.Threading;

namespace QLNS
{
    /// <summary>
    /// Interaction logic for ForgotWindow.xaml
    /// </summary>
    public partial class ForgotWindow : Window
    {
        private int randomnumber;
        private int time = 30;
        private DispatcherTimer Timer;
        public ForgotWindow()
        {
            InitializeComponent();
            Timer=new DispatcherTimer();
            Timer.Interval = new TimeSpan(0,0,1);
            Timer.Tick += Timer_Tick;
           
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (time > 00)
            {
                time--;
                txtTime.Text = string.Format("0{0}:{1}", time / 60, time%60);
              
                
            }
            else
            {
                Timer.Stop();
                txtCode.IsEnabled = false;
                btnforgot.Content = "Send Mail";
                txtCode.Text = "";
                time = 30;
                txtEmail.Text = "";
                WpfMessageBox.Show("het thoi gian vui long nhap lai email roi gui lai");
            }
        }

        private void btnForgot_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                WpfMessageBox.Show("Email not Null");
            }
            else
            {

                if (btnforgot.Content.ToString().Equals("Send Mail") && !String.IsNullOrEmpty(txtEmail.Text))
                {

                    string to = txtEmail.Text;
                    string from = "";
                    string pass = "";
                    MailMessage mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    Random r = new Random();
                    int random = r.Next(1000, 9999);
                    randomnumber = random;
                    //MessageBox.Show(random.ToString());
                    // mail.To.Add(to);
                    //mail.From=new MailAddress(from);
                    //mail.Subject = "PRN221";
                    //mail.Body = "Code:" + random;
                    //smtp.EnableSsl= true;
                    //smtp.Port = 587;
                    // smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        //smtp.Send(mail);
                        WpfMessageBox.Show("Email sent Succ " + random, "send email");
                        Timer.Start();


                        txtEmail.IsEnabled = false;
                        txtCode.IsEnabled = true;
                        btnforgot.Content = "Forgot Password";
                    }
                    catch (Exception ex)
                    {
                        WpfMessageBox.Show(ex.Message);
                    }

                }
                else if (txtCode.Text.ToString().Equals(randomnumber.ToString()))
                {
                    Timer.Stop();
                    txtTime.Visibility = Visibility.Collapsed;
                    passworkagainstack.Visibility = Visibility.Visible;
                    passworkstack.Visibility = Visibility.Visible;
                    txtCode.Visibility = Visibility.Collapsed;
                    WpfMessageBox.Show("code thanh cong", "Code");
                }
                else
                {
                    WpfMessageBox.Show("code sai", "Code");
                }
            }

           
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
