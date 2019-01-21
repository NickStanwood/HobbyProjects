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

            InitVoronoiField();

            CreateRandomSeeds();

            GrowSeeds();
        }

        private void InitVoronoiField()
        {
            for(int x = 0; x < _ImgSize; x++ )
            {
                for(int y = 0; y < _ImgSize; y++ )
                {
                    VoronoiField[ x, y ] = new CoordInfo();
                }
            }
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

                if (VoronoiField[xCoord, yCoord].IsFreeTile(seed))
                {
                    Tiles.Add(seed);
                    VoronoiField[ xCoord, yCoord ].SetTile( seed );
                }
            }
        }

        public bool GrowSeeds()
        {
            bool doneGrowing = false;
            int growthCount = 1000;
            while(!doneGrowing && growthCount != 0)
            {
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
                            if(VoronoiField[c.X , c.Y].IsFreeTile(tile))
                            {
                                allowedRegion.Add(c);
                                VoronoiField[ c.X, c.Y ].SetTile( tile );
                            }
                        }
                        if(desiredRegion.Count() != 0 && allowedRegion.Count() == 0)
                        {
                            tile.FullyExpanded = true;
                        }
                        tile.ExpandTile(1 , allowedRegion);
                    }
                }
                growthCount--;
            }       
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
