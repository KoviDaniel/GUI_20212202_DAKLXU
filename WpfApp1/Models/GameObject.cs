using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShoresOfGold.Models
{
    public abstract class GameObject
    {
        public abstract Geometry Area { get; }
        public bool IsCollision(GameObject other)
        {
            return Geometry.Combine(this.Area, other.Area, GeometryCombineMode.Intersect, null).GetArea() > 0;
        }
    }
}
