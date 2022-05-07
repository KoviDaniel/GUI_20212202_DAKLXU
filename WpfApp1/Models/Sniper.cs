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
            Width = 30;
            Height = 30;

            DetectionRange = 500;
            AttackRange = 500;
            StoppingRange = 100 + (player.Width + player.Height) / 2;

            AttackIntensity = 300;
            this.bullets = new List<Bullet>();

            EnemyRect = new Rect(this.Center.X, this.Center.Y, this.Width, this.Height);
        }

        /* private void Accuracy(ref System.Drawing.Point target) 
         {
             if (tr.Next(1) == 0)
             {
                 target.X += tr.Next(0,2);
             }
             else 
             {
                 target.X -= tr.Next(0, 2);
             }
             if (tr.Next(1) == 0)
             {
                 target.Y += tr.Next(0, 2);
             }
             else
             {
                 target.Y -= tr.Next(0, 2);
             }
         }*/
        

        public override void Attack()
        {
            if (this.player != null /* && Health > 0*/) 
            {
                cooldown++;
                if (Distance <= AttackRange && cooldown >= AttackIntensity) 
                {
                    cooldown = 0;
                    System.Drawing.Point target = player.Center;
                    //Accuracy(ref target);
                    Bullet b = new Bullet(this.Center, target);
                    bullets.Add(b);
                }
            }
            /*bullets.ForEach(b => b.Moving());
            HitDetection();*/
            BulletLife();
        }

        private void HitDetection() 
        {
            foreach (var b in bullets)
            {
                if (b.BulletRect.IntersectsWith(player.PlayerRect)) 
                {
                    this.player.GetDamage(this.Power);
                    //this.bullets.Remove(b);
                    b.Alive = false;
                }
            }
            /*int idx = -1;
            for (int i = 0; i < bullets.Count; i++)
            {
                if (idx != -1) bullets.RemoveAt(idx);
                idx = -1;
                if (bullets[i].BulletRect.IntersectsWith(player.PlayerRect))
                {
                    this.player.GetDamage(this.Power);
                    //this.bullets.RemoveAt(i);
                    idx = i;

                }
            }*/
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
                    //HitDetection
                    if (b.BulletRect.IntersectsWith(player.PlayerRect))
                    {
                        this.player.GetDamage(this.Power);
                        //this.bullets.Remove(b);
                        b.Alive = false;
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
