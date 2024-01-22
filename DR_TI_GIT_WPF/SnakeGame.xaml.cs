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
    /// Logika interakcji dla klasy SnakeGame.xaml
    /// </summary>
    public partial class SnakeGame : Page
    {
        public SnakeGame()
        {
            InitializeComponent();
            Loaded += SnakeGame_Loaded;
        }

        private void SnakeGame_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
