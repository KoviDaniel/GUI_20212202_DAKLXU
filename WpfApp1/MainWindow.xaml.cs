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
            dt.Interval = TimeSpan.FromMilliseconds(100);
            dt.Tick += Dt_Tick;
            dt.Start();

            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            gameLogic.SetupSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            gameLogic.TimeStep();
            this.InvalidateVisual();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                gameLogic.Control(Controls.Up);
                
            }
            else if (e.Key == Key.S)
            {
                gameLogic.Control(Controls.Down);
                
            }
            else if (e.Key == Key.A)
            {
                gameLogic.Control(Controls.Left);
                
            }
            else if (e.Key == Key.D)
            {
                gameLogic.Control(Controls.Right);
                
            }
            this.InvalidateVisual();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (gameLogic != null)
            {
                display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
                gameLogic.SetupSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            }
        }
    }
}
