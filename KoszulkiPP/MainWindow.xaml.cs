using System;
using System.Windows;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KoszulkiPP
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            {
                InitializeComponent();
                MinimizedWindow();
                string UserName = Environment.UserName;
                string path_directory = @"C:\temp";
                MonitorDirectory(path_directory);
                ShowInTaskbar = false;

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Move.GetSize(3);
            this.Hide();
            Move.ChangeName();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Move.GetSize(5);
            this.Hide();
            Move.ChangeName();
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Move.GetSize(7);
            this.Hide();
            Move.ChangeName();
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Move.GetSize(9);
            this.Hide();
            Move.ChangeName();

        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Move.GetSize(12);
            this.Hide();
            Move.ChangeName();
        }
        private void ShowWindow()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                Topmost = true;
                this.Show();
                CenterWindowOnScreen();
            }));
        }

        private void MinimizedWindow()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
                ni.Icon = new System.Drawing.Icon(@"Resources\6.ico");
                ni.Visible = true;
                this.Hide();
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }));
        }


        public void MonitorDirectory(string path)

        {

            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

            fileSystemWatcher.Path = path;

            fileSystemWatcher.Created += FileSystemWatcher_Created;

            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;

            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;

            fileSystemWatcher.EnableRaisingEvents = true;

            fileSystemWatcher.Filter = "*.png";

            Console.WriteLine(path + @"\static.png");

            if (File.Exists(path + @"\static.png"))
            {
                Move.ChangeName();
            }

        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)

        {
            Console.WriteLine("Nowy plik: {0}", e.Name);
        }

        private void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)

        {
            Console.WriteLine("Nowy plik - zmieniona nazwa: {0}", e.Name);
            ShowWindow();
        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)

        {
            ShowSaveMessage();
            Console.WriteLine("Plik skasowany: {0}", e.Name);
        }

        private static void ShowSaveMessage()
        {
            System.Windows.Application.Current.Dispatcher.Invoke((Action)delegate {
                SaveWindow sw = new SaveWindow();
                sw.Show();
                Thread.Sleep(5000);
                sw.Close();
                ShowTimer();
            });
        }
        private static void ShowTimer()
        {
            System.Windows.Application.Current.Dispatcher.Invoke((Action)delegate {
                Timer t = new Timer();
                t.Show();
            });
        }

        private void CenterWindowOnScreen()
        {
            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon(@"Resources\6.ico");
            ni.Visible = true;
            Topmost = true;
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = Width;
            double windowHeight = Height;
            Left = (screenWidth / 2) - (windowWidth / 2);
            Top = (screenHeight / 2) - (windowHeight / 2);
        }

    }


}

