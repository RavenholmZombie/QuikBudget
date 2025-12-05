using QuikBudget.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace QuikBudget
{
    public partial class ExpenseControl : UserControl
    {
        private decimal _amount;

        public static CultureInfo CurrencyCulture { get; set; } = CultureInfo.CurrentCulture;
        public ExpenseControl()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(4);
            this.BackColor = Color.White;

            lblCategory.Click += ExpenseControl_Click;
            lblCompanyName.Click += ExpenseControl_Click;
            lblPrice.Click += ExpenseControl_Click;
            pictureBox2.Click += ExpenseControl_Click;
        }

        private void ExpenseControl_Load(object sender, EventArgs e)
        {

        }

        public void RefreshFormatting()
        {
            // Re-apply the current culture to the amount label
            lblPrice.Text = _amount.ToString("C2", CurrencyCulture);
        }

        public event EventHandler RemoveRequested;

        #region Public Properties (show up in Designer)

        [Category("Expense")]
        [Description("Name of the expense (e.g., Verizon Wireless).")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ExpenseName
        {
            get => lblCompanyName.Text;
            set => lblCompanyName.Text = value;
        }

        [Category("Expense")]
        [Description("Category or description (e.g., Telecommunications).")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Category
        {
            get => lblCategory.Text;
            set => lblCategory.Text = value;
        }

        [Category("Expense")]
        [Description("Amount owed for this expense.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                lblPrice.Text = _amount.ToString("C2", CurrencyCulture);
            }
        }

        [Category("Expense")]
        [Description("Logo or icon for the expense.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Logo
        {
            get => pictureBox2.Image;
            set
            {
                pictureBox2.Image = value;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;  // keep aspect ratio
            }
        }

        [Category("Expense")]
        [Description("Set Paid")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Paid
        {
            get => cBoxPaid.Checked;
            set
            {
                cBoxPaid.Checked = value;
            }
        }

        #endregion

        #region Remove handling

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnRemoveRequested();
        }

        protected virtual void OnRemoveRequested()
        {
            RemoveRequested?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public override string ToString()
        {
            return $"{ExpenseName} - {Amount:C2}";
        }

        private void cBoxPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxPaid.Checked)
            {
                // Model back color
                BackColor = Color.ForestGreen;

                // Label colors
                cBoxPaid.ForeColor = Color.White;
                lblPrice.ForeColor = Color.White;
                lblCategory.ForeColor = Color.White;
                lblCompanyName.ForeColor = Color.White;
            }
            else
            {
                // Model back color
                BackColor = Color.White;

                // Label colors
                cBoxPaid.ForeColor = Color.Black;
                lblPrice.ForeColor = Color.Black;
                lblCategory.ForeColor = Color.Black;
                lblCompanyName.ForeColor = Color.Black;
            }
        }

        private void lnkLblDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void imgBtnClose_MouseEnter(object sender, EventArgs e)
        {
            imgBtnClose.BackgroundImage = Resources.delete_hov;
        }

        private void imgBtnClose_MouseLeave(object sender, EventArgs e)
        {
            imgBtnClose.BackgroundImage = Resources.delete_norm;
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            imgBtnClose.BackgroundImage = Resources.delete_press;
            OnRemoveRequested();
        }

        private void ExpenseControl_Click(object sender, EventArgs e)
        {
            if(cBoxPaid.Checked)
            {
                cBoxPaid.Checked = false;
            }
            else
            {
                cBoxPaid.Checked = true;
            }
        }
    }
}
