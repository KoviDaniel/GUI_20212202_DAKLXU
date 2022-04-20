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
using System.Windows.Threading;
using WpfApp1.Logic;
using WpfApp1.Renderer;

namespace MainMenu
{
    /// <summary>
    /// Interaction logic for LobbyWindow.xaml
    /// </summary>
    public partial class LobbyWindow : Window
    {
        private GameLogic gameLogic;
        private Display display;
        public LobbyWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gameLogic = new GameLogic();
            display = new Display();
            display.SetupModel(gameLogic);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(10);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            Control();
            gameLogic.TimeStep();
            this.InvalidateVisual();
        }

        private void Control() {
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
