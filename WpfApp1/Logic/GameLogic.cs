using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.Logic
{
    public enum Controls
    {
        Up, Down, Left, Right
    }

    public class GameLogic : IGameModel
    {
        private Size mapArea;
        public event EventHandler Changed; //public event EventHandler GameOver;
        public Player Player { get; set; }

        public void SetupSizes(Size mapArea)
        {
            this.mapArea = mapArea;
            Player = new Player(mapArea.Width / 2, mapArea.Height / 2, 25, 25);
        }

        public GameLogic()
        {

        }

        public void Control(Controls control)
        {
            switch (control)
            {
                case Controls.Up:
                    Player.Move(control);
                    break;
                case Controls.Down:
                    Player.Move(control);
                    break;
                case Controls.Left:
                    Player.Move(control);
                    break;
                case Controls.Right:
                    Player.Move(control);
                    break;
            }
        }

        public void TimeStep()
        {
            Rect playerRect = new Rect(Player.X, Player.Y, Player.PlayerWidth, Player.PlayerHeight);
            Changed?.Invoke(this, null);
        }
    }
}
