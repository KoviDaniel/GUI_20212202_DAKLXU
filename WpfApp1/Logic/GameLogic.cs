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
        Up, Down, Left, Right, Open, Melee, Range
    }

    public class GameLogic : IGameModel
    {
        Random r = new Random();
        private Size mapArea;
        public event EventHandler Changed; //public event EventHandler GameOver;
        public Player Player { get; set; }
        //public Zombie Zombie { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Bullet> Bullets { get; set; }
        
        public List<Chest> Chests { get; set; }

        public void SetupSizes(Size mapArea)
        {
            this.mapArea = mapArea;
            Player = new Player(mapArea);
            //Zombie= new Zombie(mapArea, this.Player);
            this.Enemies = new List<Enemy>();
            this.Bullets = new List<Bullet>();
            this.Chests = new List<Chest>();
            for (int i = 0; i < r.Next(3,7); i++)
            {
                GenerateEnemies();
            }
            for (int i = 0; i < r.Next(4,13); i++)
            {
                this.Chests.Add(new Chest(mapArea));
            }
        }

        public void GenerateEnemies() 
        {
            int num = r.Next(3, 3);
            if (num == 0)
            {
                this.Enemies.Add(new Zombie(mapArea, Player));
            }
            else if (num == 1)
            {
                this.Enemies.Add(new Brute(mapArea, Player));
            }
            else 
            {
                this.Enemies.Add(new Sniper(mapArea, Player));
            }
        }

        public GameLogic()
        {

        }

        public void PlayerAttackControl(Controls control, Point cursor) 
        {
            if (control == Controls.Melee) Player.MeleeAttack(Enemies);
            if (control == Controls.Range) Player.RangeAttack(Enemies, cursor);
        }

        public void PlayerControl(Controls control)
        {
            if(control != Controls.Open && control != Controls.Melee && control != Controls.Range) Player.Move(control);
            if (control == Controls.Open) Player.Interact(control, Chests);
        }

        public void EnemyControl()
        {
            // Zombie.FollowPlayer(this.Player, this.mapArea);
            /*Zombie.NewFollowPlayer();
            Zombie.Attack();*/

            Bullets.Clear();
            this.Player.BulletLife(Enemies);
            Bullets.AddRange(this.Player.Bullets);
            // Enemy removeable = null;
            List<Enemy> removing = new List<Enemy>();
            foreach (var e in Enemies)
            {
                if (e.Health <= 0)
                {
                    removing.Add(e);
                }
                else 
                {
                    e.NewFollowPlayer();
                    if (e is Zombie)
                    {
                        (e as Zombie).Attack();
                    }
                    if (e is Brute)
                    {
                        (e as Brute).Attack();
                    }
                    if (e is Sniper)
                    {
                        (e as Sniper).Attack();
                        Bullets.AddRange((e as Sniper).bullets);
                    }
                }
            }
            foreach (var item in removing)
            {
                Enemies.Remove(item);
            }
        }

        private void BulletControl(List<Bullet> eBullet) 
        {
            //this.Bullets.ForEach(b => b.Moving());
            Bullets.Clear();

        }

        public void TimeStep()
        {
            Rect playerRect = new Rect(Player.Center.X, Player.Center.Y, Player.Width, Player.Height);
            //Rect zombieRect = new Rect(Zombie.Center.X, Zombie.Center.Y, Zombie.Width, Zombie.Height);
            // Zombie.FollowPlayer(Player, mapArea);
            
            EnemyControl();
            //BulletControl();
            Changed?.Invoke(this, null);
        }
    }
}
