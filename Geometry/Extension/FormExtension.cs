using Geometry.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Extension
{
    public static class FormExtension
    {
        public static IEnumerable<Point> Where(this Polygon polygon, Func<Point, bool> predicate)
        {
            return polygon.Summits.Where(predicate);
        } 
    }
}
