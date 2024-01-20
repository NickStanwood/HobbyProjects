using Contestant;

namespace BasicContestants
{
    public class RandomContestant : IContestant
    {
        public string Name { get => "Randomizer"; }

        public bool Compete()
        {
            Random random = new Random();
            double val = random.NextDouble();

            return val > 0.5;
        }

        public void LearnResults(bool myCooperated, bool otherCooperated)
        {
            
        }
    }
}