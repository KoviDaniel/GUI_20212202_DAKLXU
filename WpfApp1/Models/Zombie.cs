﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoresOfGold.Models
{
    public class Zombie : Enemy
    {       
        public Zombie(Size mapArea, Player player) : base(mapArea,player)
        {
            Health = 100;
            Stamina = 100; // ??
            Power = 10;

            Speed = new Vector(2.9, 2.9);
            Width = 55;
            Height = 55;

            Center = new System.Drawing.Point(r.Next(Width / 2, (int)mapArea.Width - Width / 2), r.Next((int)player.UpperBound + Height / 2, (int)player.LowerBound - Height / 2));

            DetectionRange = 230;
            AttackRange = 160;
            StoppingRange = 15+(player.Width+player.Height)/2;

            AttackIntensity = 50;
        }

        public override void Attack() 
        {
            if (this.player != null && this.player.Health > 0 && Health >0)
            {               
                cooldown++;
                // if (cooldown == AttackIntensity - 20) this.IsAttacking = true;
                if (Distance <= AttackRange) this.IsAttacking = true;
                else this.IsAttacking = false;
                if (Distance <= AttackRange && cooldown >= AttackIntensity)
                {
                    this.IsDamaged = false;
                    this.IsAttacking = true;
                    this.player.GetDamage(this.Power);
                    cooldown = 0;
                    this.IsAttacking = false;
                }
            }
        }
    }
}
