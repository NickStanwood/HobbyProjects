using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Voronoi
{
    public class Tile
    {
        public int X;
        public int Y;

        public int Radius { get; private set; }
        private int _MaxCoord;  //this is for both the Y and X axis

        private List<Coord> _CurRegion;

        public bool FullyExpanded = false;

        public Tile(int xInit, int yInit , int maxCoord)
        {
            X = xInit;
            Y = yInit;

            Radius = 0;
            _MaxCoord = maxCoord;

            _CurRegion = new List<Coord>();
            _CurRegion.Add(new Coord(X, Y));
        }

        public List<Coord> GetExpansionRegion(int growthSize)
        {
            List<Coord> Coords = new List<Coord>();

            int newRadius = Radius + growthSize;

            for(int x = 0; x < newRadius; x++)
            {
                for(int y = 0; y < newRadius; y++)
                {
                    int mag = x*x + y*y;
                    if(mag <= newRadius*newRadius && mag > (Radius - growthSize)*(Radius - growthSize))
                    {
                        // modulus max coordinate so the voronoi loops around to the other side of the image
                        Coord coord1 = new Coord((X + x) % _MaxCoord , (Y + y) % _MaxCoord);                            // sector 1 coord
                        Coord coord2 = new Coord((X - x + _MaxCoord) % _MaxCoord, (Y + y) % _MaxCoord);                 // sector 2 coord
                        Coord coord3 = new Coord((X - x + _MaxCoord) % _MaxCoord, (Y - y + _MaxCoord) % _MaxCoord);     // sector 3 coord
                        Coord coord4 = new Coord((X + x) % _MaxCoord, (Y - y + _MaxCoord) % _MaxCoord);                 // sector 4 coord
                        //if (!_CurRegion.Contains(coord1))
                        //{   //if 1 coordinate isnt in the region, they all arent
                            Coords.Add(coord1);
                            Coords.Add(coord2);
                            Coords.Add(coord3);
                            Coords.Add(coord4);
                        //}
                    }
                }
            }

            return Coords;
        }

        public void ExpandTile(int growthSize, List<Coord> region)
        {
            foreach(Coord coord in region)
            {
                _CurRegion.Add(coord);
            }
            Radius += growthSize;
        }
    }
}
