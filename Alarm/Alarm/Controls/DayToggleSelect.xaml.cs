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

namespace Alarm
{
    /// <summary>
    /// Interaction logic for DayToggleSelect.xaml
    /// </summary>
    public partial class DayToggleSelect : UserControl
    {
        public DayToggleSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets all toggle buttons to "off"
        /// </summary>
        public void resetControl()
        {
            tbSun.IsChecked = false;
            tbMon.IsChecked = false;
            tbTue.IsChecked = false;
            tbWed.IsChecked = false;
            tbThu.IsChecked = false;
            tbFri.IsChecked = false;
            tbSat.IsChecked = false;
        }

        /// <summary>
        /// Used to get and set selected days, is returned as comma seperated string
        /// </summary>
        public string SelectedDays
        {
            get
            {
                string selected = "";
                int totalDaysSelected = 0;

                if ((bool)tbSun.IsChecked)
                {
                    selected += "Sun,";
                    totalDaysSelected++;
                }
                if ((bool)tbMon.IsChecked)
                {
                    selected += "Mon,";
                    totalDaysSelected++;
                }
                if ((bool)tbTue.IsChecked)
                {
                    selected += "Tue,";
                    totalDaysSelected++;
                }
                if ((bool)tbWed.IsChecked)
                {
                    selected += "Wed,";
                    totalDaysSelected++;
                }
                if ((bool)tbThu.IsChecked)
                {
                    selected += "Thu,";
                    totalDaysSelected++;
                }
                if ((bool)tbFri.IsChecked)
                {
                    selected += "Fri,";
                    totalDaysSelected++;
                }
                if ((bool)tbSat.IsChecked)
                {
                    selected += "Sat,";
                    totalDaysSelected++;
                }

                if (totalDaysSelected == 7)
                {
                    selected = "Every Day";
                }
                else if (totalDaysSelected == 2 && (bool)tbSun.IsChecked && (bool)tbSat.IsChecked)
                {
                    selected = "Weekend";
                }
                else if (totalDaysSelected == 5 && !(bool)tbSun.IsChecked && !(bool)tbSat.IsChecked)
                {
                    selected = "Weekdays";
                }
                return selected;
            }

            set
            {
                bool everyday = value.Contains("Every Day");
                bool weekend = value.Contains("Weekend");
                bool weekdays = value.Contains("Weekdays");
                bool sun = everyday || weekend || value.Contains("Sun");
                bool mon = everyday || weekdays || value.Contains("Mon");
                bool tue = everyday || weekdays || value.Contains("Tue");
                bool wed = everyday || weekdays || value.Contains("Wed");
                bool thu = everyday || weekdays || value.Contains("Thu");
                bool fri = everyday || weekdays || value.Contains("Fri");
                bool sat = everyday || weekend || value.Contains("Sat");

                resetControl();

                if (sun)
                {
                    tbSun.IsChecked = true;
                }
                if (mon)
                {
                    tbMon.IsChecked = true;
                }
                if (tue)
                {
                    tbTue.IsChecked = true;
                }
                if (wed)
                {
                    tbWed.IsChecked = true;
                }
                if (thu)
                {
                    tbThu.IsChecked = true;
                }
                if (fri)
                {
                    tbFri.IsChecked = true;
                }
                if (sat)
                {
                    tbSat.IsChecked = true;
                }
            }
        }
    }
}
