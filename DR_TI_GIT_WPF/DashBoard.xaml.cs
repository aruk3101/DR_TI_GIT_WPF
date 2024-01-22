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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DR_TI_GIT_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Page
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SnakeGame());
        }
    }
}
