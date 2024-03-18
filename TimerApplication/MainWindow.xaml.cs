using System.Text;
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
using TimerApplication.View;

namespace TimerApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserControl currentPage;
        public UserControl CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            rdtn_Clock.IsChecked = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void rdtn_Clock_Checked(object sender, RoutedEventArgs e)
        {
            CurrentPage = new ClockView();
            ct_Content.Content = currentPage.Content;
        }

        private void rdtn_Timer_Checked(object sender, RoutedEventArgs e)
        {
            CurrentPage = new TimerView();
            ct_Content.Content = currentPage.Content;
        }

        //private void rdtn_AlarmClock_Checked(object sender, RoutedEventArgs e)
        //{
        //    CurrentPage = new AlarmClockView();
        //    ct_Content.Content = currentPage.Content;
        //}


    }
}