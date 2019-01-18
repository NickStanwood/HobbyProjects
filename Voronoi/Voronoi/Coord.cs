using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voronoi
{
    public class Coord
    {
        public int X;
        public int Y;

        public Coord(int x , int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Coord c1 , Coord c2)
        {
            return (c1.X == c2.X) && (c1.Y == c2.Y);
        }

        public static bool operator !=(Coord c1 , Coord c2)
        {
            return (c1.X != c2.X) || (c1.Y != c2.Y);
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Coord p = (Coord)obj;
                return (X == p.X) && (Y == p.Y);
            }
        }
    }
}
