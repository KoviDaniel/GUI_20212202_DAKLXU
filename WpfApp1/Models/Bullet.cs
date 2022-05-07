using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoresOfGold.Models
{
    public class Bullet
    {
        public Vector Speed { get;}
        public Vector Direction { get; }

        public System.Drawing.Point Center { get; set; }
        public Rect BulletRect { get { return new Rect(this.Center.X, this.Center.Y, 3, 3); } }

        public bool Alive { get; set; }

        private Vector DirectionVector(System.Drawing.Point start, System.Drawing.Point target) 
        {
            Vector v = new Vector();
            v.X = target.X - start.X;
            v.Y = target.Y - start.Y;
            double l = v.Length;
            v.X /= l;
            v.Y /= l;
            return v;
        }

        public Bullet(System.Drawing.Point start, System.Drawing.Point target)
        {
            this.Center = start;
            Speed = new Vector(3, 3);
            Direction = DirectionVector(start, target);
            //BulletRect = new Rect(this.Center.X, this.Center.Y, 3, 3);
            Alive = true;
        }

        public void Moving() 
        {
            this.Center = new System.Drawing.Point(Center.X + (int)(Direction.X * this.Speed.X), Center.Y + (int)(Direction.Y * this.Speed.Y));
        }
        //public void HitDetection() { }
    }
}
