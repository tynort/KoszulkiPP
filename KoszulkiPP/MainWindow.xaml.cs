using System;
using System.Windows;
using System.IO;
using System.Threading;

namespace KoszulkiPP
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            {
                InitializeComponent();
                WindowState = WindowState.Minimized;
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                string UserName1 = Environment.UserName;
                string path_directory = @"C:\temp";
                MonitorDirectory(path_directory);

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            Move.GetSize(3);
            WindowState = WindowState.Minimized;
            Move.ChangeName();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Move.GetSize(5);
            WindowState = WindowState.Minimized;
            Move.ChangeName();
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Move.GetSize(7);
            WindowState = WindowState.Minimized;
            Move.ChangeName();
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Move.GetSize(9);
            WindowState = WindowState.Minimized;
            Move.ChangeName();

        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Move.GetSize(12);
            WindowState = WindowState.Minimized;
            Move.ChangeName();
        }
        private void ShowWindow()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                WindowState = WindowState.Normal;
                CenterWindowOnScreen();
            }));
        }

        private void MinimizedWindow()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                WindowState = WindowState.Minimized;
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
            Thread.Sleep(2000);
        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)

        {
            ShowSaveMessage();
            Console.WriteLine("Plik skasowany: {0}", e.Name);
        }

        private static void ShowSaveMessage()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                SaveWindow sw = new SaveWindow();
                sw.Show();
                Thread.Sleep(5000);
                sw.Close();
            });
        }

        private void CenterWindowOnScreen()
        {
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

