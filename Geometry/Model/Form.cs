using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Model
{
    public abstract class Form
    {
        public string Name { get; set; } = "?";

        public abstract void Translate(double deltaX, double deltaY);
    }
}
