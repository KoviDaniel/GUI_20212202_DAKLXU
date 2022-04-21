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
        static Random r = new Random();

        public Zombie(Size mapArea)
        {
            Health = 50;
            Stamina = 100; // ??
            Power = 10;

            Speed = new Vector(1, 1);
            Center = new System.Drawing.Point(r.Next(0, (int)mapArea.Width+1) - 25, r.Next(0, (int)mapArea.Height + 1) - 25);
            Width = 50;
            Height = 50;
        }
        public Zombie(Size mapArea, Player player) : base(player)
        {
            Health = 50;
            Stamina = 100; // ??
            Power = 10;

            Speed = new Vector(2, 2);
            Center = new System.Drawing.Point(r.Next(0, (int)mapArea.Width + 1) - 25, r.Next(0, (int)mapArea.Height + 1) - 25);
            Width = 50;
            Height = 50;

            DetectionRange = 300;
            AttackRange = 250;
            StoppingRange = 10+(player.Width+player.Height)/2;
        }
    }
}
