using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace GameTheory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ColosseumViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = DataContext as ColosseumViewModel;
        }

        private void BtnCompete_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                _vm.Compete();
            });            
        }
        private void BtnDiscoverContestants_Click(object sender, RoutedEventArgs e)
        {
            _vm.DiscoverContestants("D:\\Source\\Github\\GameTheory\\bin\\Debug\\net6.0");            
            //_vm.DiscoverContestants(Environment.CurrentDirectory);
        }
        
    }
}
