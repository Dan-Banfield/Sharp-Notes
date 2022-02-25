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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Exit();
        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e) => notepad.NewWindow();
        private void openToolStripMenuItem_Click(object sender, EventArgs e) => notepad.Open();

        #endregion

        #region Menu Item Keybinds

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.E))
            {
                Exit();
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
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Methods

        private void Exit() => Environment.Exit(0);

        #endregion

        #endregion

        #region Generics

        public void UpdateStatus(string status)
        {
            this.Text = "Sharp Notes - " + status;
        }

        #endregion
    }
}
