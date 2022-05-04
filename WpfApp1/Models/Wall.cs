using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ShoresOfGold.Models
{
    public class Wall : GameObject
    {
        protected Point start;
        protected Point end;

        public Wall(Point start, Point end, int thickness)
        {
            this.start = start;
            this.end = end;
            if (start.X == end.X) 
                this.end.X += thickness;
            else 
                this.end.Y += thickness;
        }

        public override Geometry Area
        {
            get { return new RectangleGeometry(new Rect(start, end)); }
        }
    }
}
