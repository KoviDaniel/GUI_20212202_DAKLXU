using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Models
{
    public class Entity
    {
        public double Health { get; set; }
        public double Stamina { get; set; }
        public System.Drawing.Point Center { get; set; }
        public Vector Speed { get; set; }
        public int EntityWidth { get; set; }
        public int EntityHeight { get; set; }
    }
}
