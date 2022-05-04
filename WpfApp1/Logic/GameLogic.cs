using ShoresOfGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
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

        const int topWallThickness = 700 / 3;
        const int bottomWallThickness = 340 / 3;
        public Wall TopWall { get; set; }
        public Wall BottomWall { get; set; }

        public void SetupSizes(Size mapArea)
        {
            this.mapArea = mapArea;
            Player = new Player(mapArea);
        }

        public GameLogic(Size mapArea)
        {
            TopWall = new Wall(new Point(0, 0), new Point(mapArea.Width, 0), topWallThickness);
            BottomWall = new Wall(new Point(0, mapArea.Height - bottomWallThickness), 
                new Point(mapArea.Width, mapArea.Height - bottomWallThickness), bottomWallThickness);
        }

        public void PlayerControl(Controls control)
        {           
            Player.Move(control);
        }

        public void TimeStep()
        {            
            Rect playerRect = new Rect(Player.Center.X, Player.Center.Y, Player.Width, Player.Height);
            Changed?.Invoke(this, null);
        }
    }
}
