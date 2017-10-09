using System;
using System.Windows;


namespace KoszulkiPP
{
    /// <summary>
    /// Logika interakcji dla klasy SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        public SaveWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ShowInTaskbar = false;
            this.Topmost = true;

        }
    }
}
