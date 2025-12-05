using QuikBudget.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuikBudget
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            var saved = Settings.Default.currencyNote;
            if (!string.IsNullOrWhiteSpace(saved))
            {
                int index = cmbCurrency.FindStringExact(saved);
                if (index >= 0)
                    cmbCurrency.SelectedIndex = index;
            }

            cBoxAutoLoad.Checked = Properties.Settings.Default.openLastFileOnLaunch;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbCurrency.SelectedItem != null)
            {
                Settings.Default.currencyNote = cmbCurrency.SelectedItem.ToString();
            }
            else
            {
                cmbCurrency.SelectedIndex = 0;
                Settings.Default.currencyNote = cmbCurrency.SelectedItem.ToString();
            }
            
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cBoxAutoLoad_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.openLastFileOnLaunch = cBoxAutoLoad.Checked;
        }
    }
}
