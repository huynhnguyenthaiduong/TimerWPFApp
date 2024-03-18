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

namespace TimerApplication.View
{
    /// <summary>
    /// Interaction logic for ClockView.xaml
    /// </summary>
    public partial class ClockView : UserControl
    {
        DispatcherTimer dispatcherTimer;

        public ClockView()
        {
            InitializeComponent();

            SetDateTimeInfo();

            Clock();
        }

        private void SetDateTimeInfo()
        {
            lbl_DateTime.Content = DateTime.Now.DayOfWeek.ToString() + DateTime.Now.ToString(" dd/MM/yyyy");
        }

        private void Clock()
        {
            //Take current time and apply to clock
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Tick += new EventHandler(timer_Tick);
            dispatcherTimer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lbl_Clock.Content = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
