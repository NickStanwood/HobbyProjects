using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator
{
    public class ProgressEventArgs : EventArgs
    {
        public int Percent { get; }
        public string Process { get; }
        public ProgressEventArgs(int per , string proc)
        {
            Percent = per;
            Process = proc;
        }
    }
    public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);
}
