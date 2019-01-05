using System.Collections.Generic;
using System.Drawing;

namespace MapGenerator
{
    public static class TextureGenerator {

        // Height Map Colors
        private static Color DeepColor = Color.FromArgb(15, 30, 80);
        private static Color ShallowColor = Color.FromArgb(15, 40, 90);
        private static Color RiverColor = Color.FromArgb(30, 120, 200);
        private static Color SandColor = Color.FromArgb(198, 190, 31);
        private static Color GrassColor = Color.FromArgb(50, 220, 20);
        private static Color ForestColor = Color.FromArgb(16, 160, 0);
        private static Color RockColor = Color.FromArgb(128, 128, 128);
        private static Color SnowColor = Color.FromArgb(255, 255, 255);

        private static Color IceWater = Color.FromArgb(210, 255, 252);
        private static Color ColdWater = Color.FromArgb(119, 156, 213);
        private static Color RiverWater = Color.FromArgb(65, 110, 179);

        // Heat Map Colors
        private static Color Coldest = Color.FromArgb(0, 255, 255);
        private static Color Colder = Color.FromArgb(170, 255, 1);
        private static Color Cold = Color.FromArgb(0, 229, 133);
        private static Color Warm = Color.FromArgb(255, 255, 100);
        private static Color Warmer = Color.FromArgb(255, 100, 0);
        private static Color Warmest = Color.FromArgb(241, 12, 0);

        //Moisture map
        private static Color Dryest = Color.FromArgb(255, 139, 17);
        private static Color Dryer = Color.FromArgb(245, 245, 23);
        private static Color Dry = Color.FromArgb(80, 255, 0);
        private static Color Wet = Color.FromArgb(85, 255, 255);
        private static Color Wetter = Color.FromArgb(20, 70, 255);
        private static Color Wettest = Color.FromArgb(0, 0, 100);

        //Biome map Colors
        private static Color Ice = Color.White;
        private static Color Desert = Color.FromArgb(238, 218, 130);
        private static Color Savanna = Color.FromArgb(177, 209, 110);
        private static Color TropicalRainforest = Color.FromArgb(66, 123, 25);
        private static Color Tundra = Color.FromArgb(96, 131, 112);
        private static Color TemperateRainforest = Color.FromArgb(29, 73, 40);
        private static Color Grassland = Color.FromArgb(164, 225, 99);
        private static Color SeasonalForest = Color.FromArgb(73, 100, 35);
        private static Color BorealForest = Color.FromArgb(95, 115, 62);
        private static Color Woodland = Color.FromArgb(139, 175, 90);

        //Vintage Map Colors
        private static Color VintageWater = Color.SlateGray;
        private static Color VintageLand = Color.SandyBrown;

        public static Bitmap GetHeightMapTexture(int width, int height, Tile[,] tiles)
        {
            var texture = new Bitmap(width, height);

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    switch (tiles[x, y].HeightType)
                    {
                        case HeightType.DeepWater:
                            texture.SetPixel(x, y, DeepColor);
                            break;
                        case HeightType.ShallowWater:
                            texture.SetPixel(x, y, ShallowColor);
                            break;
                        case HeightType.Sand:
                            texture.SetPixel(x, y, SandColor);
                            break;
                        case HeightType.Grass:
                            texture.SetPixel(x, y, GrassColor);
                            break;
                        case HeightType.Forest:
                            texture.SetPixel(x, y, ForestColor);
                            break;
                        case HeightType.Rock:
                            texture.SetPixel(x, y, RockColor);
                            break;
                        case HeightType.Snow:
                            texture.SetPixel(x, y, SnowColor);
                            break;
                        case HeightType.River:
                            texture.SetPixel(x, y, RiverColor);
                            break;
                    }

                    //darken the color if a edge tile
                    if ((int)tiles[x, y].HeightType > 2 && tiles[x, y].Bitmask != 15)
                    {
                        int red = (int)(texture.GetPixel(x, y).R * 0.4);
                        int green = (int)(texture.GetPixel(x, y).G * 0.4);
                        int blue = (int)(texture.GetPixel(x, y).B * 0.4);
                        texture.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }
            }

            return texture;
        }

        public static Bitmap GetHeatMapTexture(int width, int height, Tile[,] tiles)
        {
            var texture = new Bitmap(width, height);

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    switch (tiles[x, y].HeatType)
                    {
                        case HeatType.Coldest:
                            texture.SetPixel(x, y, Coldest);
                            break;
                        case HeatType.Colder:
                            texture.SetPixel(x, y, Colder);
                            break;
                        case HeatType.Cold:
                            texture.SetPixel(x, y, Cold);
                            break;
                        case HeatType.Warm:
                            texture.SetPixel(x, y, Warm);
                            break;
                        case HeatType.Warmer:
                            texture.SetPixel(x, y, Warmer);
                            break;
                        case HeatType.Warmest:
                            texture.SetPixel(x, y, Warmest);
                            break;
                    }
                    //darken the color if a edge tile
                    if ((int)tiles[x, y].HeightType > 2 && tiles[x, y].Bitmask != 15)
                    {
                        int red = (int)(texture.GetPixel(x, y).R * 0.4);
                        int green = (int)(texture.GetPixel(x, y).G * 0.4);
                        int blue = (int)(texture.GetPixel(x, y).B * 0.4);
                        texture.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }
            }
            return texture;
        }

        public static Bitmap GetMoistureMapTexture(int width, int height, Tile[,] tiles)
        {
            var texture = new Bitmap(width, height);

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    Tile t = tiles[x, y];

                    if (t.MoistureType == MoistureType.Dryest)
                        texture.SetPixel(x, y, Dryest);
                    else if (t.MoistureType == MoistureType.Dryer)
                        texture.SetPixel(x, y, Dryer);
                    else if (t.MoistureType == MoistureType.Dry)
                        texture.SetPixel(x, y, Dry);
                    else if (t.MoistureType == MoistureType.Wet)
                        texture.SetPixel(x, y, Wet);
                    else if (t.MoistureType == MoistureType.Wetter)
                        texture.SetPixel(x, y, Wetter);
                    else
                        texture.SetPixel(x, y, Wettest);
                    //darken the color if a edge tile
                    if ((int)tiles[x, y].HeightType > 2 && tiles[x, y].Bitmask != 15)
                    {
                        int red = (int)(texture.GetPixel(x, y).R * 0.4);
                        int green = (int)(texture.GetPixel(x, y).G * 0.4);
                        int blue = (int)(texture.GetPixel(x, y).B * 0.4);
                        texture.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }
            }
            return texture;
        }
        public static Bitmap GetBiomeMapTexture(int width, int height, Tile[,] tiles, float coldest, float colder, float cold)
        {
            var texture = new Bitmap(width, height);

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    BiomeType value = tiles[x, y].BiomeType;

                    switch (value)
                    {
                        case BiomeType.Ice:
                            texture.SetPixel(x, y, Ice);
                            break;
                        case BiomeType.BorealForest:
                            texture.SetPixel(x, y, BorealForest);
                            break;
                        case BiomeType.Desert:
                            texture.SetPixel(x, y, Desert);
                            break;
                        case BiomeType.Grassland:
                            texture.SetPixel(x, y, Grassland);
                            break;
                        case BiomeType.SeasonalForest:
                            texture.SetPixel(x, y, SeasonalForest);
                            break;
                        case BiomeType.Tundra:
                            texture.SetPixel(x, y, Tundra);
                            break;
                        case BiomeType.Savanna:
                            texture.SetPixel(x, y, Savanna);
                            break;
                        case BiomeType.TemperateRainforest:
                            texture.SetPixel(x, y, TemperateRainforest);
                            break;
                        case BiomeType.TropicalRainforest:
                            texture.SetPixel(x, y, TropicalRainforest);
                            break;
                        case BiomeType.Woodland:
                            texture.SetPixel(x, y, Woodland);
                            break;
                    }

                    // Water tiles
                    if (tiles[x, y].HeightType == HeightType.DeepWater)
                    {
                        texture.SetPixel(x, y, DeepColor);
                    }
                    else if (tiles[x, y].HeightType == HeightType.ShallowWater)
                    {
                        texture.SetPixel(x, y, ShallowColor);
                    }

                    // draw rivers
                    if (tiles[x, y].HeightType == HeightType.River)
                    {
                        float heatValue = tiles[x, y].HeatValue;

                        if (tiles[x, y].HeatType == HeatType.Coldest)
                        {
                            texture.SetPixel(x, y, MathHelper.ColorLerp((heatValue) / (coldest), IceWater, ColdWater));
                        }
                        else if (tiles[x, y].HeatType == HeatType.Colder)
                        {
                            texture.SetPixel(x, y, MathHelper.ColorLerp((heatValue - coldest) / (colder - coldest), ColdWater, RiverWater));
                        }
                        else if (tiles[x, y].HeatType == HeatType.Cold)
                        {
                            texture.SetPixel(x, y, MathHelper.ColorLerp((heatValue - colder) / (cold - colder), RiverWater, ShallowColor));
                        }
                        else
                        {
                            texture.SetPixel(x, y, ShallowColor);
                        }

                    }


                    // add a outline
                    if (tiles[x, y].HeightType >= HeightType.Shore && tiles[x, y].HeightType != HeightType.River)
                    {
                        if (tiles[x, y].BiomeBitmask != 15)
                            texture.SetPixel(x, y, MathHelper.ColorLerp(0.35f, texture.GetPixel(x, y), Color.Black));
                    }
                }
            }

            return texture;
        }

        public static Bitmap GetVintageMapTexture(int width, int height, Tile[,] tiles)
        {
            var texture = new Bitmap(width, height);

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    switch (tiles[x, y].HeightType)
                    {
                        case HeightType.DeepWater:
                            texture.SetPixel(x, y, VintageWater);
                            break;
                        case HeightType.ShallowWater:
                            texture.SetPixel(x, y, VintageWater);
                            break;
                        case HeightType.Sand:
                            texture.SetPixel(x, y, VintageLand);
                            break;
                        case HeightType.Grass:
                            texture.SetPixel(x, y, VintageLand);
                            break;
                        case HeightType.Forest:
                            texture.SetPixel(x, y, VintageLand);
                            break;
                        case HeightType.Rock:
                            texture.SetPixel(x, y, VintageLand);
                            break;
                        case HeightType.Snow:
                            texture.SetPixel(x, y, VintageLand);
                            break;
                        case HeightType.River:
                            texture.SetPixel(x, y, VintageWater);
                            break;
                    }

                    //darken the color if a edge tile
                    //if ((int)tiles[x, y].HeightType > 2 && tiles[x, y].Bitmask != 15)
                    //{
                    //    int red = (int)(texture.GetPixel(x, y).R * 0.4);
                    //    int green = (int)(texture.GetPixel(x, y).G * 0.4);
                    //    int blue = (int)(texture.GetPixel(x, y).B * 0.4);
                    //    texture.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    //}
                }
            }

            return texture;
        }

        #region Static legends
        public static Dictionary<string, Color> HeightLegend = new Dictionary<string, Color>
        {
            ["Deep Water"] = DeepColor,
            ["Shallow Water"] = ShallowColor,
            ["Sand"] = SandColor,
            ["Grass"] = GrassColor,
            ["Forest"] = ForestColor,
            ["Mountain"] = RockColor,
            ["Snow"] = SnowColor,
        };

        public static Dictionary<string, Color> HeatLegend = new Dictionary<string, Color>
        {
            ["-20°C"] = Coldest,
            ["-10°C"] = Colder,
            ["  0°C"] = Cold,
            [" 20°C"] = Warm,
            [" 30°C"] = Warmer,
        };

        public static Dictionary<string, Color> MoistureLegend = new Dictionary<string, Color>
        {
            [" 0%"] = Dryest,
            ["10%"] = Dryer,
            ["20%"] = Dry,
            ["40%"] = Wet,
            ["60%"] = Wetter,
            ["80%"] = Wettest,
        };
        #endregion
    }
}