using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swarm.Math
{
    public struct Vector2D
    {
        public double x;
        public double y;
        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        
        public double Length
        {
            get { return System.Math.Sqrt(x * x + y * y); }
        }
        public static Vector2D operator +(Vector2D l, Vector2D r)
        {
            return new Vector2D(l.x + r.x, l.y + r.y);
        }
        public static Vector2D operator *(double alpha, Vector2D r)
        {
            return new Vector2D(alpha * r.x, alpha * r.y);
        }


    }
}
