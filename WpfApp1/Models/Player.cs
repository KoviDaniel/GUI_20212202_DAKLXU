using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Logic;

namespace WpfApp1.Models
{
    public class Player : Entity
    {
        public int Gold { get; set; }

        public Player(Size mapArea)  // A palya merete double x, double y 
        {
            Health = 100;
            Stamina = 150;
            Gold = 0;

            Center = new System.Drawing.Point((int)mapArea.Width / 2, (int)mapArea.Height / 2);
            Speed = new Vector(3, 3);
            EntityWidth = 25;
            EntityHeight = 25;
        }

        public void Move(Controls control)
        {
            //System.Drawing.Point newCenter = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y + (int)Speed.Y);
            //if (newCenter.X >= 0 && newCenter.X <= mapArea.Width && newCenter.Y >= 0 && newCenter.Y <= mapArea.Height)

            if (control == Controls.Up)
            {
                Center = new System.Drawing.Point(Center.X, Center.Y - (int)Speed.Y);
            }
            else if (control == Controls.Down)
            {
                Center = new System.Drawing.Point(Center.X, Center.Y + (int)Speed.Y);
            }
            else if (control == Controls.Left)
            {
                Center = new System.Drawing.Point(Center.X - (int)Speed.X, Center.Y);
            }
            else if (control == Controls.Right)
            {
                Center = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y);
            }
        }
    }
}
