using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicReader
{
    public partial class FormDBViewer : Form
    {
        public FormDBViewer()
        {
            InitializeComponent();
        }

        private void comboBoxDBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxDBSelect.SelectedIndex)
            {
                case 1:
                    
                    break;
                case 2:
                    this.cardsTableAdapter.Fill(this.dBDataSet.Cards);
                    break;
                case 3:
                    //this.cardsTableAdapter.Fill(this.dBDataSet.Cards);
                    break;
                default:
                    break;

            }
        }

        private void FormDBViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBDataSet.Cards' table. You can move, or remove it, as needed.
            //this.cardsTableAdapter.Fill(this.dBDataSet.Cards);

        }
    }
}
