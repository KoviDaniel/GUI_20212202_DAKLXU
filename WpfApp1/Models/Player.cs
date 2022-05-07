using ShoresOfGold.Models;
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

        public double UpperBound { get; set; }
        public double LowerBound { get; set; }
        public double LeftBound { get; set; }
        public double RightBound { get; set; }

        public Player(Size mapArea, double upperBound, double lowerBound)
        {
            Health = 100;
            Stamina = 150;
            Gold = 0;

            Center = new System.Drawing.Point((int)mapArea.Width / 2, (int)mapArea.Height / 2);
            Speed = new Vector(3, 3);
            Width = 100;
            Height = 100;

            UpperBound = upperBound;
            LowerBound = lowerBound;
            LeftBound = 0;
            RightBound = mapArea.Width;
        }

        public void Move(Controls control)
        {          
            if (control == Controls.Up && Center.Y + Height > UpperBound)
            {
                Center = new System.Drawing.Point(Center.X, Center.Y - (int)Speed.Y);
            }
            else if (control == Controls.Down && Center.Y + Height < LowerBound)
            {
                Center = new System.Drawing.Point(Center.X, Center.Y + (int)Speed.Y);
            }
            else if (control == Controls.Left && Center.X > LeftBound)
            {
                Center = new System.Drawing.Point(Center.X - (int)Speed.X, Center.Y);
            }
            else if (control == Controls.Right && Center.X + Width < RightBound)
            {
                Center = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y);
            }
        }
    }
}
