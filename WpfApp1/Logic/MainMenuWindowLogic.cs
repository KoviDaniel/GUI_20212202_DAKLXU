using MainMenu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu.Logic
{
    public class MainMenuWindowLogic : IMainMenuWindowLogic
    {
        ILobbyOpenerService service;
        public MainMenuWindowLogic(ILobbyOpenerService service)
        {
            this.service = service;
        }
        public void LoadLobby()
        {
            this.service.LobbyOpener();
        }
    }
}
