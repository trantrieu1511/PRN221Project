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
    /// Interaction logic for LayerWindow.xaml
    /// </summary>
    public partial class LayerWindow : Window
    {
        public LayerWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            int v = RenderPages.Children.Add(new DashboardWindow());
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
      
            Application.Current.Shutdown();
        }
    }
}
