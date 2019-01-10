using System;
using System.Drawing;

namespace MapGenerator
{
    public class MapData
    {

        public float[,] Data;
        public float Min { get; set; }
        public float Max { get; set; }

        public MapData(int width, int height)
        {
            Data = new float[width, height];
            Min = float.MaxValue;
            Max = float.MinValue;
        }

        public MapData(MapData md)
        {
            Data = new float[md.Data.GetLength(0), md.Data.GetLength(1)];
            Array.Copy(md.Data, Data, md.Data.Length);
            Min = md.Min;
            Max = md.Max;
        }
    }

    public class HeightMapping
    {
        public int TerrainOctaves = 6;
        public double TerrainFrequency = 1.25;
        public float Scale;
        public float DeepWater;     // 0.2f
        public float ShallowWater;  // 0.4f
        public float Sand;          // 0.5f
        public float Grass;         // 0.7f
        public float Forest;        // 0.8f
        public float Rock;          // 0.9f

        public HeightMapping() : this(0.4f) { }
        public HeightMapping(float scale)
        {
            if (scale >= 1.0f || scale <= 0.0f)
            {
                scale = 0.4f;
            }
            Scale = scale;
            DeepWater = 0.5f * scale;
            ShallowWater = scale;
            Sand = 0.8333f * scale + 0.1667f;
            Grass = 0.5f * scale + 0.5f;
            Forest = 0.3333f * scale + 0.6667f;
            Rock = 0.1667f * scale + 0.8333f;
        }
    }

    public class HeatMapping
    {

        public int HeatOctaves = 4;
        public double HeatFrequency = 3.0;
        public float Scale;
        public float ColdestValue;          // 0.1f (0.05f)
        public float ColderValue;           // 0.2f (0.18f)
        public float ColdValue;             // 0.4f;
        public float WarmValue;             // 0.6f;
        public float WarmerValue;           // 0.8f;

        public HeatMapping() :this(0.4f){ }
        public HeatMapping(float scale)
        {
            if(scale >= 1.0f || scale <= 0.0f)
            {
                scale = 0.4f;
            }
            Scale = scale;
            ColdestValue = 0.25f * scale;
            ColderValue = 0.5f * scale;
            ColdValue = scale;
            WarmValue = 0.6667f * scale + 0.3333f;
            WarmerValue = 0.3333f * scale + 0.6667f;

        }
    }

    public class MoistureMapping
    {
        public int MoistureOctaves = 4; 
        public double MoistureFrequency = 3.0;
        public float Scale;
        public float DryerValue;            // 0.3f at default
        public float DryValue;              // 0.4f at default
        public float WetValue;              // 0.6f at default
        public float WetterValue;           // 0.8f at default
        public float WettestValue;          // 0.9f at default

        public MoistureMapping() : this(0.4f){ }
        public MoistureMapping(float scale)
        {
            Scale = scale;
            DryerValue = 0.75f * scale;
            DryValue = scale;
            WetValue = 0.6667f * scale + 0.3333f;
            WetterValue = 0.3333f * scale + 0.6667f;
            WettestValue = 0.1667f * scale + 0.8333f;
        }
    }
}