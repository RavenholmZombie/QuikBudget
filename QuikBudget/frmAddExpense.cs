using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuikBudget
{
    public partial class frmAddExpense : Form
    {
        public string ExpenseName => txtExpenseName.Text.Trim();
        public string Category => cmbCategory.Text.Trim();
        public decimal Amount => nudAmount.Value;
        public bool Paid => false;

        public frmAddExpense()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExpenseName))
            {
                MessageBox.Show("Please enter an expense name.", "Missing Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
