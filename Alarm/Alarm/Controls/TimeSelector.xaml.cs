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

        /// <summary>
        /// Returns the set hours as an integer
        /// </summary>
        /// <returns></returns>
        public int GetHour()
        {
            return Convert.ToInt32(txtHour.Text);
        }

        /// <summary>
        /// Returns the set minutes as an integer
        /// </summary>
        /// <returns></returns>
        public int GetMin()
        {
            return Convert.ToInt32(txtMin.Text);
        }

        /// <summary>
        /// Returns the set period whether the time is set to AM or PM
        /// </summary>
        /// <returns></returns>
        public string GetPeriod()
        {
            return cmbPeriod.SelectedItem.ToString();
        }

        /// <summary>
        /// Sets the time in time select control
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="min"></param>
        /// <param name="period"></param>
        public void SetTime(int hour, int min, string period)
        {
            txtHour.Text = hour.ToString();
            txtMin.Text = min.ToString();
            
            if (period == "AM")
            {
                cmbPeriod.SelectedIndex = 0;
            }
            else
            {
                cmbPeriod.SelectedIndex = 1;
            }

        }

        /// <summary>
        /// Resets the selected time to 7:00 am
        /// <remarks> I have decided to make the default time to 7:00 AM on reset</remarks>
        /// </summary>
        public void ResetControl()
        {
            hourHasFocus = true;
            txtHour.Text = "7";
            txtMin.Text = "00";
            cmbPeriod.SelectedIndex = 0; // Set period to AM
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

        /// <summary>
        /// Used to verify that, as time is input, that it is valid, also to allow the use of the
        /// arrow pad to move the hours up and down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHour_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (IsKeyADigit(e.Key))
            {
                string curHour = txtHour.Text;
                int carIndex = txtHour.CaretIndex;
                string pendingHour = curHour.Insert(carIndex, getKeyPressed(e.Key));

                int pendingIntHour = Convert.ToInt32(pendingHour);
                if (pendingIntHour >= 0 && pendingIntHour <= 12)
                {
                    txtHour.Text = pendingIntHour.ToString();
                }
                e.Handled = true;
            }
            else if (IsKeyAChar(e.Key))
            {
                e.Handled = true;
            }
            else
            {
                if (e.Key == Key.Down)
                {
                    btnDown_Click("TxtHour_KeyDown", e);
                }

                if (e.Key == Key.Up)
                {
                    btnUp_Click("TxtHour_KeyDown", e);
                }
            }
        }

        /// <summary>
        /// Used to verify that, as time is input, that it is valid, also to allow the use of the
        /// arrow pad to move the minutes up and down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (IsKeyADigit(e.Key))
            {
                string curMin = txtMin.Text;
                string pendingMin = curMin.Insert(txtMin.CaretIndex, getKeyPressed(e.Key));
                
                int pendingIntMin = Convert.ToInt32(pendingMin);
                if (pendingIntMin >= 0 && pendingIntMin <= 59)
                {
                    txtMin.Text = pendingIntMin.ToString("D2");
                }
                e.Handled = true;
            }
            else if(IsKeyAChar(e.Key))
            {
                e.Handled = true;
            }
            else
            {
                if (e.Key == Key.Down)
                {
                    btnDown_Click("TxtHour_KeyDown", e);
                }

                if (e.Key == Key.Up)
                {
                    btnUp_Click("TxtHour_KeyDown", e);
                }
            }
        }

        /// <summary>
        /// used to check if key that was pressed was alphabit
        /// </summary>
        /// <param name="keyPressed"></param>
        /// <returns></returns>
        private static bool IsKeyAChar(Key keyPressed)
        {
            return keyPressed >= Key.A && keyPressed <= Key.Z;
        }

        /// <summary>
        /// used to check if key that was pressed was digit either on keyboard or
        /// number pad
        /// </summary>
        /// <param name="keyPressed"></param>
        /// <returns></returns>
        private static bool IsKeyADigit(Key keyPressed)
        {
            return (keyPressed >= Key.D0 && keyPressed <= Key.D9) || 
                    (keyPressed >= Key.NumPad0 && keyPressed <= Key.NumPad9);
        }

        /// <summary>
        /// Turns Key Class into a string with the correct item in it for letters and numbers
        /// </summary>
        /// <param name="keyPressed"></param>
        /// <returns></returns>
        private static string getKeyPressed(Key keyPressed)
        {
            string keyCodeString = keyPressed.ToString();
            string key = "";
            if (keyCodeString.Length == 1)
            {
                key = keyCodeString[0].ToString();
            }
            else
            {
                if (keyCodeString.StartsWith("NumPad") || keyCodeString[0] == 'D')
                {
                    key = keyCodeString[keyCodeString.Length - 1].ToString();
                }
            }

            return key;
        }
    }
}
