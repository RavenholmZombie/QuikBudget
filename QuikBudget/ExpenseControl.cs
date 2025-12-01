using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuikBudget
{
    public partial class ExpenseControl : UserControl
    {
        private decimal _amount;
        public ExpenseControl()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(4);
            this.BackColor = Color.White;

            lnkLblDelete.LinkClicked += lnkRemove_LinkClicked;
        }

        private void ExpenseControl_Load(object sender, EventArgs e)
        {

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
                lblPrice.Text = _amount.ToString("C2"); // e.g. $185.59
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
    }
}
