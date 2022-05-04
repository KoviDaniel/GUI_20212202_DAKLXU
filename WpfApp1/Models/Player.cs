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
            Width = 100;
            Height = 100;
        }

        public void Move(Controls control)
        {          
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
