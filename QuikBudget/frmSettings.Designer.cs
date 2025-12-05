namespace QuikBudget
{
    partial class frmSettings
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
            cBoxAutoLoad = new CheckBox();
            btnDone = new Button();
            label1 = new Label();
            cmbCurrency = new ComboBox();
            SuspendLayout();
            // 
            // cBoxAutoLoad
            // 
            cBoxAutoLoad.AutoSize = true;
            cBoxAutoLoad.Location = new Point(23, 46);
            cBoxAutoLoad.Name = "cBoxAutoLoad";
            cBoxAutoLoad.Size = new Size(243, 19);
            cBoxAutoLoad.TabIndex = 0;
            cBoxAutoLoad.Text = "Load Previously Saved Budget on Launch";
            cBoxAutoLoad.UseVisualStyleBackColor = true;
            cBoxAutoLoad.CheckedChanged += cBoxAutoLoad_CheckedChanged;
            // 
            // btnDone
            // 
            btnDone.Location = new Point(170, 141);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(107, 23);
            btnDone.TabIndex = 1;
            btnDone.Text = "Save and Close";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 82);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 2;
            label1.Text = "Set your currency:";
            // 
            // cmbCurrency
            // 
            cmbCurrency.FormattingEnabled = true;
            cmbCurrency.Items.AddRange(new object[] { "United States Dollar (USD $)", "Euro (EUR €)", "British Pound Sterling (GBP £)", "Chinese Yuan Renminbi (CNY ¥)", "Australian Dollar (AUD $)", "Canadian Dollar (CAD $)", "New Zealand Dollar (NZD $)", "Hong Kong Dollar (HKD $)", "Singapore Dollar (SGD $)", "East Caribbean Dollar (XCD $)", "Fijian Dollar (FJD $)", "Solomon Islands Dollar (SBD $)", "New Taiwan Dollar (TWD $)", "Trinidad and Tobago Dollar (TTD $)", "Namibian Dollar (NAD $)", "Bahamian Dollar (BSD $)", "Barbadian Dollar (BBD $)", "Bermudian Dollar (BMD $)", "Brunei Dollar (BND $)", "Cayman Islands Dollar (KYD $)", "Guyanese Dollar (GYD $)", "Jamaican Dollar (JMD $)", "Liberian Dollar (LRD $)", "Surinamese Dollar (SRD $)", "Tuvaluan Dollar (TVD $)", "Afghan Afghani (AFN)", "Albanian Lek (ALL)", "Algerian Dinar (DZD)", "Angolan Kwanza (AOA)", "Armenian Dram (AMD)", "Aruban Florin (AWG)", "Azerbaijani Manat (AZN)", "Bahraini Dinar (BHD)", "Bangladeshi Taka (BDT)", "Belarusian Ruble (BYN)", "Belize Dollar (BZD)", "Bhutanese Ngultrum (BTN)", "Botswanan Pula (BWP)", "Brazilian Real (BRL)", "Bulgarian Lev (BGN)", "Burundian Franc (BIF)", "Cambodian Riel (KHR)", "Cape Verdean Escudo (CVE)", "Central African CFA Franc (XAF)", "CFP Franc (XPF)", "Chilean Peso (CLP)", "Colombian Peso (COP)", "Comorian Franc (KMF)", "Congolese Franc (CDF)", "Costa Rican Colón (CRC)", "Croatian Kuna (HRK)", "Cuban Peso (CUP)", "Czech Koruna (CZK)", "Danish Krone (DKK)", "Djiboutian Franc (DJF)", "Dominican Peso (DOP)", "Egyptian Pound (EGP)", "Eritrean Nakfa (ERN)", "Ethiopian Birr (ETB)", "Falkland Islands Pound (FKP)", "Faroese Króna (FOK)", "Gambian Dalasi (GMD)", "Georgian Lari (GEL)", "Ghanaian Cedi (GHS)", "Gibraltar Pound (GIP)", "Guatemalan Quetzal (GTQ)", "Guernsey Pound (GGP)", "Guinean Franc (GNF)", "Haitian Gourde (HTG)", "Honduran Lempira (HNL)", "Hungarian Forint (HUF)", "Icelandic Króna (ISK)", "Indian Rupee (INR)", "Indonesian Rupiah (IDR)", "Iranian Rial (IRR)", "Iraqi Dinar (IQD)", "Isle of Man Pound (IMP)", "Israeli New Shekel (ILS)", "Jordanian Dinar (JOD)", "Japanese Yen (JPY)", "Kazakhstani Tenge (KZT)", "Kenyan Shilling (KES)", "Kiribati Dollar (KID)", "Kuwaiti Dinar (KWD)", "Kyrgyzstani Som (KGS)", "Lao Kip (LAK)", "Lebanese Pound (LBP)", "Lesotho Loti (LSL)", "Libyan Dinar (LYD)", "Macanese Pataca (MOP)", "Macedonian Denar (MKD)", "Malagasy Ariary (MGA)", "Malawian Kwacha (MWK)", "Malaysian Ringgit (MYR)", "Maldivian Rufiyaa (MVR)", "Mauritanian Ouguiya (MRU)", "Mauritian Rupee (MUR)", "Mexican Peso (MXN)", "Moldovan Leu (MDL)", "Mongolian Tögrög (MNT)", "Moroccan Dirham (MAD)", "Mozambican Metical (MZN)", "Myanmar Kyat (MMK)", "Nicaraguan Córdoba (NIO)", "Nigerian Naira (NGN)", "Norwegian Krone (NOK)", "Omani Rial (OMR)", "Panamanian Balboa (PAB)", "Papua New Guinean Kina (PGK)", "Paraguayan Guaraní (PYG)", "Peruvian Sol (PEN)", "Philippine Peso (PHP)", "Polish Złoty (PLN)", "Qatari Riyal (QAR)", "Romanian Leu (RON)", "Russian Ruble (RUB)", "Rwandan Franc (RWF)", "Samoan Tālā (WST)", "São Tomé and Príncipe Dobra (STN)", "Saudi Riyal (SAR)", "Serbian Dinar (RSD)", "Seychellois Rupee (SCR)", "Sierra Leonean Leone (SLE)", "Somali Shilling (SOS)", "South African Rand (ZAR)", "South Korean Won (KRW)", "South Sudanese Pound (SSP)", "Sri Lankan Rupee (LKR)", "Swazi Lilangeni (SZL)", "Swedish Krona (SEK)", "Swiss Franc (CHF)", "Syrian Pound (SYP)", "Tajikistani Somoni (TJS)", "Tanzanian Shilling (TZS)", "Thai Baht (THB)", "Tongan Paʻanga (TOP)", "Tunisian Dinar (TND)", "Turkish Lira (TRY)", "Turkmenistan Manat (TMT)", "Ukrainian Hryvnia (UAH)", "Ugandan Shilling (UGX)", "Uruguayan Peso (UYU)", "Uzbekistani Som (UZS)", "Vanuatu Vatu (VUV)", "Venezuelan Bolívar (VES)", "Vietnamese Đồng (VND)", "West African CFA Franc (XOF)", "Yemeni Rial (YER)", "Zambian Kwacha (ZMW)", "Zimbabwean Dollar (ZWL)" });
            cmbCurrency.Location = new Point(23, 100);
            cmbCurrency.Name = "cmbCurrency";
            cmbCurrency.Size = new Size(254, 23);
            cmbCurrency.TabIndex = 3;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 176);
            Controls.Add(cmbCurrency);
            Controls.Add(label1);
            Controls.Add(btnDone);
            Controls.Add(cBoxAutoLoad);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSettings";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += frmSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cBoxAutoLoad;
        private Button btnDone;
        private Label label1;
        private ComboBox cmbCurrency;
    }
}