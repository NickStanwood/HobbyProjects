using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapGenerator;

namespace MapGeneratorTest
{
    public partial class FormMapTest : Form
    {
        MapDesigner MapGen;
        private int pictureIndex;
        private static int numMaps = 5;
        
        private HeightData HD = new HeightData();
        private HeatData TD = new HeatData();
        private MoistureData MD = new MoistureData();               

        private int MapHeight;
        private int MapWidth;

        bool IsDragging = false;
        bool IsZooming = false;
        float Zoom = 1.0f;

        #region Debugging variables
        Stopwatch GetDataStopWatch;
        #endregion

        public FormMapTest()
        {
            InitializeComponent();

            MapGen = new MapDesigner();
            GetDataStopWatch = new Stopwatch();
            pictureIndex = 0;

            MapGen.ProgressBarUpdate += MapGen_ProgressBarUpdate;
            MapGen.MapsUpdate += MapGen_MapsUpdate;
            SetResolution();
        }

        private void SetResolution()
        {
            switch (trackBarResolution.Value)
            {
                case 0:
                    MapHeight = 128;
                    MapWidth = 128;
                    break;
                case 1:
                    MapHeight = 256;
                    MapWidth = 256;
                    break;
                case 2:
                    MapHeight = 512;
                    MapWidth = 512;
                    break;
                case 3:
                    MapHeight = 1024;
                    MapWidth = 1024;
                    break;
                case 4:
                    MapHeight = 2048;
                    MapWidth = 2048;
                    break;
            }
        }

        private void SetNewMap()
        {
            switch (pictureIndex)
            {
                case 0:
                    pbMap.Image = MapGen.HeightMap;
                    break;
                case 1:
                    pbMap.Image = MapGen.HeatMap;
                    break;
                case 2:
                    pbMap.Image = MapGen.MoistureMap;
                    break;
                case 3:
                    pbMap.Image = MapGen.VintageMap;
                    break;
                case 4:
                    pbMap.Image = MapGen.BiomeMap;
                    break;
                default:
                    break;
            }
        }

        private void MapGen_MapsUpdate(object sender, EventArgs e)
        {
            SetNewMap();
        }

        private void MapGen_ProgressBarUpdate(object sender, ProgressEventArgs e)
        {
            progressBar1.Value = e.Percent;
            textBox1.Text = e.Process + "   " + e.Percent.ToString() + "%";
            if(e.Percent == 42)
            {
                GetDataStopWatch.Stop();
                lblGetDataTime.Text = "Get Data Time: " + GetDataStopWatch.Elapsed.ToString(@"ss\.ffff") + " s";
                lblGetDataTime.Update();
            }
            progressBar1.Update();
            textBox1.Update();
        }

        private void btnCreateNewMap_Click(object sender, EventArgs e)
        {
            lblHeatScale.Text = "Heat: " + ((float)trackBarCold.Value / 100.0f).ToString();
            lblMoistureScale.Text = "Moisture: " + ((float)trackBarDry.Value / 100.0f).ToString();
            lblWaterScale.Text = "Water: " + ((float)trackBarWater.Value / 100.0f).ToString();

            GetDataStopWatch.Restart();

            btnUpdateMap.Enabled = false;
            MapGen.GenerateNew(MapWidth, MapWidth);

            btnUpdateMap.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pictureIndex++;
            if (pictureIndex > numMaps) { pictureIndex = 0; }
            SetNewMap();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            pictureIndex--;
            if(pictureIndex < 0) { pictureIndex = numMaps; }
            SetNewMap();
        }
        
        private void btnUpdateMap_Click(object sender, EventArgs e)
        {
            lblHeatScale.Text = "Heat: " + ((float)trackBarCold.Value / 100.0f).ToString();
            lblMoistureScale.Text = "Moisture: " + ((float)trackBarDry.Value / 100.0f).ToString();
            lblWaterScale.Text = "Water: " + ((float)trackBarWater.Value / 100.0f).ToString();

            MapGen.UpdateMap((float)trackBarWater.Value / 100.0f, (float)trackBarCold.Value / 100.0f, (float)trackBarDry.Value / 100.0f);
            SetNewMap();
        }

        private void trackBarResolution_Scroll(object sender, EventArgs e)
        {
            SetResolution();
            string res = MapHeight.ToString() + " x " + MapWidth.ToString();
            labelResolution.Text = "Resolution " + res;
            btnUpdateMap.Enabled = (res == MapGen.Resolution);
        }
        
        private void pbMap_MouseDownDrag(object sender, MouseEventArgs e)
        {
            MapGen.StartDrag();
        }

        private void pbMap_MouseUpDrag(object sender, MouseEventArgs e)
        {
            MapGen.EndDrag();
        }
        
        private void btnDrag_Click(object sender, EventArgs e)
        {
            if(IsZooming)
            {
                IsZooming = false;
                pbMap.MouseClick -= pbMap_MouseClickZoom;
                btnZoom.Text = "Zoom";
            }

            if(!IsDragging)
            {
                IsDragging = true;
                pbMap.MouseUp += pbMap_MouseUpDrag;
                pbMap.MouseDown += pbMap_MouseDownDrag;
                btnDrag.Text = "Stop Drag";
            }
            else
            {
                IsDragging = false;
                pbMap.MouseUp -= pbMap_MouseUpDrag;
                pbMap.MouseDown -= pbMap_MouseDownDrag;
                btnDrag.Text = "Drag";
            }
        }

        private void pbMap_MouseClickZoom(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {   //Zoom in
                Zoom *= 2.0f;
                Zoom = Math.Min(Zoom, 8.0f);
                MapGen.Zoom(e.X, e.Y, Zoom);
            }
            else
            {   //Zoom out
                Zoom *= 0.5f;
                Zoom = Math.Max(Zoom, 1.0f);
                MapGen.Zoom(e.X, e.Y, Zoom);
            }
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {   
            if(IsDragging)
            {
                IsDragging = false;
                pbMap.MouseUp -= pbMap_MouseUpDrag;
                pbMap.MouseDown -= pbMap_MouseDownDrag;
                btnDrag.Text = "Drag";
            }

            if (!IsZooming)
            {
                IsZooming = true;
                pbMap.MouseClick += pbMap_MouseClickZoom;
                btnZoom.Text = "Stop Zoom";
            }
            else
            {
                IsZooming = false;
                pbMap.MouseClick -= pbMap_MouseClickZoom;
                btnZoom.Text = "Zoom";
            }
        }
    }
}
