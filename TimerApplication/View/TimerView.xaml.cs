using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TimerApplication.View
{
    /// <summary>
    /// Interaction logic for TimerView.xaml
    /// </summary>
    public partial class TimerView : UserControl
    {
        public TimeSpan defaultValue = TimeSpan.FromSeconds(3600);
        public TimeSpan runningTime, currentTime;
        public DispatcherTimer dispatcherTimer;

        bool isStartTimer;

        public TimerView()
        {
            InitializeComponent();
            runningTime = defaultValue;
            isStartTimer = false;
            SetUpDispatcherTimer();
        }

        private void SetUpDispatcherTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        }

        private void Timer(bool isStart)
        {
            if (isStart)
            {
                dispatcherTimer.Tick += (s, e) =>
                {
                    if (runningTime == TimeSpan.Zero || !isStart)
                    {
                        dispatcherTimer.Stop();
                        TimeUp();
                        return;
                    }
                    else
                    {
                        runningTime = runningTime.Add(TimeSpan.FromSeconds(-1));
                        lbl_Clock.Content = runningTime.ToString();
                    }
                };
                dispatcherTimer.Start();
            }
            else
            {
                dispatcherTimer.Tick += (s, e) => { runningTime = runningTime.Add(TimeSpan.FromSeconds(1)); };
                dispatcherTimer.Stop();
            }
        }

        private void TimeUp()
        {
            MessageBox.Show("Time is up!");
            isStartTimer = false;
            btn_StartStop.Background = Brushes.LightGreen;
            btn_StartStop.Content = "Start";
            runningTime = currentTime;
            lbl_Clock.Content = runningTime.ToString();
        }

        private void TriggerTimer()
        {
            if (!isStartTimer)
            {
                btn_StartStop.Background = Brushes.OrangeRed;
                btn_StartStop.Content = "Stop";
                isStartTimer = true;
                Timer(true);
            }
            else
            {
                btn_StartStop.Background = Brushes.LightGreen;
                btn_StartStop.Content = "Start";
                isStartTimer = false;
                Timer(false);
            }
        }

        private void btn_StartStop_Click(object sender, RoutedEventArgs e)
        {
            TriggerTimer();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_SetTimer_Click(object sender, RoutedEventArgs e)
        {
            double hour = !string.IsNullOrEmpty(txt_Hour.Text) ? double.Parse(txt_Hour.Text) : 0;
            double minute = !string.IsNullOrEmpty(txt_Minute.Text) ? double.Parse(txt_Minute.Text) : 0;
            double second = !string.IsNullOrEmpty(txt_Second.Text) ? double.Parse(txt_Second.Text) : 0;

            currentTime = TimeSpan.FromSeconds(hour * 60 * 60 + minute * 60 + second);
            runningTime = currentTime;
            lbl_Clock.Content = runningTime.ToString();
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            runningTime = currentTime;
            lbl_Clock.Content = runningTime.ToString();
        }
    }
}
