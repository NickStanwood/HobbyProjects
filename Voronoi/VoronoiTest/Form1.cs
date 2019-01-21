using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Voronoi;

namespace VoronoiTest
{
    public partial class Form1 : Form
    {
        VoronoiDiagram Diagram;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            int imgSize, numSeeds;

            if(int.TryParse(tbImgSize.Text , out imgSize) && int.TryParse(tbSeedCount.Text , out numSeeds))
            {
                Diagram = new VoronoiDiagram(imgSize , numSeeds , 1);
                pbVoronoiDiagram.Image = Diagram.CreateImage();
            }
            else
            {
                tbSeedCount.Text = "";
                tbImgSize.Text = "";
            }
        }

        private void btnGrow_Click( object sender, EventArgs e )
        {
            Diagram.GrowSeeds();
            pbVoronoiDiagram.Image = Diagram.CreateImage();
        }
    }
}
