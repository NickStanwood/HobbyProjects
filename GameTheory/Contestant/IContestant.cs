namespace Contestant
{
    public interface IContestant
    {
        public string Name { get; }
        public bool Compete();
        public void LearnResults(bool myCooperated, bool otherCooperated);
    }
}