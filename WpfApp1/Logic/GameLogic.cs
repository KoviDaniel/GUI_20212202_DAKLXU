using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ShoresOfGold.Models;

namespace ShoresOfGold.Logic
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
        public Zombie Zombie { get; set; }

        public void SetupSizes(Size mapArea)
        {
            this.mapArea = mapArea;
            Player = new Player(mapArea);
            Zombie= new Zombie(mapArea, this.Player);
        }

        public GameLogic()
        {

        }

        public void PlayerControl(Controls control)
        {
            Player.Move(control);
        }

        public void EnemyControl()
        {
            // Zombie.FollowPlayer(this.Player, this.mapArea);
            Zombie.NewFollowPlayer();
        }

        public void TimeStep()
        {
            Rect playerRect = new Rect(Player.Center.X, Player.Center.Y, Player.Width, Player.Height);
            Rect zombieRect = new Rect(Zombie.Center.X, Zombie.Center.Y, Zombie.Width, Zombie.Height);
            // Zombie.FollowPlayer(Player, mapArea);
            
            EnemyControl();
            Changed?.Invoke(this, null);
        }
    }
}
