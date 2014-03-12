using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DPS_Calculator
{
    public partial class MainWindow : Window
    {
        DPSViewModel viewModel;
        MainWindow window;

        public MainWindow()
        {
            InitializeComponent();
            window = this;
            viewModel = (DPSViewModel)base.DataContext;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DPSEC = 0;
            viewModel.DPSECQ = 0;
            viewModel.PDPSEC = 0;
            viewModel.PDPSECQ = 0;
        }
    }
}
