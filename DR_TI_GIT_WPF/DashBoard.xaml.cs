using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.WebRequestMethods;

namespace DR_TI_GIT_WPF
{
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            Directory.CreateDirectory("saves/");
            string[] files = Directory.GetFiles("saves/");
            List<FileInfo> fileInfos = new List<FileInfo>();
            foreach (string filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                fileInfos.Add(fileInfo);
            }
            lstview.ItemsSource = fileInfos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new SnakeGame());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //if (lstview.SelectedItem == null) return;
            //FileInfo fileInfo = lstview.SelectedItem as FileInfo;
            //string[] contents = System.IO.File.ReadAllText(fileInfo.FullName).Split(';');
            //NavigationService.Navigate(new SnakeGame(
            //        Convert.ToInt32(contents[0]),
            //        Convert.ToInt32(contents[1]),
            //        Convert.ToInt32(contents[2]),
            //        Convert.ToInt32(contents[3])
            //    ));

        }
    }
}
