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
using ShoresOfGold.Logic;

namespace MainMenu
{
    /// <summary>
    /// Interaction logic for LobbyWindow.xaml
    /// </summary>
    public partial class LobbyWindow : Window
    {
        private GameLogic gameLogic;

        public LobbyWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gameLogic = new GameLogic(new Size(lobby_grid.ActualWidth, lobby_grid.ActualHeight));
            // logic.GameOver += Logic_GameOver;
            display.SetupModel(gameLogic);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(10);
            dt.Tick += Dt_Tick;
            dt.Start();

            display.SetupSizes(new Size(lobby_grid.ActualWidth, lobby_grid.ActualHeight));
            gameLogic.SetupSizes(new Size((int)lobby_grid.ActualWidth, (int)lobby_grid.ActualHeight));
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            PlayerControl();        
            gameLogic.TimeStep();
            this.InvalidateVisual();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (gameLogic != null)
            {
                display.SetupSizes(new Size(lobby_grid.ActualWidth, lobby_grid.ActualHeight));
                gameLogic.SetupSizes(new Size((int)lobby_grid.ActualWidth, (int)lobby_grid.ActualHeight));
            }
        }
        private void PlayerControl()
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
            if (Keyboard.IsKeyDown(Key.E)) 
            {
                gameLogic.PlayerControl(Controls.Open);
            }           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //gameLogic.PlayerControl(Controls.Melee);
            gameLogic.PlayerAttackControl(Controls.Melee, e.GetPosition(display));
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //e.GetPosition(display);
            //gameLogic.PlayerControl(Controls.Range);
            gameLogic.PlayerAttackControl(Controls.Range, e.GetPosition(display));
        }
    }
}
