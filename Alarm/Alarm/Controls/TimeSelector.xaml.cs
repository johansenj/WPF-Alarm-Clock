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
    /// Interaction logic for TimeSelector.xaml
    /// </summary>
    public partial class TimeSelector : UserControl
    {
        private bool hourHasFocus = true;

        public TimeSelector()
        {
            InitializeComponent();
        }

        public string DisplayTime
        {
            get
            {
                return "";
            }
            set
            {

            }
        }

        /// <summary>
        /// Used to verify that, as time is input, that it is valid, also to allow the use of the
        /// arrow pad to move the hours up and down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtHour_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Used to verify that, as time is input, that it is valid, also to allow the use of the
        /// arrow pad to move the minutes up and down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMin_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// Used to keep track of which text box last had focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMin_GotFocus(object sender, RoutedEventArgs e)
        {
            hourHasFocus = false;
        }

        /// <summary>
        /// Used to keep track of which text box last had focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHour_GotFocus(object sender, RoutedEventArgs e)
        {
            hourHasFocus = true;
        }

        /// <summary>
        /// Used to move the hour or min up depending on which was last selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hourHasFocus)
                {
                    int workingHour = Convert.ToInt32(txtHour.Text);
                    if (workingHour == 12)
                    {
                        workingHour = 1;
                    }
                    else
                    {
                        workingHour++;
                    }
                    txtHour.Text = workingHour.ToString();
                }
                else
                {
                    int workingHour = Convert.ToInt32(txtMin.Text);
                    if (workingHour == 59)
                    {
                        workingHour = 1;
                    }
                    else
                    {
                        workingHour++;
                    }
                    txtMin.Text = workingHour.ToString("D2");
                }
            }
            catch (Exception)
            {
                //TODO: Out put to log in user directory so users can send any errors to me if needed
            }
            
        }

        /// <summary>
        /// Used to move the hour or min down depending on which was last selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hourHasFocus)
                {
                    int workingHour = Convert.ToInt32(txtHour.Text);
                    if (workingHour == 1)
                    {
                        workingHour = 12;
                    }
                    else
                    {
                        workingHour--;
                    }
                    txtHour.Text = workingHour.ToString();
                }
                else
                {
                    int workingHour = Convert.ToInt32(txtMin.Text);
                    if (workingHour == 0)
                    {
                        workingHour = 59;
                    }
                    else
                    {
                        workingHour--;
                    }
                    txtMin.Text = workingHour.ToString("D2");
                }
            }
            catch (Exception)
            {
                //TODO: Out put to log in user directory so users can send any errors to me if needed
            }
        }


    }
}
