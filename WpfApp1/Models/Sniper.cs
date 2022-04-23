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
        public Sniper(Size mapArea, Player player) : base(mapArea, player)
        {
            Health = 50;
            Stamina = 100; // ??
            Power = 60;
            Speed = new Vector(2, 2);
        }
    }
}
