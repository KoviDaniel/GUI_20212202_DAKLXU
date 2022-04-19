using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Logic;

namespace WpfApp1.Models
{
    public class Player
    {
        private double speedX, speedY;

        public double X { get; set; }
        public double Y { get; set; }
        public int PlayerWidth { get; set; }
        public int PlayerHeight { get; set; }

        //public System.Drawing.Point Center { get; set; } // A jatekos kozeppontja
        //public Vector Speed { get; set; }

        public Player(double x, double y, int playerWidth, int playerHeight)  // Size mapArea A palya merete
        {           
            //Center = new System.Drawing.Point((int)mapArea.Width / 2, (int)mapArea.Height / 2);
            //Speed = new Vector(10, 10); // ?? mapArea.Width, mapArea.Height
            
            this.X = x;
            this.Y = y;
            this.PlayerWidth = playerWidth;
            this.PlayerHeight = playerHeight;
            speedX = 5;
            speedY = 5;
        }

        public void Move(Controls control)
        {
            //System.Drawing.Point newCenter = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y + (int)Speed.Y);
            //if (newCenter.X >= 0 && newCenter.X <= mapArea.Width && newCenter.Y >= 0 && newCenter.Y <= mapArea.Height)

            if (control == Controls.Up)
            {
                Y = Y - speedY;             
            }
            else if (control == Controls.Down)
            {
                Y = Y + speedY;               
            }
            else if (control == Controls.Left)
            {
                X = X - speedX;
            }
            else if (control == Controls.Right)
            {
                X = X + speedX;
            }

            //if (control == Controls.Up)
            //{
            //    Center = new System.Drawing.Point(Center.X, Center.Y + (int)Speed.Y);
            //}
            //else if (control == Controls.Down)
            //{
            //    Center = new System.Drawing.Point(Center.X, Center.Y - (int)Speed.Y);
            //}
            //else if (control == Controls.Left)
            //{
            //    Center = new System.Drawing.Point(Center.X - (int)Speed.X, Center.Y);
            //}
            //else if (control == Controls.Right)
            //{
            //    Center = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y);
            //}
        }
    }
}
