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
    /// Logika interakcji dla klasy Timer.xaml
    /// </summary>
    public partial class Timer : Window
    {
        private int _time = 15;
        private DispatcherTimer Timerr;

        public EventHandler Tick { get; internal set; }

        public Timer()
        {
            InitializeComponent();
            Topmost = true;
            Timerr = new DispatcherTimer();
            Timerr.Start();
            Timerr.Interval = new TimeSpan(0, 0, 1);
            Timerr.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_time > 0)
            {
                if (_time <= 10)
                {
                    if (_time % 2 == 0)
                    {
                        lblClockTime.Foreground = Brushes.Red;
                    }
                    else
                    {
                        lblClockTime.Foreground = Brushes.Black;
                    }
                    _time--;
                    lblClockTime.Text = string.Format("00:0{0}:0{1}", _time / 60, _time % 60);
                }
                else
                {
                    _time--;
                    lblClockTime.Text = string.Format("00:0{0}:{01}", _time / 60, _time % 60);
                }

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
    }
}
