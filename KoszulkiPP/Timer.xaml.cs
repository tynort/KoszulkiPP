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
        private int _time;
        private DispatcherTimer Timerr;

        public EventHandler Tick { get; internal set; }

        public Timer()
        {
            InitializeComponent();
            Topmost = true;
            StartProject czas = new StartProject();
            _time = czas.TimeToStop;
            Timerr = new DispatcherTimer();
            Timerr.Interval = new TimeSpan(0, 0, 1);
            Timerr.Tick += Timer_Tick;
            Timerr.Start();
            MainWindow.ShowStart();


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
                        _time--;
                    }
                    else
                    {
                        lblClockTime.Foreground = Brushes.Black;
                        _time--;

                    }
                    lblClockTime.Text = string.Format("00:0{0}:0{1}", _time / 60, _time % 60);
                }
                else
                {
                    if((_time % 60) == 0 || (_time%60)==1|| (_time % 60) == 2 || (_time % 60) == 3 || (_time % 60) == 4 || (_time % 60) == 5 || (_time % 60) == 6 || (_time % 60) == 7 || (_time % 60) == 8 || (_time % 60) == 9)
                    {
                        lblClockTime.Text = string.Format("00:0{0}:0{1}", _time / 60, _time % 60);
                    }
                    else
                    {
                        lblClockTime.Text = string.Format("00:0{0}:{01}", _time / 60, _time % 60);
                    }
                    _time--;
                }

            }
            else
            {
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
