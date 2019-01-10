using System;
using System.Drawing;
using System.Numerics;
using System.Collections.Generic;
using AccidentalNoise;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MapGenerator
{
    public class MapDesigner
    {
        int Seed;
        
        #region Adjustable Map Variables

        int Width;
        int Height;
        public string Resolution { get; private set; } = "";

        HeightMapping HMapping = new HeightMapping();
        HeatMapping TMapping = new HeatMapping();
        MoistureMapping MMapping = new MoistureMapping();

        int RiverCount = 40;
        float MinRiverHeight = 0.6f;
        int MaxRiverAttempts = 1000;
        int MinRiverTurns = 18;
        int MinRiverLength = 20;
        int MaxRiverIntersections = 0;

        private int DragOriginX;
        private int DragOriginY;
        #endregion

        #region Map Private Propertires
        bool Initialized = false;
        // private variables
        ImplicitFractal HeightMapFractal;
        ImplicitCombiner HeatMapFractal;
        ImplicitFractal MoistureMapFractal;

        MapData HeightData;
        MapData HeatData;
        MapData MoistureData;

        MapData InitHeightData;
        MapData InitHeatData;
        MapData InitMoistureData;

        Tile[,] Tiles;

        List<TileGroup> Waters = new List<TileGroup>();
        List<TileGroup> Lands = new List<TileGroup>();

        List<River> Rivers = new List<River>();
        List<RiverGroup> RiverGroups = new List<RiverGroup>();

        protected BiomeType[,] BiomeTable = new BiomeType[6, 6] {   
		  //COLDEST        //COLDER              //COLD                  //HOT                          //HOTTER                       //HOTTEST
		{ BiomeType.Ice , BiomeType.Tundra , BiomeType.Grassland   , BiomeType.Desert             , BiomeType.Desert             , BiomeType.Desert },              //DRYEST
		{ BiomeType.Ice , BiomeType.Tundra , BiomeType.Grassland   , BiomeType.Desert             , BiomeType.Desert             , BiomeType.Desert },              //DRYER
		{ BiomeType.Ice , BiomeType.Tundra , BiomeType.Woodland    , BiomeType.Woodland           , BiomeType.Savanna            , BiomeType.Savanna },             //DRY
		{ BiomeType.Ice , BiomeType.Tundra , BiomeType.BorealForest, BiomeType.Woodland           , BiomeType.Savanna            , BiomeType.Savanna },             //WET
		{ BiomeType.Ice , BiomeType.Tundra , BiomeType.BorealForest, BiomeType.SeasonalForest     , BiomeType.TropicalRainforest , BiomeType.TropicalRainforest },  //WETTER
		{ BiomeType.Ice , BiomeType.Tundra , BiomeType.BorealForest, BiomeType.TemperateRainforest, BiomeType.TropicalRainforest , BiomeType.TropicalRainforest }   //WETTEST
	};

        bool isDragging;

        int DrawOffsetX;
        int DrawOffsetY;
        double ZoomPercent;

        #endregion

        #region output images
        // The map output images
        private object ImageLock = new object();

        private Bitmap _HeightMap_Movable;
        private Bitmap _HeightMap_Fixed;
        private Bitmap _HeightMap;
        public Bitmap HeightMap
        {
            get
            {
                lock(ImageLock)
                {
                    return (Bitmap)_HeightMap.Clone();
                }
            }
            private set
            {
                lock (ImageLock)
                {
                    _HeightMap = value;
                }
            }
        }

        private Bitmap _HeatMap_Movable;
        private Bitmap _HeatMap_Fixed;
        private Bitmap _HeatMap;
        public Bitmap HeatMap
        {
            get
            {
                lock (ImageLock)
                {
                    return (Bitmap)_HeatMap.Clone();
                }
            }
            private set
            {
                lock(ImageLock)
                {
                    _HeatMap = value;
                }                
            }
        }

        private Bitmap _MoistureMap_Movable;
        private Bitmap _MoistureMap_Fixed;
        private Bitmap _MoistureMap;
        public Bitmap MoistureMap
        {
            get
            {
                lock (ImageLock)
                {
                    return (Bitmap)_MoistureMap.Clone();
                }
            }
            private set
            {
                lock (ImageLock)
                {
                    _MoistureMap = value;
                }
            }
        }

        private Bitmap _BiomeMap_Movable;
        private Bitmap _BiomeMap_Fixed;
        private Bitmap _BiomeMap;
        public Bitmap BiomeMap
        {
            get
            {
                lock (ImageLock)
                {
                    return (Bitmap)_BiomeMap.Clone();
                }
            }
            private set
            {
                lock (ImageLock)
                {
                    _BiomeMap = value;
                }
            }
        }

        private Bitmap _VintageMap_Movable;
        private Bitmap _VintageMap_Fixed;
        private Bitmap _VintageMap;
        public Bitmap VintageMap
        {
            get
            {
                lock (ImageLock)
                {
                    return (Bitmap)_VintageMap.Clone();
                }
            }
            private set
            {
                lock (ImageLock)
                {
                    _VintageMap = value;
                }
            }
        }
        #endregion

        #region Initialize Maps

        public void GenerateNew(int height = 512 , int width = 512)
        {
            Initialized = false;

            Height = height;
            Width = width;
            Resolution = Width.ToString() + " x " + Height.ToString();

            Random rand = new Random();
            Seed = rand.Next(0, int.MaxValue);
            
            OnProgressBarUpdate(new ProgressEventArgs(0, "Initializing"));
            Initialize();

            OnProgressBarUpdate(new ProgressEventArgs(1 , "Getting Data"));
            GetDataBothAxis();

            UpdateMap(HMapping.Scale, TMapping.Scale, MMapping.Scale);

            InitHeatData = new MapData(HeatData);
            InitHeightData = new MapData(HeightData);
            InitMoistureData = new MapData(MoistureData);

            Initialized = true;
            ZoomPercent = 1.0;
            DrawOffsetX = 0;
            DrawOffsetY = 1;

        }

        public void UpdateMap(float hScale , float TScale , float mScale)
        {
            HMapping = new HeightMapping(hScale);
            TMapping = new HeatMapping(TScale);
            MMapping = new MoistureMapping(mScale);

            if(Initialized)
            {
                HeatData = new MapData(InitHeatData);
                HeightData = new MapData(InitHeightData);
                MoistureData = new MapData(InitMoistureData);
            }

            OnProgressBarUpdate(new ProgressEventArgs(43, "Loading Tiles"));
            LoadTiles();
            OnProgressBarUpdate(new ProgressEventArgs(44, "Updating neighbor Tiles"));
            UpdateNeighbors();

            OnProgressBarUpdate(new ProgressEventArgs(45, "Generating Rivers"));
            GenerateRivers();
            BuildRiverGroups();
            DigRiverGroups();

            OnProgressBarUpdate(new ProgressEventArgs(46, "Adjusting Moisture Map"));
            AdjustMoistureMap();

            UpdateBitmasks();
            FloodFill();

            OnProgressBarUpdate(new ProgressEventArgs(87, "Generating Biomes"));
            GenerateBiomeMap();
            UpdateBiomeBitmask();

            OnProgressBarUpdate(new ProgressEventArgs(89, "Setting Height Map"));
            HeightMap = TextureGenerator.GetHeightMapTexture(Width, Height, Tiles);
            OnProgressBarUpdate(new ProgressEventArgs(91, "Setting Heat Map"));
            HeatMap = TextureGenerator.GetHeatMapTexture(Width, Height, Tiles);
            OnProgressBarUpdate(new ProgressEventArgs(93, "Setting Moisture Map"));
            MoistureMap = TextureGenerator.GetMoistureMapTexture(Width, Height, Tiles);
            OnProgressBarUpdate(new ProgressEventArgs(95, "Setting Biome Map"));
            BiomeMap = TextureGenerator.GetBiomeMapTexture(Width, Height, Tiles, TMapping.ColdestValue, TMapping.ColderValue, TMapping.ColdValue);
            OnProgressBarUpdate(new ProgressEventArgs(97, "Setting Vintage Map"));
            VintageMap = TextureGenerator.GetVintageMapTexture(Width, Height, Tiles);

            _HeatMap_Fixed = HeatMap;
            _HeatMap_Movable = HeatMap;
            _HeightMap_Fixed = HeightMap;
            _HeightMap_Movable = HeightMap;
            _MoistureMap_Fixed = MoistureMap;
            _MoistureMap_Movable = MoistureMap;
            _BiomeMap_Fixed = BiomeMap;
            _BiomeMap_Movable = BiomeMap;
            _VintageMap_Fixed = VintageMap;
            _VintageMap_Movable = VintageMap;

            OnProgressBarUpdate(new ProgressEventArgs(100, "Finished"));
            OnMapsUpdate(new EventArgs());
        }

        private void Initialize()
        {
            // Initialize the HeightMap Generator
            HeightMapFractal = new ImplicitFractal(FractalType.MULTI,
                                             BasisType.SIMPLEX,
                                             InterpolationType.QUINTIC,
                                             HMapping.TerrainOctaves,
                                             HMapping.TerrainFrequency,
                                             Seed);


            // Initialize the Heat map
            ImplicitGradient gradient = new ImplicitGradient(1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            ImplicitFractal heatFractal = new ImplicitFractal(FractalType.MULTI,
                                                              BasisType.SIMPLEX,
                                                              InterpolationType.QUINTIC,
                                                              TMapping.HeatOctaves,
                                                              TMapping.HeatFrequency,
                                                              Seed);

            HeatMapFractal = new ImplicitCombiner(CombinerType.MULTIPLY);
            HeatMapFractal.AddSource(gradient);
            HeatMapFractal.AddSource(heatFractal);

            //moisture map
            MoistureMapFractal = new ImplicitFractal(FractalType.MULTI,
                                               BasisType.SIMPLEX,
                                               InterpolationType.QUINTIC,
                                               MMapping.MoistureOctaves,
                                               MMapping.MoistureFrequency,
                                               Seed);
        }
        #endregion

        #region Biome Map
        private void UpdateBiomeBitmask()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Tiles[x, y].UpdateBiomeBitmask();
                }
            }
        }

        public BiomeType GetBiomeType(Tile tile)
        {
            return BiomeTable[(int)tile.MoistureType, (int)tile.HeatType];
        }

        private void GenerateBiomeMap()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {

                    if (!Tiles[x, y].Collidable) continue;

                    Tile t = Tiles[x, y];
                    t.BiomeType = GetBiomeType(t);
                }
            }
        }

        #endregion

        #region Rivers

        private void AddMoisture(Tile t, int radius)
        {
            int startx = MathHelper.Mod(t.X - radius, Width);
            int endx = MathHelper.Mod(t.X + radius, Width);
            Vector2 center = new Vector2(t.X, t.Y);
            int curr = radius;

            while (curr > 0)
            {

                int x1 = MathHelper.Mod(t.X - curr, Width);
                int x2 = MathHelper.Mod(t.X + curr, Width);
                int y = t.Y;

                AddMoisture(Tiles[x1, y], 0.025f / (center - new Vector2(x1, y)).Length());

                for (int i = 0; i < curr; i++)
                {
                    AddMoisture(Tiles[x1, MathHelper.Mod(y + i + 1, Height)], 0.025f / (center - new Vector2(x1, MathHelper.Mod(y + i + 1, Height))).Length());
                    AddMoisture(Tiles[x1, MathHelper.Mod(y - (i + 1), Height)], 0.025f / (center - new Vector2(x1, MathHelper.Mod(y - (i + 1), Height))).Length());

                    AddMoisture(Tiles[x2, MathHelper.Mod(y + i + 1, Height)], 0.025f / (center - new Vector2(x2, MathHelper.Mod(y + i + 1, Height))).Length());
                    AddMoisture(Tiles[x2, MathHelper.Mod(y - (i + 1), Height)], 0.025f / (center - new Vector2(x2, MathHelper.Mod(y - (i + 1), Height))).Length());
                }
                curr--;
            }
        }

        private void AddMoisture(Tile t, float amount)
        {
            MoistureData.Data[t.X, t.Y] += amount;
            t.MoistureValue += amount;
            if (t.MoistureValue > 1)
                t.MoistureValue = 1;

            //set moisture type
            if (t.MoistureValue < MMapping.DryerValue) t.MoistureType = MoistureType.Dryest;
            else if (t.MoistureValue < MMapping.DryValue) t.MoistureType = MoistureType.Dryer;
            else if (t.MoistureValue < MMapping.WetValue) t.MoistureType = MoistureType.Dry;
            else if (t.MoistureValue < MMapping.WetterValue) t.MoistureType = MoistureType.Wet;
            else if (t.MoistureValue < MMapping.WettestValue) t.MoistureType = MoistureType.Wetter;
            else t.MoistureType = MoistureType.Wettest;
        }

        private void AdjustMoistureMap()
        {
            int percent = 47;
            Tile t;
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {

                    t = Tiles[x, y];
                    if (t.HeightType == HeightType.River)
                    {
                        AddMoisture(t, Width / 128);
                    }
                }
                if ((x % (Width / 40)) == 0)
                {
                    OnProgressBarUpdate(new ProgressEventArgs(percent++, "Adjusting Moisture Map"));
                }
            }
        }

        private void DigRiverGroups()
        {
            for (int i = 0; i < RiverGroups.Count; i++)
            {

                RiverGroup group = RiverGroups[i];
                River longest = null;

                //Find longest river in this group
                for (int j = 0; j < group.Rivers.Count; j++)
                {
                    River river = group.Rivers[j];
                    if (longest == null)
                        longest = river;
                    else if (longest.Tiles.Count < river.Tiles.Count)
                        longest = river;
                }

                if (longest != null)
                {
                    //Dig out longest path first
                    DigRiver(longest);

                    for (int j = 0; j < group.Rivers.Count; j++)
                    {
                        River river = group.Rivers[j];
                        if (river != longest)
                        {
                            DigRiver(river, longest);
                        }
                    }
                }
            }
        }

        private void BuildRiverGroups()
        {
            //loop each tile, checking if it belongs to multiple rivers
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Tile t = Tiles[x, y];

                    if (t.Rivers.Count > 1)
                    {
                        // multiple rivers == intersection
                        RiverGroup group = null;

                        // Does a rivergroup already exist for this group?
                        for (int n = 0; n < t.Rivers.Count; n++)
                        {
                            River tileriver = t.Rivers[n];
                            for (int i = 0; i < RiverGroups.Count; i++)
                            {
                                for (int j = 0; j < RiverGroups[i].Rivers.Count; j++)
                                {
                                    River river = RiverGroups[i].Rivers[j];
                                    if (river.ID == tileriver.ID)
                                    {
                                        group = RiverGroups[i];
                                    }
                                    if (group != null) break;
                                }
                                if (group != null) break;
                            }
                            if (group != null) break;
                        }

                        // existing group found -- add to it
                        if (group != null)
                        {
                            for (int n = 0; n < t.Rivers.Count; n++)
                            {
                                if (!group.Rivers.Contains(t.Rivers[n]))
                                    group.Rivers.Add(t.Rivers[n]);
                            }
                        }
                        else   //No existing group found - create a new one
                        {
                            group = new RiverGroup();
                            for (int n = 0; n < t.Rivers.Count; n++)
                            {
                                group.Rivers.Add(t.Rivers[n]);
                            }
                            RiverGroups.Add(group);
                        }
                    }
                }
            }
        }

        private void GenerateRivers()
        {
            int attempts = 0;
            int rivercount = RiverCount;
            Rivers = new List<River>();
            Random rand = new Random();

            // Generate some rivers
            while (rivercount > 0 && attempts < MaxRiverAttempts)
            {

                // Get a random tile
                int x = rand.Next(0, Width);
                int y = rand.Next(0, Height);
                Tile tile = Tiles[x, y];

                // validate the tile
                if (!tile.Collidable) continue;
                if (tile.Rivers.Count > 0) continue;

                if (tile.HeightValue > MinRiverHeight)
                {
                    // Tile is good to start river from
                    River river = new River(rivercount);

                    // Figure out the direction this river will try to flow
                    river.CurrentDirection = tile.GetLowestNeighbor();

                    // Recursively find a path to water
                    FindPathToWater(tile, river.CurrentDirection, ref river);

                    // Validate the generated river 
                    if (river.TurnCount < MinRiverTurns || river.Tiles.Count < MinRiverLength || river.Intersections > MaxRiverIntersections)
                    {
                        //Validation failed - remove this river
                        for (int i = 0; i < river.Tiles.Count; i++)
                        {
                            Tile t = river.Tiles[i];
                            t.Rivers.Remove(river);
                        }
                    }
                    else if (river.Tiles.Count >= MinRiverLength)
                    {
                        //Validation passed - Add river to list
                        Rivers.Add(river);
                        tile.Rivers.Add(river);
                        rivercount--;
                    }
                }
                attempts++;
            }
        }

        // Dig river based on a parent river vein
        private void DigRiver(River river, River parent)
        {
            int intersectionID = 0;
            int intersectionSize = 0;
            Random rand = new Random();

            // determine point of intersection
            for (int i = 0; i < river.Tiles.Count; i++)
            {
                Tile t1 = river.Tiles[i];
                for (int j = 0; j < parent.Tiles.Count; j++)
                {
                    Tile t2 = parent.Tiles[j];
                    if (t1 == t2)
                    {
                        intersectionID = i;
                        intersectionSize = t2.RiverSize;
                    }
                }
            }

            int counter = 0;
            int intersectionCount = river.Tiles.Count - intersectionID;
            int size = rand.Next(intersectionSize, 5);
            river.Length = river.Tiles.Count;

            // randomize size change
            int two = river.Length / 2;
            int three = two / 2;
            int four = three / 2;
            int five = four / 2;

            int twomin = two / 3;
            int threemin = three / 3;
            int fourmin = four / 3;
            int fivemin = five / 3;

            // randomize length of each size
            int count1 = rand.Next(fivemin, five);
            if (size < 4)
            {
                count1 = 0;
            }
            int count2 = count1 + rand.Next(fourmin, four);
            if (size < 3)
            {
                count2 = 0;
                count1 = 0;
            }
            int count3 = count2 + rand.Next(threemin, three);
            if (size < 2)
            {
                count3 = 0;
                count2 = 0;
                count1 = 0;
            }
            int count4 = count3 + rand.Next(twomin, two);

            // Make sure we are not digging past the river path
            if (count4 > river.Length)
            {
                int extra = count4 - river.Length;
                while (extra > 0)
                {
                    if (count1 > 0) { count1--; count2--; count3--; count4--; extra--; }
                    else if (count2 > 0) { count2--; count3--; count4--; extra--; }
                    else if (count3 > 0) { count3--; count4--; extra--; }
                    else if (count4 > 0) { count4--; extra--; }
                }
            }

            // adjust size of river at intersection point
            if (intersectionSize == 1)
            {
                count4 = intersectionCount;
                count1 = 0;
                count2 = 0;
                count3 = 0;
            }
            else if (intersectionSize == 2)
            {
                count3 = intersectionCount;
                count1 = 0;
                count2 = 0;
            }
            else if (intersectionSize == 3)
            {
                count2 = intersectionCount;
                count1 = 0;
            }
            else if (intersectionSize == 4)
            {
                count1 = intersectionCount;
            }
            else
            {
                count1 = 0;
                count2 = 0;
                count3 = 0;
                count4 = 0;
            }

            // dig out the river
            for (int i = river.Tiles.Count - 1; i >= 0; i--)
            {

                Tile t = river.Tiles[i];

                if (counter < count1)
                {
                    t.DigRiver(river, 4);
                }
                else if (counter < count2)
                {
                    t.DigRiver(river, 3);
                }
                else if (counter < count3)
                {
                    t.DigRiver(river, 2);
                }
                else if (counter < count4)
                {
                    t.DigRiver(river, 1);
                }
                else
                {
                    t.DigRiver(river, 0);
                }
                counter++;
            }
        }

        // Dig river
        private void DigRiver(River river)
        {
            int counter = 0;
            Random rand = new Random();
            // How wide are we digging this river?
            int size = rand.Next(1, 5);
            river.Length = river.Tiles.Count;

            // randomize size change
            int two = river.Length / 2;
            int three = two / 2;
            int four = three / 2;
            int five = four / 2;

            int twomin = two / 3;
            int threemin = three / 3;
            int fourmin = four / 3;
            int fivemin = five / 3;

            // randomize lenght of each size
            int count1 = rand.Next(fivemin, five);
            if (size < 4)
            {
                count1 = 0;
            }
            int count2 = count1 + rand.Next(fourmin, four);
            if (size < 3)
            {
                count2 = 0;
                count1 = 0;
            }
            int count3 = count2 + rand.Next(threemin, three);
            if (size < 2)
            {
                count3 = 0;
                count2 = 0;
                count1 = 0;
            }
            int count4 = count3 + rand.Next(twomin, two);

            // Make sure we are not digging past the river path
            if (count4 > river.Length)
            {
                int extra = count4 - river.Length;
                while (extra > 0)
                {
                    if (count1 > 0) { count1--; count2--; count3--; count4--; extra--; }
                    else if (count2 > 0) { count2--; count3--; count4--; extra--; }
                    else if (count3 > 0) { count3--; count4--; extra--; }
                    else if (count4 > 0) { count4--; extra--; }
                }
            }

            // Dig it out
            for (int i = river.Tiles.Count - 1; i >= 0; i--)
            {
                Tile t = river.Tiles[i];

                if (counter < count1)
                {
                    t.DigRiver(river, 4);
                }
                else if (counter < count2)
                {
                    t.DigRiver(river, 3);
                }
                else if (counter < count3)
                {
                    t.DigRiver(river, 2);
                }
                else if (counter < count4)
                {
                    t.DigRiver(river, 1);
                }
                else
                {
                    t.DigRiver(river, 0);
                }
                counter++;
            }
        }
        
        private void FindPathToWater(Tile tile, Direction direction, ref River river)
        {
            while (!tile.Rivers.Contains(river))
            {
                // check if there is already a river on this tile
                if (tile.Rivers.Count > 0)
                    river.Intersections++;

                river.AddTile(tile);

                // get neighbors
                Tile left = GetLeft(tile);
                Tile right = GetRight(tile);
                Tile top = GetTop(tile);
                Tile bottom = GetBottom(tile);

                float leftValue = int.MaxValue;
                float rightValue = int.MaxValue;
                float topValue = int.MaxValue;
                float bottomValue = int.MaxValue;

                // query height values of neighbors
                if (left.GetRiverNeighborCount(river) < 2 && !river.Tiles.Contains(left))
                    leftValue = left.HeightValue;
                if (right.GetRiverNeighborCount(river) < 2 && !river.Tiles.Contains(right))
                    rightValue = right.HeightValue;
                if (top.GetRiverNeighborCount(river) < 2 && !river.Tiles.Contains(top))
                    topValue = top.HeightValue;
                if (bottom.GetRiverNeighborCount(river) < 2 && !river.Tiles.Contains(bottom))
                    bottomValue = bottom.HeightValue;

                // if neighbor is existing river that is not this one, flow into it
                if (bottom.Rivers.Count == 0 && !bottom.Collidable)
                    bottomValue = 0;
                if (top.Rivers.Count == 0 && !top.Collidable)
                    topValue = 0;
                if (left.Rivers.Count == 0 && !left.Collidable)
                    leftValue = 0;
                if (right.Rivers.Count == 0 && !right.Collidable)
                    rightValue = 0;

                // override flow direction if a tile is significantly lower
                if (direction == Direction.Left)
                    if (Math.Abs(rightValue - leftValue) < 0.1f)
                        rightValue = int.MaxValue;
                if (direction == Direction.Right)
                    if (Math.Abs(rightValue - leftValue) < 0.1f)
                        leftValue = int.MaxValue;
                if (direction == Direction.Top)
                    if (Math.Abs(topValue - bottomValue) < 0.1f)
                        bottomValue = int.MaxValue;
                if (direction == Direction.Bottom)
                    if (Math.Abs(topValue - bottomValue) < 0.1f)
                        topValue = int.MaxValue;

                // find mininum
                float min = Math.Min(Math.Min(Math.Min(leftValue, rightValue), topValue), bottomValue);

                // if no minimum found - exit
                if (min == int.MaxValue)
                    return;

                //Move to next neighbor
                if (min == leftValue)
                {
                    if (left.Collidable)
                    {
                        if (river.CurrentDirection != Direction.Left)
                        {
                            river.TurnCount++;
                            river.CurrentDirection = Direction.Left;
                        }
                        tile = left;
                        //FindPathToWater(left, direction, ref river);
                    }
                }
                else if (min == rightValue)
                {
                    if (right.Collidable)
                    {
                        if (river.CurrentDirection != Direction.Right)
                        {
                            river.TurnCount++;
                            river.CurrentDirection = Direction.Right;
                        }
                        tile = right;
                        //FindPathToWater(right, direction, ref river);
                    }
                }
                else if (min == bottomValue)
                {
                    if (bottom.Collidable)
                    {
                        if (river.CurrentDirection != Direction.Bottom)
                        {
                            river.TurnCount++;
                            river.CurrentDirection = Direction.Bottom;
                        }
                        tile = bottom;
                        //FindPathToWater(bottom, direction, ref river);
                    }
                }
                else if (min == topValue)
                {
                    if (top.Collidable)
                    {
                        if (river.CurrentDirection != Direction.Top)
                        {
                            river.TurnCount++;
                            river.CurrentDirection = Direction.Top;
                        }
                        tile = top;
                        //FindPathToWater(top, direction, ref river);
                    }
                }
            }
        }

        #endregion

        #region Get Data 
        private void GetDataXAxis()
        {
            HeightData = new MapData(Width, Height);
            HeatData = new MapData(Width, Height);
            MoistureData = new MapData(Width, Height);
            int percent = 1;
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    //Wrap on x - axis only
                    //Noise range
                    float x1 = 0, x2 = 2;
                    float y1 = 0, y2 = 2;
                    float dx = x2 - x1;
                    float dy = y2 - y1;

                    //Sample noise at smaller intervals
                    float s = x / (float)Width;
                    float t = y / (float)Height;

                    // Calculate our 3D coordinates
                    double nx = x1 + Math.Cos(s * 2 * Math.PI) * dx / (2 * Math.PI);
                    double ny = x1 + Math.Sin(s * 2 * Math.PI) * dx / (2 * Math.PI);
                    double nz = t;

                    float heightValue = (float)HeightMapFractal.Get(nx, ny, nz);
                    float heatValue = (float)HeatMapFractal.Get(nx, ny, nz);
                    float moistureValue = (float)MoistureMapFractal.Get(nx, ny, nz);
                    
                    // keep track of the max and min values found
                    if (heightValue > HeightData.Max) HeightData.Max = heightValue;
                    if (heightValue < HeightData.Min) HeightData.Min = heightValue;

                    if (heatValue > HeatData.Max) HeatData.Max = heatValue;
                    if (heatValue < HeatData.Min) HeatData.Min = heatValue;

                    if (moistureValue > MoistureData.Max) MoistureData.Max = moistureValue;
                    if (moistureValue < MoistureData.Min) MoistureData.Min = moistureValue;

                    HeightData.Data[x, y] = heightValue;
                    HeatData.Data[x, y] = heatValue;
                    MoistureData.Data[x, y] = moistureValue;
                }
                if ((x % (Width / 40)) == 0)
                {
                    OnProgressBarUpdate(new ProgressEventArgs(percent++, "Getting Data"));
                }
            }
        }
        // Extract data from a noise module
        private void GetDataBothAxis()
        {
            HeightData = new MapData(Width, Height);
            HeatData = new MapData(Width, Height);
            MoistureData = new MapData(Width, Height);
            int percent = 1;
            // loop through each x,y point - get height value
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    // WRAP ON BOTH AXIS
                    // Noise range
                    float x1 = 0, x2 = 2;
                    float y1 = 0, y2 = 2;
                    float dx = x2 - x1;
                    float dy = y2 - y1;

                    // Sample noise at smaller intervals
                    double s = x / (float)Width;
                    double t = y / (float)Height;

                    // Calculate our 4D coordinates
                    double nx = x1 + Math.Cos(s * 2 * Math.PI) * dx / (2 * Math.PI);
                    double ny = y1 + Math.Cos(t * 2 * Math.PI) * dy / (2 * Math.PI);
                    double nz = x1 + Math.Sin(s * 2 * Math.PI) * dx / (2 * Math.PI);
                    double nw = y1 + Math.Sin(t * 2 * Math.PI) * dy / (2 * Math.PI);

                    float heightValue = (float)HeightMapFractal.Get(nx, ny, nz, nw);
                    float heatValue = (float)HeatMapFractal.Get(nx, ny, nz, nw);
                    float moistureValue = (float)MoistureMapFractal.Get(nx, ny, nz, nw);

                    // keep track of the max and min values found
                    if (heightValue > HeightData.Max) HeightData.Max = heightValue;
                    if (heightValue < HeightData.Min) HeightData.Min = heightValue;

                    if (heatValue > HeatData.Max) HeatData.Max = heatValue;
                    if (heatValue < HeatData.Min) HeatData.Min = heatValue;

                    if (moistureValue > MoistureData.Max) MoistureData.Max = moistureValue;
                    if (moistureValue < MoistureData.Min) MoistureData.Min = moistureValue;

                    HeightData.Data[x, y] = heightValue;
                    HeatData.Data[x, y] = heatValue;
                    MoistureData.Data[x, y] = moistureValue;
                }
                if((x % (Width/40)) == 0)
                {
                    OnProgressBarUpdate(new ProgressEventArgs(percent++, "Getting Data"));
                }
            }

        }

        private void GetDataSpherical()
        {
            HeightData = new MapData(Width, Height);
            HeatData = new MapData(Width, Height);
            MoistureData = new MapData(Width, Height);
            int percent = 1;

            // Define our map area in latitude/longitude
            float southLatBound = -180;
            float northLatBound = 180;
            float westLonBound = -90;
            float eastLonBound = 90;

            float lonExtent = eastLonBound - westLonBound;
            float latExtent = northLatBound - southLatBound;

            float xDelta = lonExtent / (float)Width;
            float yDelta = latExtent / (float)Height;

            float curLon = westLonBound;
            float curLat = southLatBound;

            // Loop through each tile using its lat/long coordinates
            for (var x = 0; x < Width; x++)
            {
                curLon = westLonBound;

                for (var y = 0; y < Height; y++)
                {

                    float x1 = 0, y1 = 0, z1 = 0;

                    // Convert this lat/lon to x/y/z
                    LatLonToXYZ(curLat, curLon, ref x1, ref y1, ref z1);

                    // Heat data
                    float sphereValue = (float)HeatMapFractal.Get(x1, y1, z1);
                    if (sphereValue > HeatData.Max)
                        HeatData.Max = sphereValue;
                    if (sphereValue < HeatData.Min)
                        HeatData.Min = sphereValue;
                    HeatData.Data[x, y] = sphereValue;

                    float coldness = Math.Abs(curLon) / 90f;
                    float heat = 1 - Math.Abs(curLon) / 90f;
                    HeatData.Data[x, y] += heat;
                    HeatData.Data[x, y] -= coldness;

                    // Height Data
                    float heightValue = (float)HeightMapFractal.Get(x1, y1, z1);
                    if (heightValue > HeightData.Max)
                        HeightData.Max = heightValue;
                    if (heightValue < HeightData.Min)
                        HeightData.Min = heightValue;
                    HeightData.Data[x, y] = heightValue;

                    // Moisture Data
                    float moistureValue = (float)MoistureMapFractal.Get(x1, y1, z1);
                    if (moistureValue > MoistureData.Max)
                        MoistureData.Max = moistureValue;
                    if (moistureValue < MoistureData.Min)
                        MoistureData.Min = moistureValue;
                    MoistureData.Data[x, y] = moistureValue;

                    curLon += xDelta;
                }
                curLat += yDelta;

                if ((x % (Width / 40)) == 0)
                {
                    OnProgressBarUpdate(new ProgressEventArgs(percent++, "Getting Data"));
                }
            }
        }

        // Convert Lat/Long coordinates to x/y/z for spherical mapping
        void LatLonToXYZ(float lat, float lon, ref float x, ref float y, ref float z)
        {
            float r = (float)Math.Cos(Math.PI / 180.0f * lon);
            x = r * (float)Math.Cos(Math.PI / 180.0f * lat);
            y = (float)Math.Sin(Math.PI / 180.0f * lon);
            z = r * (float)Math.Sin(Math.PI / 180.0f * lat);
        }

        #endregion

        #region Tile Stuff
        // Build a Tile array from our data
        private void LoadTiles()
        {
            Tiles = new Tile[Width, Height];

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Tile t = new Tile();
                    t.X = x;
                    t.Y = y;

                    //set heightmap value
                    float heightValue = HeightData.Data[x, y];
                    heightValue = (heightValue - HeightData.Min) / (HeightData.Max - HeightData.Min);
                    t.HeightValue = heightValue;


                    if (heightValue < HMapping.DeepWater)
                    {
                        t.HeightType = HeightType.DeepWater;
                        t.Collidable = false;
                    }
                    else if (heightValue < HMapping.ShallowWater)
                    {
                        t.HeightType = HeightType.ShallowWater;
                        t.Collidable = false;
                    }
                    else if (heightValue < HMapping.Sand)
                    {
                        t.HeightType = HeightType.Sand;
                        t.Collidable = true;
                    }
                    else if (heightValue < HMapping.Grass)
                    {
                        t.HeightType = HeightType.Grass;
                        t.Collidable = true;
                    }
                    else if (heightValue < HMapping.Forest)
                    {
                        t.HeightType = HeightType.Forest;
                        t.Collidable = true;
                    }
                    else if (heightValue < HMapping.Rock)
                    {
                        t.HeightType = HeightType.Rock;
                        t.Collidable = true;
                    }
                    else
                    {
                        t.HeightType = HeightType.Snow;
                        t.Collidable = true;
                    }


                    //adjust moisture based on height
                    if (t.HeightType == HeightType.DeepWater)
                    {
                        MoistureData.Data[t.X, t.Y] += 8f * t.HeightValue;
                    }
                    else if (t.HeightType == HeightType.ShallowWater)
                    {
                        MoistureData.Data[t.X, t.Y] += 3f * t.HeightValue;
                    }
                    else if (t.HeightType == HeightType.Shore)
                    {
                        MoistureData.Data[t.X, t.Y] += 1f * t.HeightValue;
                    }
                    else if (t.HeightType == HeightType.Sand)
                    {
                        MoistureData.Data[t.X, t.Y] += 0.2f * t.HeightValue;
                    }

                    //Moisture Map Analyze	
                    float moistureValue = MoistureData.Data[x, y];
                    moistureValue = (moistureValue - MoistureData.Min) / (MoistureData.Max - MoistureData.Min);
                    t.MoistureValue = moistureValue;

                    //set moisture type
                    if (moistureValue < MMapping.DryerValue) t.MoistureType = MoistureType.Dryest;
                    else if (moistureValue < MMapping.DryValue) t.MoistureType = MoistureType.Dryer;
                    else if (moistureValue < MMapping.WetValue) t.MoistureType = MoistureType.Dry;
                    else if (moistureValue < MMapping.WetterValue) t.MoistureType = MoistureType.Wet;
                    else if (moistureValue < MMapping.WettestValue) t.MoistureType = MoistureType.Wetter;
                    else t.MoistureType = MoistureType.Wettest;


                    // Adjust Heat Map based on Height - Higher == colder
                    if(t.HeightType == HeightType.Grass)
                    {
                        HeatData.Data[t.X, t.Y] -= 0.1f * t.HeightValue;
                    }
                    else if (t.HeightType == HeightType.Forest)
                    {
                        HeatData.Data[t.X, t.Y] -= 0.1f * t.HeightValue;
                    }
                    else if (t.HeightType == HeightType.Rock)
                    {
                        HeatData.Data[t.X, t.Y] -= 0.25f * t.HeightValue;
                    }
                    else if (t.HeightType == HeightType.Snow)
                    {
                        HeatData.Data[t.X, t.Y] -= 0.4f * t.HeightValue;
                    }
                    else
                    {
                        HeatData.Data[t.X, t.Y] += 0.01f * t.HeightValue;
                    }

                    // Set heat value
                    float heatValue = HeatData.Data[x, y];
                    heatValue = (heatValue - HeatData.Min) / (HeatData.Max - HeatData.Min);
                    t.HeatValue = heatValue;

                    // set heat type
                    if (heatValue < TMapping.ColdestValue) t.HeatType = HeatType.Coldest;
                    else if (heatValue < TMapping.ColderValue) t.HeatType = HeatType.Colder;
                    else if (heatValue < TMapping.ColdValue) t.HeatType = HeatType.Cold;
                    else if (heatValue < TMapping.WarmValue) t.HeatType = HeatType.Warm;
                    else if (heatValue < TMapping.WarmerValue) t.HeatType = HeatType.Warmer;
                    else t.HeatType = HeatType.Warmest;

                    Tiles[x, y] = t;
                }
            }
        }

        private void UpdateNeighbors()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Tile t = Tiles[x, y];

                    t.Top = GetTop(t);
                    t.Bottom = GetBottom(t);
                    t.Left = GetLeft(t);
                    t.Right = GetRight(t);
                }
            }
        }

        private void UpdateBitmasks()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Tiles[x, y].UpdateBitmask();
                }
            }
        }

        private void FloodFill()
        {
            // Use a stack instead of recursion
            Stack<Tile> stack = new Stack<Tile>();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {

                    Tile t = Tiles[x, y];

                    //Tile already flood filled, skip
                    if (t.FloodFilled) continue;

                    // Land
                    if (t.Collidable)
                    {
                        TileGroup group = new TileGroup();
                        group.Type = TileGroupType.Land;
                        stack.Push(t);

                        while (stack.Count > 0)
                        {
                            FloodFill(stack.Pop(), ref group, ref stack);
                        }

                        if (group.Tiles.Count > 0)
                            Lands.Add(group);
                    }
                    // Water
                    else
                    {
                        TileGroup group = new TileGroup();
                        group.Type = TileGroupType.Water;
                        stack.Push(t);

                        while (stack.Count > 0)
                        {
                            FloodFill(stack.Pop(), ref group, ref stack);
                        }

                        if (group.Tiles.Count > 0)
                            Waters.Add(group);
                    }
                }
            }
        }

        private void FloodFill(Tile tile, ref TileGroup tiles, ref Stack<Tile> stack)
        {
            // Validate
            if (tile.FloodFilled)
                return;
            if (tiles.Type == TileGroupType.Land && !tile.Collidable)
                return;
            if (tiles.Type == TileGroupType.Water && tile.Collidable)
                return;

            // Add to TileGroup
            tiles.Tiles.Add(tile);
            tile.FloodFilled = true;

            // floodfill into neighbors
            Tile t = GetTop(tile);
            if (!t.FloodFilled && tile.Collidable == t.Collidable)
                stack.Push(t);
            t = GetBottom(tile);
            if (!t.FloodFilled && tile.Collidable == t.Collidable)
                stack.Push(t);
            t = GetLeft(tile);
            if (!t.FloodFilled && tile.Collidable == t.Collidable)
                stack.Push(t);
            t = GetRight(tile);
            if (!t.FloodFilled && tile.Collidable == t.Collidable)
                stack.Push(t);
        }

        private Tile GetTop(Tile t)
        {
            return Tiles[t.X, MathHelper.Mod(t.Y - 1, Height)];
        }
        private Tile GetBottom(Tile t)
        {
            return Tiles[t.X, MathHelper.Mod(t.Y + 1, Height)];
        }
        private Tile GetLeft(Tile t)
        {
            return Tiles[MathHelper.Mod(t.X - 1, Width), t.Y];
        }
        private Tile GetRight(Tile t)
        {
            return Tiles[MathHelper.Mod(t.X + 1, Width), t.Y];
        }

        #endregion

        #region Image Movement Manipulation
        public void Zoom(int x , int y , double percent)
        {
            Bitmap imgClone = new Bitmap(Width, Height);

            Rectangle srcRect = new Rectangle(0, 0, Width, Height);
            Rectangle destRect = new Rectangle((int)(x * (1 - 1 / percent)),(int) (y * (1 - 1 / percent)), (int)(Width / percent), (int)(Height / percent));
            Graphics imgGraphic = Graphics.FromImage(imgClone);
            lock (ImageLock)
            {
                imgGraphic.DrawImage(_HeightMap_Fixed, srcRect, destRect, GraphicsUnit.Pixel);
            }
            
            
            HeightMap = imgClone;

            lock(ImageLock)
            {
                _HeightMap_Movable = HeightMap;
            }

            OnMapsUpdate(new EventArgs());
        }
        
        public void StartDrag()
        {
            DragOriginX = Cursor.Position.X;
            DragOriginY = Cursor.Position.Y;
            isDragging = true;
            Thread dragMap = new Thread(DragMapThread);
            dragMap.Start();
        }

        public void EndDrag()
        {
            isDragging = false;
        }

        private void DragMapThread()
        {
            while (isDragging)
            {                
                Bitmap heightClone;
                Bitmap heatClone;
                Bitmap moistureClone;
                Bitmap biomeClone;
                Bitmap vintageClone;

                lock (ImageLock)
                {
                    heightClone = (Bitmap)_HeightMap_Movable.Clone();
                    heatClone = (Bitmap)_HeatMap_Movable.Clone();
                    moistureClone = (Bitmap)_MoistureMap_Movable.Clone();
                    biomeClone = (Bitmap)_BiomeMap_Movable.Clone();
                    vintageClone = (Bitmap)_VintageMap_Movable.Clone();
                }              

                Graphics heightGraphic = Graphics.FromImage(heightClone);
                Graphics heatGraphic = Graphics.FromImage(heatClone);
                Graphics moistureGraphic = Graphics.FromImage(moistureClone);
                Graphics biomeGraphic = Graphics.FromImage(biomeClone);
                Graphics vintageGraphic = Graphics.FromImage(vintageClone);

                float dx = (Cursor.Position.X - DragOriginX) / (1024 / Width);
                float dy = (Cursor.Position.Y - DragOriginY) / (1024 / Height);

                while(dx >  Width)  { dx -= Width; }
                while(dy >  Height) { dy -= Height;}
                while(dx < -Width)  { dx += Width; }
                while(dy < -Height) { dy += Height;}
                
                if (dx > 0)
                {
                    lock(ImageLock)
                    {
                        heightGraphic.DrawImage(_HeightMap_Movable, dx, 0.0f);
                        heightGraphic.DrawImage(_HeightMap_Movable, (float)(dx - Width), 0.0f);
                    }
                    Thread.Sleep(1);

                    lock (ImageLock)
                    {
                        heatGraphic.DrawImage(_HeatMap_Movable, dx, 0.0f);
                        heatGraphic.DrawImage(_HeatMap_Movable, (float)(dx - Width), 0.0f);
                    }
                    Thread.Sleep(1);

                    lock (ImageLock)
                    {
                        moistureGraphic.DrawImage(_MoistureMap_Movable, dx, 0.0f);
                        moistureGraphic.DrawImage(_MoistureMap_Movable, (float)(dx - Width), 0.0f);
                    }
                    Thread.Sleep(1);

                    lock (ImageLock)
                    {
                        biomeGraphic.DrawImage(_BiomeMap_Movable, dx, 0.0f);
                        biomeGraphic.DrawImage(_BiomeMap_Movable, (float)(dx - Width), 0.0f);
                    }
                    Thread.Sleep(1);

                    lock (ImageLock)
                    {
                        vintageGraphic.DrawImage(_VintageMap_Movable, dx, 0.0f);
                        vintageGraphic.DrawImage(_VintageMap_Movable, (float)(dx - Width), 0.0f);
                    }
                    Thread.Sleep(1);
                }
                else
                {
                    lock(ImageLock)
                    {
                        heightGraphic.DrawImage(_HeightMap_Movable, dx, 0.0f);
                        heightGraphic.DrawImage(_HeightMap_Movable, (float)(dx + Width), 0.0f);
                    }
                    Thread.Sleep(1);

                    lock (ImageLock)
                    {
                        heatGraphic.DrawImage(_HeatMap_Movable, dx, 0.0f);
                        heatGraphic.DrawImage(_HeatMap_Movable, (float)(dx + Width), 0.0f);
                    }
                    Thread.Sleep(1);

                    lock (ImageLock)
                    {
                        moistureGraphic.DrawImage(_MoistureMap_Movable, dx, 0.0f);
                        moistureGraphic.DrawImage(_MoistureMap_Movable, (float)(dx + Width), 0.0f);
                    }
                    Thread.Sleep(1);

                    lock (ImageLock)
                    {
                        biomeGraphic.DrawImage(_BiomeMap_Movable, dx, 0.0f);
                        biomeGraphic.DrawImage(_BiomeMap_Movable, (float)(dx + Width), 0.0f);
                    }

                    Thread.Sleep(1);
                    lock (ImageLock)
                    {
                        vintageGraphic.DrawImage(_VintageMap_Movable, dx, 0.0f);
                        vintageGraphic.DrawImage(_VintageMap_Movable, (float)(dx + Width), 0.0f);
                    }

                    Thread.Sleep(1);
                }

                HeightMap = heightClone;
                HeatMap = heatClone;
                MoistureMap = moistureClone;
                BiomeMap = biomeClone;
                VintageMap = vintageClone;

                heightGraphic.Dispose();
                heatGraphic.Dispose();
                moistureGraphic.Dispose();
                biomeGraphic.Dispose();
                vintageGraphic.Dispose();

                OnMapsUpdate(new EventArgs());
                Thread.Sleep(20);
            }

            lock(ImageLock)
            {
                _HeightMap_Movable = HeightMap;
                _HeatMap_Movable = HeatMap;
                _MoistureMap_Movable = MoistureMap;
                _BiomeMap_Movable = BiomeMap;
                _VintageMap_Movable = VintageMap;
            }
            
        }
        #endregion

        #region Event Handling

        public event ProgressEventHandler ProgressBarUpdate;
        protected virtual void OnProgressBarUpdate(ProgressEventArgs e)
        {
            ProgressBarUpdate?.Invoke(this , e );
        }

        public event EventHandler MapsUpdate;
        public delegate void EventHandler(object sender, EventArgs e);
        protected virtual void OnMapsUpdate(EventArgs e)
        {
            MapsUpdate?.Invoke(this, e);
        }
        #endregion

    }
}