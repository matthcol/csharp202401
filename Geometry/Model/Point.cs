using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Model
{
    public class Point: Form, IAdditionOperators<Point, double, Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Distance(Point other)
        {
            return Double.Hypot(X - other.X, Y - other.Y);
        }

        public override void Translate(double deltaX, double deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        public override string ToString() => $"{Name}({X}; {Y})";

        public static Point operator +(Point left, double right)
        {
            return new()
            {
                Name = left.Name,
                X = left.X + right,
                Y = left.Y + right
            };
        }
    }
}
