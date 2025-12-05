namespace QuikBudget
{
    partial class ExpenseControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            linkLabel2 = new LinkLabel();
            lblCompanyName = new Label();
            pictureBox2 = new PictureBox();
            lblCategory = new Label();
            lblPrice = new Label();
            cBoxPaid = new CheckBox();
            imgBtnClose = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgBtnClose).BeginInit();
            SuspendLayout();
            // 
            // linkLabel2
            // 
            linkLabel2.Location = new Point(0, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(100, 23);
            linkLabel2.TabIndex = 0;
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.BackColor = Color.Transparent;
            lblCompanyName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyName.Location = new Point(47, 5);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(93, 15);
            lblCompanyName.TabIndex = 6;
            lblCompanyName.Text = "Company Name";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Location = new Point(3, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Transparent;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(47, 20);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 7;
            lblCategory.Text = "Category";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Right;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.BorderStyle = BorderStyle.FixedSingle;
            lblPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(266, 12);
            lblPrice.Name = "lblPrice";
            lblPrice.RightToLeft = RightToLeft.Yes;
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "$0.00";
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cBoxPaid
            // 
            cBoxPaid.Anchor = AnchorStyles.Right;
            cBoxPaid.AutoSize = true;
            cBoxPaid.BackColor = Color.Transparent;
            cBoxPaid.Location = new Point(206, 15);
            cBoxPaid.Name = "cBoxPaid";
            cBoxPaid.Size = new Size(54, 19);
            cBoxPaid.TabIndex = 10;
            cBoxPaid.Text = "Paid?";
            cBoxPaid.TextAlign = ContentAlignment.BottomCenter;
            cBoxPaid.UseVisualStyleBackColor = false;
            cBoxPaid.CheckedChanged += cBoxPaid_CheckedChanged;
            // 
            // imgBtnClose
            // 
            imgBtnClose.Anchor = AnchorStyles.Right;
            imgBtnClose.BackColor = Color.Transparent;
            imgBtnClose.BackgroundImage = Properties.Resources.delete_norm;
            imgBtnClose.BackgroundImageLayout = ImageLayout.Stretch;
            imgBtnClose.Cursor = Cursors.Hand;
            imgBtnClose.Location = new Point(374, 14);
            imgBtnClose.Name = "imgBtnClose";
            imgBtnClose.Size = new Size(20, 20);
            imgBtnClose.TabIndex = 11;
            imgBtnClose.TabStop = false;
            imgBtnClose.Click += imgBtnClose_Click;
            imgBtnClose.MouseEnter += imgBtnClose_MouseEnter;
            imgBtnClose.MouseLeave += imgBtnClose_MouseLeave;
            // 
            // ExpenseControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._7751;
            BackgroundImageLayout = ImageLayout.Stretch;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(imgBtnClose);
            Controls.Add(cBoxPaid);
            Controls.Add(lblPrice);
            Controls.Add(lblCategory);
            Controls.Add(lblCompanyName);
            Controls.Add(pictureBox2);
            DoubleBuffered = true;
            Name = "ExpenseControl";
            Size = new Size(402, 46);
            Load += ExpenseControl_Load;
            Click += ExpenseControl_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgBtnClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private LinkLabel linkLabel2;
        private Label label7;
        private Label lblCompanyName;
        private PictureBox pictureBox2;
        private Label lblCategory;
        private Label lblPrice;
        private CheckBox cBoxPaid;
        private PictureBox imgBtnClose;
    }
}
