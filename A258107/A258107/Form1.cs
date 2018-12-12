using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A258107
{
    public partial class Form1 : Form
    {
        Dictionary<long , string> base2List = new Dictionary<long, string>();
        Dictionary<long, string> base3List = new Dictionary<long, string>();
        Dictionary<long, string> base4List = new Dictionary<long, string>();
        Dictionary<long, string> base5List = new Dictionary<long, string>();
        Dictionary<long, string> base6List = new Dictionary<long, string>();

        List<long> base3UniqueNumbers = new List<long>();
        List<long> base4UniqueNumbers = new List<long>();
        List<long> base5UniqueNumbers = new List<long>();
        List<long> base6UniqueNumbers = new List<long>();

        public Form1()
        {
            InitializeComponent();

            int valCount = 82000;

            base2List = CalculateBase(2, valCount);
            base3List = CalculateBase(3, valCount);
            base4List = CalculateBase(4, valCount);
            base5List = CalculateBase(5, valCount);
            base6List = CalculateBase(6, valCount);

            for (int i = 2; i <= 6; i++)
            {
                dgvDisplay.Rows.Add();
                dgvDisplay.Rows[i - 2].Cells[0].Value = i.ToString();

                dgvDifference.Rows.Add();
                dgvDifference.Rows[i - 2].Cells[0].Value = i.ToString();
            }

            for (int i = 1; i <= valCount && i <= 654; i++)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                col.CellTemplate = new DataGridViewTextBoxCell();
                dgvDisplay.Columns.Add(col);
                dgvDisplay.Columns[i].HeaderCell.Value = i.ToString();
                
                if (base2List.Keys.Contains(i))
                {
                    dgvDisplay.Rows[0].Cells[i].Value = base2List[i].TrimStart('0');
                }

                if (base3List.Keys.Contains(i))
                {
                    dgvDisplay.Rows[1].Cells[i].Value = base3List[i].TrimStart('0');
                }

                if (base4List.Keys.Contains(i))
                {
                    dgvDisplay.Rows[2].Cells[i].Value = base4List[i].TrimStart('0');
                }

                if (base5List.Keys.Contains(i))
                {
                    dgvDisplay.Rows[3].Cells[i].Value = base5List[i].TrimStart('0');
                }
                if (base6List.Keys.Contains(i))
                {
                    dgvDisplay.Rows[4].Cells[i].Value = base6List[i].TrimStart('0');
                }

            }

            long lastVal = 0;
            long accumulatedEndValue = 0;
            foreach (long val in base3List.Keys)
            {
                accumulatedEndValue += (val - lastVal);
                if (!base3UniqueNumbers.Contains(val - lastVal))
                {
                    base3UniqueNumbers.Add(val - lastVal);
                    accumulatedEndValue = 0;
                }
                lastVal = val;
            }
            base3UniqueNumbers.Add(accumulatedEndValue);

            lastVal = 0;
            foreach (long val in base4List.Keys)
            {
                accumulatedEndValue += (val - lastVal);
                if (!base4UniqueNumbers.Contains(val - lastVal))
                {
                    base4UniqueNumbers.Add(val - lastVal);
                    accumulatedEndValue = 0;
                }
                lastVal = val;
            }
            base4UniqueNumbers.Add(accumulatedEndValue);

            lastVal = 0;
            foreach (long val in base5List.Keys)
            {
                accumulatedEndValue += (val - lastVal);
                if (!base5UniqueNumbers.Contains(val - lastVal))
                {
                    base5UniqueNumbers.Add(val - lastVal);
                    accumulatedEndValue = 0;
                }
                lastVal = val;
            }
            base5UniqueNumbers.Add(accumulatedEndValue);

            lastVal = 0;
            foreach (long val in base6List.Keys)
            {
                accumulatedEndValue += (val - lastVal);
                if (!base6UniqueNumbers.Contains(val - lastVal))
                {
                    base6UniqueNumbers.Add(val - lastVal);
                    accumulatedEndValue = 0;
                }
                lastVal = val;
            }
            base6UniqueNumbers.Add(accumulatedEndValue);

            for (int i = 0; i < base3UniqueNumbers.Count; i++)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                col.CellTemplate = new DataGridViewTextBoxCell();
                dgvDifference.Columns.Add(col);

                dgvDifference.Rows[0].Cells[i].Value = base3UniqueNumbers[i];
            }
            for (int i = 0; i < base4UniqueNumbers.Count; i++)
            {
                dgvDifference.Rows[1].Cells[i].Value = base4UniqueNumbers[i];
            }
            for (int i = 0; i < base5UniqueNumbers.Count; i++)
            {
                dgvDifference.Rows[2].Cells[i].Value = base5UniqueNumbers[i];
            }
            for (int i = 0; i < base6UniqueNumbers.Count; i++)
            {
                dgvDifference.Rows[3].Cells[i].Value = base6UniqueNumbers[i];
            }

        }

        private Dictionary<long, string> CalculateBase(int b , long highestVal)
        {
            int digitCount = 1;
            long val = b;
            string newBaseVal;
            long base10Val;
            long basePower;
            bool isBadNumber = false;
            List<char> badDigits = new List<char>();

            Dictionary<long, string> goodNumbers = new Dictionary<long, string>();

            for(int i = 2; i < b; i++)
            {
                badDigits.Add(i.ToString()[0]);
            }

            while ((val *= b) < highestVal)
            {
                digitCount++;
            }

            for(long i = 0; i <= highestVal; i++)
            {
                newBaseVal = "";
                base10Val = i;
                isBadNumber = false;
                for(int digitIndex = digitCount; digitIndex >= 0; digitIndex--)
                {
                    basePower = (long)Math.Pow(b, digitIndex);

                    long digit = (base10Val / basePower);
                    newBaseVal += digit;

                    if (digit > 0)
                    {
                        base10Val = base10Val % basePower;
                    }
                    
                }

                foreach(char c in badDigits)
                {
                    if(newBaseVal.Contains(c))
                    {
                        isBadNumber = true;
                        break;
                    }
                }

                if(!isBadNumber)
                {
                    goodNumbers.Add(i , newBaseVal);
                }                
            }

            return goodNumbers;
        }
    }
}
