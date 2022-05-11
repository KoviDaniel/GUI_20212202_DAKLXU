using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoresOfGold.Models
{
    public class Entity
    {
        public double Health { get; set; }
        public double Stamina { get; set; }
        public System.Drawing.Point Center { get; set; }
        public Vector Speed { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public bool IsAttacking { get; set; }
        public bool IsDamaged { get; set; }
    }
}
