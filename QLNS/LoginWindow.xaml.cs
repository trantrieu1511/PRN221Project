using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountRespository accountRespository;

        public LoginWindow(IAccountRespository _accountRespository)
        {
            accountRespository = _accountRespository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtEmail.Text.ToString();
            string password = txtPassword.Password.ToString();
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                if (accountRespository.FindByEmailAndPassword(username, password) != null)
                {
                    WpfMessageBox.Show("ok");
                    LayerWindow lay= new LayerWindow();
                    lay.Show();
                    this.Hide();
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnForgot_Click(object sender, RoutedEventArgs e)
        {
            ForgotWindow forgotWindow = new ForgotWindow();
            forgotWindow.Show();
        }
    }
}
