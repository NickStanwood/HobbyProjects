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


        private List<Site> Sites;

        VoronoiDiagram(int imgSize , int numSites)
        {
            Sites = new List<Site>();
        }
    }
}
