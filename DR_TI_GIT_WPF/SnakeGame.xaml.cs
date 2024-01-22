using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
using System.Windows.Threading;

namespace DR_TI_GIT_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy SnakeGame.xaml
    /// </summary>
    public partial class SnakeGame : Page
    {
        int size = 32;
        int width, height, stepx, stepy, length, point;
        DispatcherTimer timer;
        Point snake, food;

        public SnakeGame()
        {
            InitializeComponent();
            Loaded += SnakeGame_Loaded;
        }

        private void SnakeGame_Loaded(object sender, RoutedEventArgs e)
        {
            width = (int)canvas.ActualWidth;
            height = (int)canvas.ActualHeight;
            snake = new Point(width/2, height/2);

            Dispa
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddFood()
        {

        }


        private Rectangle CreateRectangle(Point point, Brush brush)
        {
            Rectangle rectangle = new Rectangle()
            {
                Width = size,
                Height = size,
                Fill = brush
            };
            Canvas.SetLeft(rectangle, point.X);
            Canvas.SetTop(rectangle, point.Y);
            return rectangle;
        }

        private void GoBack()
        {
            timer.Stop();
            NavigationService.GoBack();
        }

        private void GameWin()
        {
            MessageBox.Show("Wygrałeś");
            GoBack();
        }
        private void GameLost()
        {
            MessageBox.Show("Przegrałeś");
            GoBack();
        }

        private bool isCross(Point A, Point B)
        {
            return (Math.Abs(A.X - B.Y) < size && Math.Abs(A.Y - B.Y) < size);
        }

        private bool isOutOfBorder(Point A)
        {
            return A.X < 0 || A.Y < 0 || A.X-size > width || A.Y-size > height ;
        }

        }
}
