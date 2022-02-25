using System.Diagnostics;
using System.IO;

namespace Sharp_Notes
{
    public class Notepad
    {
        private MainWindow MainWindow;

        public Notepad(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        public void New()
        {

        }

        public void Save()
        {

        }

        public void SaveAs()
        {

        }

        public void Open()
        {

        }

        public void NewWindow()
        {
            string fileName = Directory.GetCurrentDirectory() + @"\Sharp Notes.exe";
            Process.Start(fileName);
        }

        public void PageSetup()
        {

        }

        public void Print()
        {

        }
    }
}
