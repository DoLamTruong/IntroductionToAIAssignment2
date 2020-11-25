using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPGA
{
    public class City
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static int Distance(City c1, City c2)
        {
            return (c1.X - c2.X) * (c1.X - c2.X) + (c1.Y - c2.Y) * (c1.Y - c2.Y);
        }
    }
}
