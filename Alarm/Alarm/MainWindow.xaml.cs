using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Alarm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer TimerSP;
        public MainWindow()
        {
            TimerSP = new DispatcherTimer();
            TimerSP.Interval = new TimeSpan(0, 0, 1);
            TimerSP.Tick += new EventHandler(TimerSP_Tick);

            InitializeComponent();
            TimerSP.Start();
        }

        private void TimerSP_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblTime.Content = now.ToString("t");
            lblDate.Content = now.ToString("D");
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnAddAlarm_Click(object sender, RoutedEventArgs e)
        {
            grdAlarmList.Visibility = System.Windows.Visibility.Hidden;
            grdAddAlarm.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnCancleEditAlarm_Click(object sender, RoutedEventArgs e)
        {
            grdAddAlarm.Visibility = System.Windows.Visibility.Hidden;
            grdAlarmList.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnAppExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

