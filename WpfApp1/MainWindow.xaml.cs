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
using System.Windows.Threading;
using WpfApp1.Logic;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameLogic gameLogic;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gameLogic = new GameLogic();
            // logic.GameOver += Logic_GameOver;
            display.SetupModel(gameLogic);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(10);
            dt.Tick += Dt_Tick;
            dt.Start();

            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            gameLogic.SetupSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
        }

        private void Dt_Tick(object sender, EventArgs e)
        {           
            Control();
            gameLogic.TimeStep();
            this.InvalidateVisual();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) { }

        private void Window_KeyUp(object sender, KeyEventArgs e) { }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (gameLogic != null)
            {
                display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
                gameLogic.SetupSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            }
        }

        private void Control()
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                gameLogic.PlayerControl(Controls.Up);
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                gameLogic.PlayerControl(Controls.Down);

            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                gameLogic.PlayerControl(Controls.Left);

            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                gameLogic.PlayerControl(Controls.Right);

            }
        }
    }
}
