using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoresOfGold.Models
{
    public class Sniper : Enemy
    {
        Random tr = new Random();
        public List<Bullet> bullets;
        Size mapArea;
        public Sniper(Size mapArea, Player player) : base(mapArea, player)
        {
            this.mapArea = mapArea;
            Health = 50;
            Stamina = 100; // ??
            Power = 60;
            Speed = new Vector(2, 2);
            Width = 50;
            Height = 50;

            Center = new System.Drawing.Point(r.Next(Width / 2, (int)mapArea.Width - Width / 2), r.Next((int)player.UpperBound + Height / 2, (int)player.LowerBound - Height / 2));

            DetectionRange = 500;
            AttackRange = 500;
            StoppingRange = 100 + (player.Width + player.Height) / 2;

            AttackIntensity = 300;
            this.bullets = new List<Bullet>();

          
        }

        
        

        public override void Attack()
        {
            if (this.player != null && this.player.Health > 0 && Health > 0) 
            {
                cooldown++;
                if (Distance <= AttackRange && cooldown >= AttackIntensity) 
                {
                    cooldown = 0;
                    System.Drawing.Point target = player.Center;

                    System.Windows.Point wTarget = new System.Windows.Point();
                    wTarget.X = player.Center.X;
                    wTarget.Y = player.Center.Y;

                    Bullet b = new Bullet(this.Center, wTarget);
                    bullets.Add(b);
                }
            }

            BulletLife();
        }

        private void HitDetection() 
        {
            foreach (var b in bullets)
            {
                if (b.BulletRect.IntersectsWith(player.PlayerRect)) 
                {
                    this.player.GetDamage(this.Power);

                    b.Alive = false;
                }
            }
           
        }

        private void BulletLife() 
        {
            List<Bullet> removing = new List<Bullet>();
            foreach (var b in bullets)
            {
                if (b.Alive = false || b.Center.X <= 0 || b.Center.X >= mapArea.Width
                    || b.Center.Y <= 0 || b.Center.Y >= mapArea.Height)
                {
                    removing.Add(b);
                }
                else 
                {
                    b.Moving(); // moving

                    if (b.BulletRect.IntersectsWith(player.PlayerRect))
                    {
                        this.player.GetDamage(this.Power);

                        b.Alive = false;
                        removing.Add(b);
                    }
                }
            }
            foreach (var r in removing)
            {
                bullets.Remove(r);
            }
        }
    }
}
