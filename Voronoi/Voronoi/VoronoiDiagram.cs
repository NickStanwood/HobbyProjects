using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Voronoi
{
    public class VoronoiDiagram
    {
        public Bitmap ImgDiagram { get; private set; }


        private CoordInfo[,] VoronoiField;
        private List<Tile> Tiles;

        private int _ImgSize;
        private int _NumSeeds;
        private int _MinRadius;

        public VoronoiDiagram(int imgSize , int numSeeds, int minRadius)
        {
            VoronoiField = new CoordInfo[imgSize,imgSize];
            Tiles = new List<Tile>();

            _ImgSize = imgSize;
            _NumSeeds = numSeeds;
            _MinRadius = minRadius;

            CreateRandomSeeds();

            GrowSeeds();
        }

        private void CreateRandomSeeds()
        {
            Tiles = new List<Tile>();
            Random rand = new Random();
            for(int i = 0; i < _NumSeeds; i++)
            {
                int xCoord = rand.Next(0, _ImgSize - 1);
                int yCoord = rand.Next(0, _ImgSize - 1);
                Tile seed = new Tile(xCoord, yCoord , _ImgSize);

                if (VoronoiField[xCoord, yCoord].TrySetTile(seed))
                {
                    Tiles.Add(seed);
                }
            }
        }

        public bool GrowSeeds()
        {
            bool doneGrowing = false;

            //while(!doneGrowing)
            //{
                doneGrowing = true;
                foreach (Tile tile in Tiles)
                {
                    if (!tile.FullyExpanded)
                    {
                        doneGrowing = false;
                        List<Coord> desiredRegion = tile.GetExpansionRegion(1);
                        List<Coord> allowedRegion = new List<Coord>();
                        foreach(Coord c in desiredRegion)
                        {
                            if(VoronoiField[c.X , c.Y].TrySetTile(tile))
                            {
                                allowedRegion.Add(c);
                            }
                        }
                        tile.ExpandTile(allowedRegion);
                    }
                }
            //}       
            return doneGrowing;
        }

        public Bitmap CreateImage()
        {
            Bitmap img = new Bitmap(_ImgSize, _ImgSize);
            for(int x = 0; x < _ImgSize; x++)
            {
                for(int y = 0; y < _ImgSize; y++)
                {
                    img.SetPixel(x, y, VoronoiField[x, y].GetColor());
                }
            }
            return img;
        }
    }
}
