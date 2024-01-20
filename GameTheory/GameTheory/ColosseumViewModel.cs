using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using Contestant;

namespace GameTheory
{
    public class ColosseumViewModel : INotifyPropertyChanged
    {
        IContestant _player1;
        IContestant _player2;
        public IContestant Player1 { get { return _player1; } set { _player1 = value; Notify(); Notify(nameof(CanCompete)); } }
        public IContestant Player2 { get { return _player2; } set { _player2 = value; Notify(); Notify(nameof(CanCompete)); } }
        public ObservableCollection<bool> Player1Cooperated { get; set; } = new ObservableCollection<bool>();
        public ObservableCollection<bool> Player2Cooperated { get; set; } = new ObservableCollection<bool>();
        public ObservableCollection<IContestant> Contestants { get; set; } = new ObservableCollection<IContestant>();

        private double _player1Score;
        private double _player2Score;
        public double Player1Score { get { return _player1Score; } set { _player1Score = value; Notify(); } }
        public double Player2Score { get { return _player2Score; } set { _player2Score = value; Notify(); } }

        public bool CanCompete { get { return _player1 != null && _player2 != null && !_competing; } }
        private bool _competing = false;

        private object _player1Lock = new object();
        private object _player2Lock = new object();
        public ColosseumViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(Player1Cooperated, _player1Lock);
            BindingOperations.EnableCollectionSynchronization(Player2Cooperated, _player2Lock);
        }

        public void DiscoverContestants(string dir)
        {
            Contestants.Clear();
            DirectoryInfo di = new DirectoryInfo(dir);
            foreach(FileInfo fi in di.GetFiles())
            {
                if(fi.Extension == ".dll")
                {
                    Assembly assem = Assembly.LoadFrom(fi.FullName);
                    Type[] types = assem.GetTypes();
                    foreach (Type t in types)
                    {
                        if(t.GetInterfaces().Contains(typeof(IContestant)) && !t.IsInterface)
                        {
                            IContestant? player = Activator.CreateInstance(t) as IContestant;
                            if(player != null)
                                Contestants.Add(player);
                        }
                    }
                }
            }
        }

        public void Compete()
        {
            if (Player1 == null || Player2 == null)
                return;

            _competing = true;
            Notify(nameof(CanCompete));

            Player1Cooperated.Clear();
            Player2Cooperated.Clear();
            double p1CumScore = 0;
            double p2CumScore = 0;

            Random r = new Random();
            //int rounds = r.Next(240, 260);
            int rounds = 20;
            for (int i = 0; i < rounds; i++)
            {
                bool p1Coop = Player1.Compete();
                bool p2Coop = Player2.Compete();

                Player1Cooperated.Add(p1Coop);
                Player2Cooperated.Add(p2Coop);

                Player1.LearnResults(p1Coop, p2Coop);
                Player2.LearnResults(p2Coop, p1Coop);

                if (p1Coop && p2Coop)
                {
                    p1CumScore += 3;
                    p2CumScore += 3;
                }
                else if(p1Coop && !p2Coop)
                {
                    p2CumScore += 5;
                }
                else if(!p1Coop && p2Coop)
                {
                    p1CumScore += 5;
                }
                else
                {
                    p1CumScore += 1;
                    p2CumScore += 1;
                }

                Player1Score = p1CumScore / (i + 1);
                Player2Score = p2CumScore / (i + 1);
                Thread.Sleep(50);
            }

            _competing = false;
            Notify(nameof(CanCompete));
        }

        private void Notify([CallerMemberName] string prop = null)
        {
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(prop);
            PropertyChanged?.Invoke(this, e);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
