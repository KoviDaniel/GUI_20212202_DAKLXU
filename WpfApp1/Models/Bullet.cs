﻿using System;
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

        private System.Drawing.Point center;

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
            this.center = start;
            Speed = new Vector(10, 10);
            Direction = DirectionVector(start, target);
        }

        public void Moving() 
        {
            this.center = new System.Drawing.Point(center.X + (int)(Direction.X * this.Speed.X), center.Y + (int)(Direction.Y * this.Speed.Y));
        }
    }
}
