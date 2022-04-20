using MainMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Page
    {
        private int click_counter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }     

        private void Button_Click_Continue(object sender, RoutedEventArgs e)
        {
            if (click_counter == 0)
            {
                GraphicalEffects.StartTransition<LobbyWindow>(mainmenu_canvas, MainMenuPage);
                click_counter++;
            }
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
