using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contestant;

namespace BasicContestants
{
    public class NastyContestant : IContestant
    {
        public string Name { get => "Grumpy Guts"; }

        public bool Compete()
        {
            return false;
        }

        public void LearnResults(bool myCooperated, bool otherCooperated)
        {

        }
    }
}
