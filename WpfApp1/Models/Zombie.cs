using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoresOfGold.Models
{
    public class Zombie : Enemy
    {
        //static Random r = new Random();

        public Zombie(Size mapArea)
        {
            Health = 50;
            Stamina = 100; // ??
            Power = 10;

            Speed = new Vector(1, 1);
            Center = new System.Drawing.Point(r.Next(0, (int)mapArea.Width+1) - 25, r.Next(0, (int)mapArea.Height + 1) - 25);
            Width = 60;
            Height = 60;
            Center = new System.Drawing.Point(r.Next(Width / 2, (int)mapArea.Width - Width / 2), r.Next((int)player.UpperBound + Height / 2, (int)player.LowerBound - Height / 2));
        }
        public Zombie(Size mapArea, Player player) : base(mapArea,player)
        {
            Health = 100;
            Stamina = 100; // ??
            Power = 10;

            Speed = new Vector(2.9, 2.9);
            //Center = new System.Drawing.Point(r.Next(0, (int)mapArea.Width + 1) - 25, r.Next(0, (int)mapArea.Height + 1) - 25);
            Width = 50;
            Height = 50;

            DetectionRange = 300;
            AttackRange = 290;
            StoppingRange = 10+(player.Width+player.Height)/2;

            AttackIntensity = 50;
           // EnemyRect = new Rect(this.Center.X, this.Center.Y, this.Width, this.Height);
        }

        public override void Attack() 
        {
            if (this.player != null && this.player.Health > 0 && Health >0)
            {
                cooldown++;
                if (Distance <= AttackRange && cooldown >= AttackIntensity)
                {
                    this.player.GetDamage(this.Power);
                    cooldown = 0;
                }
            }
        }
    }
}
