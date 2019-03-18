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
using System.Windows.Threading;

namespace Property_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        int count = 0;
        Warning bingoFuelWarning;

        public MainWindow()
        {
            InitializeComponent();
            
            dispatcherTimer1.Tick += new EventHandler(dispatcherTimer1_Tick);
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            Connect();
        }

        public void Connect()
        {
            bingoFuelWarning = new Warning();
            dispatcherTimer1.Start();
        }
        
        private void dispatcherTimer1_Tick(object sender, EventArgs e)
        {
            count++;
            textBlock_timer.Text = $"{count}";
            textBlock_content.Text = $"bingoFuelWarning_count: {bingoFuelWarning.bingoFuelWarning_count} | nextBingoFuelWarning: {bingoFuelWarning.nextBingoFuelWarning}";
            if (count >= 10 && count < 15)
            {
                bingoFuelWarning.bingoFuelWarning_count++;
            }
            if (count == 20)
            {
                dispatcherTimer1.Stop();
                count = 0;
                Connect();
            }
        }
    }

    public class Warning
    {
        int _bingoFuelWarning_count = 0;
        int _nextBingoFuelWarning = -1;

        public int bingoFuelWarning_count
        {
            get => _bingoFuelWarning_count;
            set => _bingoFuelWarning_count = value;
        }

        public int nextBingoFuelWarning
        {
            get => _nextBingoFuelWarning;
            set => _nextBingoFuelWarning = value;
        }
    }
}
