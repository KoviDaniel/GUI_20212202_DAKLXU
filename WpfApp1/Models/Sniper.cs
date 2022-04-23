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
        public Sniper(Size mapArea, Player player) : base(mapArea, player)
        {
            Health = 50;
            Stamina = 100; // ??
            Power = 60;
            Speed = new Vector(2, 2);
            Width = 25;
            Height = 25;

            DetectionRange = 500;
            AttackRange = 500;
            StoppingRange = 100 + (player.Width + player.Height) / 2;

            AttackIntensity = 300;
            this.bullets = new List<Bullet>();

            EnemyRect = new Rect(this.Center.X, this.Center.Y, this.Width, this.Height);
        }

        private void Accuracy(ref System.Drawing.Point target) 
        {
            if (tr.Next(1) == 0)
            {
                target.X += tr.Next(0,4);
            }
            else 
            {
                target.X -= tr.Next(0, 4);
            }
            if (tr.Next(1) == 0)
            {
                target.Y += tr.Next(0, 4);
            }
            else
            {
                target.Y -= tr.Next(0, 4);
            }
        }

        public override void Attack()
        {
            if (this.player != null) 
            {
                cooldown++;
                if (Distance <= AttackRange && cooldown >= AttackIntensity) 
                {
                    cooldown = 0;
                    System.Drawing.Point target = player.Center;
                    Accuracy(ref target);
                    Bullet b = new Bullet(this.Center, target);
                    bullets.Add(b);
                }
            }
            bullets.ForEach(b => b.Moving());
            HitDetection();
        }

        private void HitDetection() 
        {
            foreach (var b in bullets)
            {
                if (b.BulletRect.IntersectsWith(player.PlayerRect)) 
                {
                    this.player.GetDamage(this.Power);
                }
            }
        }
    }
}
