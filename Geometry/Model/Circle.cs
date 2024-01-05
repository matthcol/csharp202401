using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Model
{
    public class Circle : Form, IMesurable2D
    {
        public Point Center {  get; set; }
        public double Radius { get; set; }

        public double Diameter => 2 * Radius;

        // short syntax
        public double Perimeter => 2.0 * Math.PI * Radius;

        // expanded syntax
        public double Area
        {
            get => Math.PI * Radius * Radius;
        }

        public override void Translate(double deltaX, double deltaY)
        {
            Center.Translate(deltaX, deltaY);
        }
    }
}
