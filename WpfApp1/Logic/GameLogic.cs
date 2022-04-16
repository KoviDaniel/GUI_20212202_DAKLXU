using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Logic
{
    public enum Controls
    {
        Up, Down, Left, Right
    }

    public class GameLogic
    {
        private System.Windows.Size mapArea;
        public event EventHandler Changed; //public event EventHandler GameOver;
        public Player Player { get; set; }

        public void SetupSizes(System.Windows.Size mapArea)
        {
            this.mapArea = mapArea;
            Player = new Player(mapArea);
        }

        public GameLogic()
        {

        }

        public void Control(Controls control)
        {
            switch (control) 
            {
                case Controls.Up:
                    Player.Move(mapArea);
                    break;
                case Controls.Down:
                    break;
                case Controls.Left:
                    break;
                case Controls.Right:
                    break;
            }
        }
    }
}
