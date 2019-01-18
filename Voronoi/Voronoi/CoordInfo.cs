﻿using System;
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

        public bool TrySetTile(Tile tile)
        {
            if(_FirstTile == null)
            {
                _FirstTile = tile;
                return true;
            }
            if(_SecondTile == null)
            {
                _SecondTile = tile;
                return true;
            }
            return false;
        }

        public Color GetColor()
        {
            if(_FirstTile == null)
            {
                return Color.Transparent;
            }
            else if(_SecondTile == null)
            {
                return Color.Navy;
            }
            else
            {
                return Color.Gold;
            }
        }
    }
}
