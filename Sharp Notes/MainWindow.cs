using System;
using System.Windows.Forms;

namespace Sharp_Notes
{
    public partial class MainWindow : Form
    {
        private Notepad notepad;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (notepad != null) return;
            notepad = new Notepad(this);
        }

        #region UI

        #region Menu Items

        private void newToolStripMenuItem_Click(object sender, EventArgs e) => notepad.New();
        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e) => notepad.NewWindow();
        private void openToolStripMenuItem_Click(object sender, EventArgs e) => notepad.Open();
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => notepad.Save(notepad.currentText);
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => notepad.SaveAs(notepad.currentText);
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e) => notepad.PageSetup();
        private void printToolStripMenuItem_Click(object sender, EventArgs e) => notepad.Print();
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Exit();

        #endregion

        #region Menu Item Keybinds

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                notepad.New();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Shift | Keys.N))
            {
                notepad.NewWindow();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                notepad.Open();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                notepad.Save(notepad.currentText);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                notepad.SaveAs(notepad.currentText);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.P))
            {
                notepad.Print();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.E))
            {
                Exit();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Methods

        private void Exit() => Environment.Exit(0);

        #endregion

        #endregion

        #region Generics

        public void UpdateStatus(string status, bool saved)
        {
            if (saved)
            {
                this.Text = "Sharp Notes - " + status;
                return;
            }
            this.Text = "*Sharp Notes - " + status;
        }

        #endregion

        private void noteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (notepad.UnsavedChanges())
            {
                UpdateStatus(notepad.currentFileName, false);
                return;
            }
            UpdateStatus(notepad.currentFileName, true);
        }
    }
}
