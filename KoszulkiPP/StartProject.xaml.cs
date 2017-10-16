using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;


namespace KoszulkiPP
{
    /// <summary>
    /// Logika interakcji dla klasy StartProject.xaml
    /// </summary>
    public partial class StartProject : Window
    {
        private static int _time = 0;
        private DispatcherTimer Timerr;

        public EventHandler Tick { get; internal set; }

        public StartProject()
        {
            InitializeComponent();
            Topmost = true;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_time > 0)
            {
                _time--;
            }
            else
            {
                Timerr.Stop();
                Close();
            }
        }
        public int TimeToStop
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            _time = 300;
            Timerr = new DispatcherTimer();
            Timerr.Start();
            Timerr.Interval = new TimeSpan(0, 0, 1);
            Timerr.Tick += Timer_Tick;
            Close();
        }
    }
}
