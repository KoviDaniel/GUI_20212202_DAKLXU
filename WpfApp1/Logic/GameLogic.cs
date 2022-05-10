using ShoresOfGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ShoresOfGold.Logic
{
    public enum Controls
    {
        Up, Down, Left, Right, Open, Melee, Range
    }

    public class GameLogic : IGameModel
    {
        private const int topWallThickness = 240; 
        private const int bottomWallThickness = 120; 

        Random r = new Random();
        private Size mapArea;

        public event EventHandler Changed; //public event EventHandler GameOver;

        public Player Player { get; set; }
        public Wall TopWall { get; set; }
        public Wall BottomWall { get; set; }

        public Boss Boss { get; set; }
        public Zombie Zombie { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Bullet> Bullets { get; set; }
        
        public List<Chest> Chests { get; set; }

        public int MapNumber { get; set; }

        public void SetupSizes(Size mapArea)
        {
            this.mapArea = mapArea;

            //Player = new Player(mapArea.Width / 2, mapArea.Height / 2);
            Player = new Player(mapArea, TopWall.Area.Bounds.Height, BottomWall.Area.Bounds.Y);
            Boss = new Boss(mapArea, Player);
            Zombie= new Zombie(mapArea, this.Player);
            this.Enemies = new List<Enemy>();
            this.Bullets = new List<Bullet>();
            this.Chests = new List<Chest>();
            for (int i = 0; i < r.Next(3,7); i++)
            {
                GenerateEnemies();
            }
            for (int i = 0; i < r.Next(1, 5); i++)
            {
                this.Chests.Add(new Chest(mapArea, TopWall.Area.Bounds.Height, BottomWall.Area.Bounds.Y));
            }
        }

        public void LoadNexMap() 
        {
            this.Enemies = new List<Enemy>();
            this.Bullets = new List<Bullet>();
            this.Chests = new List<Chest>();
            for (int i = 0; i < r.Next(3, 7); i++)
            {
                GenerateEnemies();
            }
            for (int i = 0; i < r.Next(1, 5); i++)
            {
                this.Chests.Add(new Chest(mapArea, TopWall.Area.Bounds.Height, BottomWall.Area.Bounds.Y));
            }
        }

        public void GenerateEnemies() 
        {
            int num = r.Next(0, 3);
            //int num = 0;
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

        public GameLogic(Size mapArea)
        {
            TopWall = new Wall(new Point(0, 0), new Point(mapArea.Width, 0), topWallThickness);
            BottomWall = new Wall(new Point(0, mapArea.Height - bottomWallThickness),
                new Point(mapArea.Width, mapArea.Height - bottomWallThickness), bottomWallThickness);
            MapNumber = 1;
        }

        public void PlayerAttackControl(Controls control, Point cursor) 
        {
            if (control == Controls.Melee) 
                Player.MeleeAttack(Enemies, Boss);
            if (control == Controls.Range) 
                Player.RangeAttack(Enemies, cursor);
        }

        public void PlayerControl(Controls control)
        {
            if(control != Controls.Open && control != Controls.Melee && control != Controls.Range) 
                Player.Move(control);
            if (control == Controls.Open) 
                Player.Interact(control, Chests);
        }

        public void EnemyControl()
        {
            // Zombie.FollowPlayer(this.Player, this.mapArea);
            /*Zombie.NewFollowPlayer();
            Zombie.Attack();*/

            Bullets.Clear();
            //this.Player.BulletLife(Enemies);
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

        public void BossControl() 
        {
            if (this.Enemies.Count == 0 && this.MapNumber == 4)
            {
                this.Boss.AttackHandler();
            }
        }

        public void TimeStep()
        {
            //Rect playerRect = new Rect(Player.X, Player.Y, Player.PlayerWidth, Player.PlayerHeight);
            if (this.Enemies.Count == 0 && Boss.Health<=0) { 
                this.Bullets.Clear();
                this.Player.Bullets.Clear();
            }
            // Zombie.FollowPlayer(Player, mapArea);
            this.Player.NewBulletLife(Enemies, Boss);
            this.Player.Restoration();
            EnemyControl();
            BossControl();
            //BulletControl();
            Changed?.Invoke(this, null);
        }
    }
}
