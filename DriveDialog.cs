using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilePerf
{
    public partial class DriveDialog : Form
    {
        public DriveDialog()
        {
            InitializeComponent();
            this.diskBox.Focus();
        }

        public string Disk
        {
            get { return this.diskBox.Text; }
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.diskBox.Text = folderBrowserDialog.SelectedPath;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void diskBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
