using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ShoresOfGold.Logic;

namespace ShoresOfGold.Models
{
    public class Player : Entity
    {
        public int Gold { get; set; }
        public int MeleeDamage { get; set; }
        public int RangeDamage { get; set; }
        public List<Bullet> Bullets;
        Size mapArea;
        public Player(Size mapArea)
        {
            this.mapArea = mapArea;
            Health = 100;
            Stamina = 0;
            Gold = 0;
            Width = 70;
            Height = 86;
            Center = new System.Drawing.Point((int)mapArea.Width / 2, (int)mapArea.Height / 2);
            Speed = new Vector(3, 3);
            MeleeDamage = 40;
            RangeDamage = 30;
            Bullets = new List<Bullet>();
            //PlayerRect = new Rect(this.Center.X, this.Center.Y, this.Width, this.Height);
        }
        public Rect PlayerRect { get { return new Rect(this.Center.X-this.Width/2, this.Center.Y-this.Height/2, this.Width, this.Height); } }

        public void Move(Controls control)
        {
            //System.Drawing.Point newCenter = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y + (int)Speed.Y);
            //if (newCenter.X >= 0 && newCenter.X <= mapArea.Width && newCenter.Y >= 0 && newCenter.Y <= mapArea.Height)
            
            if (control == Controls.Up)
            {
                Center = new System.Drawing.Point(Center.X, Center.Y - (int)Speed.Y);
            }
            else if (control == Controls.Down)
            {
                Center = new System.Drawing.Point(Center.X, Center.Y + (int)Speed.Y);
            }
            else if (control == Controls.Left)
            {
                Center = new System.Drawing.Point(Center.X - (int)Speed.X, Center.Y);
            }
            else if (control == Controls.Right)
            {
                Center = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y);
            }
            
        }
        public void Interact(Controls control ,List<Chest> chests) 
        {
            foreach (var c in chests)
            {
                if (DistanceCalculator(c.Center) <= 80) 
                {
                    c.Open(this);
                }
            }
        }
        public void MeleeAttack(List<Enemy> enemies) 
        {
            foreach (var e in enemies)
            {
                if (DistanceCalculator(e.Center) <= 280 && Health > 0) 
                {
                    e.GetDamage(this.MeleeDamage);
                }
            }
        }

        public void RangeAttack(List<Enemy> enemies, Point target)
        {
            if (this.Health>0) 
            {
                Shoot(target);
            }
            BulletLife(enemies);
        }

        private void Shoot(Point target) 
        {
            System.Drawing.Point dTarget = new System.Drawing.Point();
            dTarget.X = (int)target.X;
            dTarget.Y = (int)target.Y;
            Bullets.Add(new Bullet(this.Center, dTarget));
        }

        public void BulletLife(List<Enemy> enemies) 
        {
            List<Bullet> removing = new List<Bullet>();
            foreach (var e in enemies)
            {
                foreach (var b in Bullets)
                {
                    if (b.Alive = false || b.Center.X <= 0 || b.Center.X >= mapArea.Width
                    || b.Center.Y <= 0 || b.Center.Y >= mapArea.Height)
                    {
                        removing.Add(b);
                    }
                    else
                    {
                        b.Moving(); // moving
                                    //HitDetection
                        if (b.BulletRect.IntersectsWith(e.EnemyRect))
                        {
                            e.GetDamage(this.RangeDamage);
                            //this.bullets.Remove(b);
                            b.Alive = false;
                            removing.Add(b);
                        }
                    }
                }
                foreach (var r in removing)
                {
                    Bullets.Remove(r);
                }
            }
        }



        private double DistanceCalculator(System.Drawing.Point center) 
        {
            //return Math.Sqrt(Math.Pow((player.Center.X-this.Center.X), 2)+Math.Pow((player.Center.Y - this.Center.Y), 2));
            return Math.Sqrt(Math.Pow((center.X-this.Center.X),2)+Math.Pow((center.Y-this.Center.Y),2));
        }

        public void Heal() 
        {
            
        }

        public void GetDamage(double damage) 
        {
            this.Health -= damage;
            if (this.Health <= 0) { /*the player dies*/}
        }
    }
}
