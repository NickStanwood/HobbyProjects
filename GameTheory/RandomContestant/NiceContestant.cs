using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contestant;

namespace BasicContestants
{
    public class NiceContestant : IContestant
    {
        public string Name { get => "Happy Camper"; }

        public bool Compete()
        {
            return true;
        }

        public void LearnResults(bool myCooperated, bool otherCooperated)
        {

        }
    }
}
