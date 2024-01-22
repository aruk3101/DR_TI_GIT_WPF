using DR_TI_GIT_WPF;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DR_TI_GIT_WPF
{
    public partial class SnakeGame : Page
    {
        const int size = 32;
        DispatcherTimer timer;
        int width, height, stepx, stepy, length, points;
        Point snake, food;

        public SnakeGame(int sx, int sy, int fx, int fy)
        {
            InitializeComponent();
            this.Loaded += SnakeGame_Loaded;
            snake = new Point(sx, sy);
            food = new Point(fx, fy);
            Rectangle ellipse = CreateRectangle(food, Brushes.Green);
            if (canvas.Children.Count > 0)
                canvas.Children.RemoveAt(0);
            canvas.Children.Insert(0, ellipse);
            length++;
        }
        public SnakeGame()
        {
            InitializeComponent();
            this.Loaded += SnakeGame_Loaded;
        }

        private void SnakeGame_Loaded(object sender, RoutedEventArgs e)
        {
            width = (int)canvas.ActualWidth;
            height = (int)canvas.ActualHeight;
            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(20000),
                IsEnabled = true
            };
            timer.Tick += GameRun;
            if (food.X == 0 && food.Y == 0) AddFood();
            if (snake.X == 0 && snake.Y == 0) snake = new Point(width / 2, height / 2);
            stepx = stepy = 0;
            MoveSnake();
            MainWindow.Instance.PreviewKeyDown += MainWindow_KeyDown;
        }

        private void UnsubscribeKeyDownEvent()
        {
            MainWindow.Instance.PreviewKeyDown -= MainWindow_KeyDown;
        }

        private void GoBack()
        {
            timer.Stop();
            UnsubscribeKeyDownEvent();
            this.NavigationService.GoBack();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case (Key.Down): stepx = 0; stepy = -1; break;
                case (Key.Up): stepx = 0; stepy = +1; break;
                case (Key.Right): stepx = +1; stepy = 0; break;
                case (Key.Left): stepx = -1; stepy = 0; break;
            }
        }

        private void GameRun(object sender, EventArgs e)
        {
            MoveSnake();
            if (isOutOfBorder(snake))
                GameLost();
            if (isCross(snake, food))
                if (++points == 100)
                {
                    canvas.Children.RemoveAt(0);
                    GameWin();
                }
                else
                {
                    AddFood();
                }
            punkty.Content = $"Punkty: {points}/100";
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private void MoveSnake()
        {
            snake.X += stepx * 6; // 6 pixeli na interval sie rusza
            snake.Y += stepy * 6;
            Rectangle ellipse = CreateRectangle(snake, Brushes.Red);
            if (canvas.Children.Count > length)
                canvas.Children.RemoveAt(length);
            canvas.Children.Insert(1, ellipse);

        }

        private void AddFood()
        {
            Random random = new Random();
            food = new Point(random.Next(width - size), random.Next(height - size));
            Rectangle ellipse = CreateRectangle(food, Brushes.Green);
            if (canvas.Children.Count > 0)
                canvas.Children.RemoveAt(0);
            canvas.Children.Insert(0, ellipse);
            length++;
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
            Canvas.SetBottom(rectangle, point.Y);
            return rectangle;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("saves/" + DateTime.Now.ToString("yyyyMMddHHmmss"), $"{snake.X};{snake.Y};{food.X};{food.Y}");
            GoBack();
        }

        private bool isCross(Point A, Point B)
        {
            return (Math.Abs(A.X - B.X)) < size && (Math.Abs(A.Y - B.Y)) < size;
        }

        private bool isOutOfBorder(Point A)
        {
            return A.X < 0 || A.Y < 0 || A.X - size > width || A.Y - size > height;
        }
    }
}