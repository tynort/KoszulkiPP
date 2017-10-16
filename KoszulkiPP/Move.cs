using System;
using System.IO;

namespace KoszulkiPP
{
    public class Move : MainWindow
    {
        private static string rozmiar = String.Empty;

        public static void ChangeName()
        {

            string UserName = Environment.UserName;
            //FileInfo fInfo = new FileInfo(@"C:\Users\" + UserName1 + @"\Downloads\static.png");
            FileInfo fInfo = new FileInfo(@"C:\temp\static.png");
            string data_pliku = fInfo.CreationTimeUtc.ToString("HH_mm_ss");
            string czas_zapisu = fInfo.LastWriteTimeUtc.ToString("HH_mm_ss");
            //string path = "C:\\Users\\" + UserName1 + @"\Downloads\static.png";
            string path = @"C:\temp\static.png";
            string path2 = @"C:\temp2\koszulka_" + rozmiar + "_" + data_pliku + "_" + UserName + ".png";

            try
            {
                // This statement ensures that the file is created,
                // but the handle is not kept.
                if (File.Exists(path2))
                    File.Delete(path2);


                File.Move(path, path2);
                Console.WriteLine("{0} został przeniesony do {1}.", path, path2);

                // See if the original exists now.
                if (File.Exists(path))
                {
                    Console.WriteLine("Orginalny plik nadal istnieje.");
                }
                else
                {
                    Console.WriteLine("Orginalny plik został skasowany.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Coś nie pykło!");
            }
        }
        public static void GetSize(int v)
        {
            rozmiar = v.ToString();
        }
    }
}
