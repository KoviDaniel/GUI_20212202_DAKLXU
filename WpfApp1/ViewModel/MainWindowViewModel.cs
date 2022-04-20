using MainMenu.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MainMenu.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public IMainMenuWindowLogic logic;
        public ICommand LobbyOpenerCommand { get; set; }
        static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IMainMenuWindowLogic>())
        {

        }

        public MainWindowViewModel(IMainMenuWindowLogic logic)
        {
            this.logic = logic;
            LobbyOpenerCommand = new RelayCommand(
                () => logic.LoadLobby()
                );
        }
    }
}
