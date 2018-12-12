using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recaman_Sequence
{
    public partial class Form1 : Form
    {

        float imgResulution = 4;
        float penWidth = 2;
        List<int> Sequence;

        public Form1()
        {
            InitializeComponent();
            Sequence = new List<int>();
            comboBoxResolution.SelectedIndex = 3;
            comboBoxPenWidth.SelectedIndex = 1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int sequenceCount;
            if(int.TryParse(tbSequenceCount.Text , out sequenceCount))
            {
                imgResulution = float.Parse(comboBoxResolution.SelectedItem.ToString());
                penWidth = float.Parse(comboBoxPenWidth.SelectedItem.ToString());
                DrawRecamanSequence(sequenceCount);
                btnAdd.Enabled = true;
            }
        }

        private void DrawRecamanSequence(int count)
        {
            Sequence.Clear();
            Sequence = new List<int>();
            int currentVal = 0 , nextVal;
            int maxJump = 0, maxVal = 0;

            Sequence.Add(currentVal);

            for (int i = 0; i < count; i++)
            {
                nextVal = currentVal - (i + 1);
                if(nextVal < 0 || Sequence.Contains(nextVal))
                {
                    nextVal = currentVal + (i + 1);
                }

                if(Math.Abs(nextVal - currentVal) > maxJump)
                {
                    maxJump = Math.Abs(nextVal - currentVal);
                }

                if(nextVal > maxVal)
                {
                    maxVal = nextVal;
                }

                Sequence.Add(nextVal);
                currentVal = nextVal;
                tbSequence.Text += nextVal.ToString() + ", ";
            }
            
            Bitmap img = new Bitmap((int)(maxVal * imgResulution), (int)(maxJump*2 * imgResulution));
            using (Graphics g = Graphics.FromImage(img))
            {
                using (Pen pen = new Pen(pnlForeColor.BackColor))
                {
                    g.FillRectangle(new SolidBrush(pnlBackColor.BackColor), 0, 0, img.Width, img.Height);

                    pen.Width = penWidth;
                    g.DrawLine(pen, 0, maxJump * imgResulution, maxVal * imgResulution, maxJump * imgResulution);


                    for (int i = 1; i < count; i++)
                    {
                        int xMin = (int)(Math.Min(Sequence[i - 1], Sequence[i]) * imgResulution);
                        int xMax = (int)(Math.Max(Sequence[i - 1], Sequence[i]) * imgResulution);
                        int y = (int)(maxJump * imgResulution);
                        int width = Math.Abs(xMax - xMin);
                        int height = width;
                        int startAngle = 0;
                        int endAngle = 180;

                        y -= width / 2;

                        if (height == 0) continue;

                        if (i % 2 == 0)
                        {
                            startAngle = 180;
                            endAngle = 180;
                        }

                        Rectangle rect = new Rectangle(xMin, y, width, height);

                        g.DrawArc(pen, rect, startAngle, endAngle);
                    }
                }                   
            }              

            pbSequence.Image = img;    

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int sequenceCount;
            if (int.TryParse(tbSequenceCount.Text, out sequenceCount))
            {
                sequenceCount += 1;
                tbSequenceCount.Text = sequenceCount.ToString();
                DrawRecamanSequence(sequenceCount);
            }
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                pnlBackColor.BackColor = cd.Color;
            }
        }

        private void btnForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                pnlForeColor.BackColor = cd.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(pbSequence.Image != null)
            {
                string path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                path = Path.Combine(path, "Downloads");
                pbSequence.Image.Save( Path.Combine( path , "RecamanSequence_" + (Sequence.Count - 1).ToString()+".jpeg"));
            }
        }
    }
}
