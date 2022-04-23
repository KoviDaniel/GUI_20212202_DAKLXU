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
        public Sniper(Size mapArea, Player player) : base(mapArea, player)
        {
            Health = 50;
            Stamina = 100; // ??
            Power = 60;
            Speed = new Vector(2, 2);
            Width = 50;
            Height = 50;

            DetectionRange = 500;
            AttackRange = 500;
            StoppingRange = 100 + (player.Width + player.Height) / 2;

            AttackIntensity = 300;
        }

        private void Accuracy(ref Point target) 
        {
            if (tr.Next(1) == 0)
            {
                target.X += tr.NextDouble();
            }
            else 
            {
                target.X -= tr.NextDouble();
            }
            if (tr.Next(1) == 0)
            {
                target.Y += tr.NextDouble();
            }
            else
            {
                target.Y -= tr.NextDouble();
            }
        }

        public override void Attack()
        {
            if (this.player != null) 
            {
                cooldown++;
                if (Distance <= AttackRange && cooldown >= AttackIntensity) 
                {
                    
                }
            }
        }
    }
}
