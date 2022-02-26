using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Sharp_Notes
{
    public class Notepad
    {
        #region Fields

        private MainWindow MainWindow;

        public string currentText
        {
            get => MainWindow.noteTextBox.Text;
            set => MainWindow.noteTextBox.Text = value;
        }

        private string currentFileLocation = string.Empty;
        private string currentFileText = string.Empty;

        //Not related to vital information (save checks).
        public string currentFileName = "Untitled";

        #endregion

        public Notepad(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        #region Methods

        public void New()
        {
            if (UnsavedChanges()) PromptSave();
            Clear();
        }

        public bool UnsavedChanges()
        {
            if (currentFileLocation == string.Empty && currentFileText == string.Empty)
            {
                if (currentText != string.Empty) return true;
                else if (currentText == string.Empty) return false;
            }
            else if (currentFileLocation != string.Empty && currentFileText != string.Empty)
            {
                if (currentText != currentFileText) return true;
            }

            return false;
        }

        private void PromptSave()
        {
            DialogResult dialogResult = MessageBox.Show("You have unsaved changes. Would you like to save?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            switch (dialogResult)
            {
                case DialogResult.Yes:
                    Save(currentText);
                    break;
                case DialogResult.No:
                    break;
            }
        }

        public void Clear()
        {
            currentText = string.Empty;
            currentFileLocation = string.Empty;
            currentFileText = string.Empty;

            //Not related to vital information (save checks).
            currentFileName = "Untitled";

            UpdateSaveInformation(currentFileLocation, currentFileText, currentFileName);
        }

        public void Save(string contents)
        {
            if (currentFileLocation == string.Empty && currentFileText == string.Empty) SaveAs(contents);
            else { File.WriteAllText(currentFileLocation, contents); UpdateSaveInformation(currentFileLocation, contents, currentFileName); }
        }

        public void SaveAs(string contents)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, contents);
                    UpdateSaveInformation(sfd.FileName, File.ReadAllText(sfd.FileName), Path.GetFileName(sfd.FileName));
                }
            }
        }

        public void UpdateSaveInformation(string fileLocation, string fileText, string fileName)
        {
            currentFileLocation = fileLocation;
            currentFileText = fileText;

            //Not related to vital information (save checks).
            currentFileName = fileName;

            MainWindow.UpdateStatus(fileName, true);
        }

        public void Open()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    UpdateSaveInformation(ofd.FileName, File.ReadAllText(ofd.FileName), ofd.SafeFileName);
                    currentText = currentFileText;
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
            //TODO: Show a dialogue allowing you to configure options for Sharp Notes.
        }

        public void Print()
        {
            //TODO: Print the note on an A4 sheet of paper.
        }

        #endregion
    }
}
