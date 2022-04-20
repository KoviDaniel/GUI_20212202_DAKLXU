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

            //Player = new Player(mapArea.Width / 2, mapArea.Height / 2);
            Player = new Player(mapArea);
        }

        public GameLogic()
        {

        }

        public void PlayerControl(Controls control)
        {
            Player.Move(control);
        }

        public void TimeStep()
        {
            //Rect playerRect = new Rect(Player.X, Player.Y, Player.PlayerWidth, Player.PlayerHeight);
            Rect playerRect = new Rect(Player.Center.X, Player.Center.Y, Player.PlayerWidth, Player.PlayerHeight);
            Changed?.Invoke(this, null);
        }
    }
}
