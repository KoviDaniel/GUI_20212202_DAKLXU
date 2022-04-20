using MainMenu.Services;
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
            //check save files, if these are not avaible, then call the LoadLobbyWithNew method
            this.service.LobbyOpener();
        }
        public void LoadLobbyWithNew() 
        {
            //deletes earlier save files
            this.service.LobbyOpener();
        }
    }
}
