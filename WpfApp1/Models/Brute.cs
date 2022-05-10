using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoresOfGold.Models
{
    public class Brute : Enemy
    {
        public Brute(Size mapArea, Player player) : base(mapArea,player)
        {
            Health = 200;
            Stamina = 0; //TODO:? REMOVE
            Power = 50; //Damage

            Speed = new Vector(1.5, 1.5);
            Width = 75;
            Height = 75;
            Center = new System.Drawing.Point(r.Next(Width/2, (int)mapArea.Width -Width/2), r.Next((int)player.UpperBound+Height/2, (int)player.LowerBound-Height/2));

            DetectionRange = 300;
            AttackRange = 250;
            StoppingRange = 19 + (player.Width + player.Height) / 2;

            AttackIntensity = 150;
        }
        public override void Attack()
        {
            if (this.player != null && this.player.Health>0 && Health > 0)
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
