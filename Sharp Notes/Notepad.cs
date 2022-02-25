using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Sharp_Notes
{
    public class Notepad
    {
        private MainWindow MainWindow;

        private string currentText
        {
            get
            {
               return MainWindow.noteTextBox.Text;
            }
            set
            {
                MainWindow.noteTextBox.Text = value;
            }
        }

        private string currentFileLocation = string.Empty;

        public Notepad(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        public void New()
        {
            if (string.IsNullOrEmpty(currentText)) return;
            //TODO: Create new save instance.
        }

        public void Save()
        {

        }

        public void SaveAs()
        {

        }

        public void Open()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentFileLocation = ofd.FileName;
                    currentText = File.ReadAllText(ofd.FileName);
                    MainWindow.UpdateStatus(ofd.SafeFileName);
                }
            }
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
