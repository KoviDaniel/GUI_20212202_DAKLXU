using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Models
{
    public class Player
    {
        public System.Drawing.Point Center { get; set; } // A jatekos kozeppontja
        public Vector Speed { get; set; }

        public Player(Size mapArea)  // A palya merete
        {           
            Center = new System.Drawing.Point((int)mapArea.Width / 2, (int)mapArea.Height / 2);
            Speed = new Vector(10, 10); // ?? mapArea.Width, mapArea.Height
        }

        public void Move(Size area)
        {
            ////hova kerülne a lépéskor a jatekos
            //System.Drawing.Point newCenter = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y + (int)Speed.Y);
            //if (newCenter.X >= 0 && newCenter.X <= area.Width && newCenter.Y >= 0 && newCenter.Y <= area.Height)
            //{
            //    //pályán belül van az jatekos
            //    Center = newCenter;
            //    //return true;
            //}
            //else
            //{
            //    //épp elhagyta a pályát
            //    Center = Center;
            //}
        }
    }
}
