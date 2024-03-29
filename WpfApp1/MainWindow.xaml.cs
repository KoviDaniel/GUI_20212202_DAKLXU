﻿using MainMenu;
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
using ShoresOfGold.Logic;

namespace ShoresOfGold
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Media.SoundPlayer mediaPlayer = new System.Media.SoundPlayer();
        public MainWindow()
        {
            InitializeComponent();
            mediaPlayer.SoundLocation = "Sounds/menu.wav";
            mediaPlayer.PlayLooping();
        }

        private void Button_Click_Continue(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            var cApp = ((App)Application.Current);
            cApp.MainWindow = new LobbyWindow();
            cApp.MainWindow.Show();
            this.Close();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
