using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Model
{
    public interface IMesurable2D
    {
        double Perimeter { get; }
        double Area { get; }

        // default method
        double Surface { get => Area; }
    }
}
