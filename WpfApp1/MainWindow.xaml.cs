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
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProcessesView.ItemsSource = Process.GetProcesses();
        }

        private void ProcessInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProcessesView.SelectedItem is null) return;

            var process = (Process)ProcessesView.SelectedItem;
            Threads.ItemsSource = process.Threads;
            try
            {
                Modules.ItemsSource = process.Modules;
            }
            catch
            {

            }

        }
    }
}
