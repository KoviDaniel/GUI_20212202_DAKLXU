﻿using System;
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
        //private Display display;
        public LobbyWindow()
        {
            InitializeComponent();
           // display = new Display();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gameLogic = new GameLogic();
            
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
            if (Keyboard.IsKeyDown(Key.Escape)) this.Close();

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (gameLogic != null) {
                display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
                gameLogic.SetupSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to return to the menu?", "Confirm",
           MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
