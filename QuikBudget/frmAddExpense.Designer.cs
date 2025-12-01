namespace QuikBudget
{
    partial class frmAddExpense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            txtExpenseName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cmbCategory = new ComboBox();
            nudAmount = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(273, 119);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(192, 119);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 2;
            label1.Text = "Expense Name:";
            // 
            // txtExpenseName
            // 
            txtExpenseName.Cursor = Cursors.IBeam;
            txtExpenseName.Location = new Point(105, 6);
            txtExpenseName.Name = "txtExpenseName";
            txtExpenseName.Size = new Size(243, 23);
            txtExpenseName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 43);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 4;
            label2.Text = "Category:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 80);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 5;
            label3.Text = "Amount Owed: $";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "Car Payment", "Credit Card", "Insurance", "Loan", "Medical Bill", "Misc. Expense", "Mortgage", "Pay TV", "Personal Expense", "Rent", "Subscription Service", "Telecommunications" });
            cmbCategory.Location = new Point(105, 40);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(243, 23);
            cmbCategory.Sorted = true;
            cmbCategory.TabIndex = 6;
            // 
            // nudAmount
            // 
            nudAmount.Location = new Point(115, 78);
            nudAmount.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(233, 23);
            nudAmount.TabIndex = 7;
            nudAmount.ThousandsSeparator = true;
            // 
            // frmAddExpense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 155);
            ControlBox = false;
            Controls.Add(nudAmount);
            Controls.Add(cmbCategory);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtExpenseName);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddExpense";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Expense";
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private TextBox txtExpenseName;
        private Label label2;
        private Label label3;
        private ComboBox cmbCategory;
        private NumericUpDown nudAmount;
    }
}