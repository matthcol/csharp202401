using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Model
{
    public class Polygon : Form, IMesurable2D
    {
        public Polygon(string name, IList<Point> summits)
        {
            Name = name;
            Summits = summits;
        }


        private IList<Point> _summits;
        public IList<Point> Summits {
            get => _summits;
            set {
                if ((value == null) || value.Count < 3) {
                    throw new ArgumentException("A Polygon needs at least 3 summits");
                }
                _summits = value;
            }
        }

        public Point this[int i]
        {
            get => Summits[i];
            set => Summits[i] = value;
        }

        public double Perimeter { get {
                double res = 0.0;
                for (int i = 0; i < Summits.Count; i++)
                {
                    res += Summits[i].Distance(Summits[(i + 1) % Summits.Count]);
                }
                return res;
            }
        }

        // TODO
        public double Area => 1.0;

        public override void Translate(double deltaX, double deltaY)
        {
            foreach (Point summit in Summits)
            {
                summit.Translate(deltaX, deltaY);   
            }
        }
    }
}
