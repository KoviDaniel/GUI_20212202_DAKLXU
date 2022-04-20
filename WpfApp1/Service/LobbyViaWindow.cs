using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu.Service
{
    public class LobbyViaWindow : ILobbyOpenerService
    {
        public void LobbyOpener()
        {
            new LobbyWindow().ShowDialog();
        }
    }
}
