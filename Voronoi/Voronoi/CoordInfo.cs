using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Voronoi
{
    public class CoordInfo
    {       
        private Tile _FirstTile;
        private Tile _SecondTile;

        public bool Full { get; private set; }

        public CoordInfo()
        {
            _FirstTile = null;
            _SecondTile = null;
            Full = false;
        }

        public bool IsFreeTile(Tile tile)
        {
            if(_FirstTile == null || _SecondTile == null)
            {
                return true;
            }
            return false;
        }

        public void SetTile(Tile tile)
        {
            if(_FirstTile == null)
            {
                _FirstTile = tile;
            }
            else if(_SecondTile == null)
            {
                _SecondTile = tile;
            }
        }

        public Color GetColor()
        {
            if(_FirstTile == null)
            {
                return Color.White;
            }
            else if(_SecondTile == null)
            {
                return Color.Navy;
            }
            else if(_FirstTile == _SecondTile)
            {
                return Color.AliceBlue;
            }
            else 
            {
                return Color.Gold;
            }
        }
    }
}
