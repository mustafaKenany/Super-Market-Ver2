namespace Rresturant
{
    partial class BuyReportForm
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
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyReportForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxDateSearch = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFilterBuyGrid = new System.Windows.Forms.TextBox();
            this.buttonPrintBuyGrid = new System.Windows.Forms.Button();
            this.buttonShowBuyInvoices = new System.Windows.Forms.Button();
            this.dataGridViewBuyGridInvoice = new System.Windows.Forms.DataGridView();
            this.ColumnInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceRunORNot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIQPAid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUSPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConversionRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReminder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnButtonDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuyGridInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 50);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Changa", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(483, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "فواتير البيع";
            // 
            // Exit
            // 
            this.Exit.Dock = System.Windows.Forms.DockStyle.Left;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Location = new System.Drawing.Point(0, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(43, 50);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Exit.TabIndex = 2;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxDateSearch);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dateTimePickerTo);
            this.panel2.Controls.Add(this.dateTimePickerFrom);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxFilterBuyGrid);
            this.panel2.Controls.Add(this.buttonPrintBuyGrid);
            this.panel2.Controls.Add(this.buttonShowBuyInvoices);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1125, 75);
            this.panel2.TabIndex = 4;
            // 
            // checkBoxDateSearch
            // 
            this.checkBoxDateSearch.AutoSize = true;
            this.checkBoxDateSearch.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxDateSearch.Font = new System.Drawing.Font("Changa Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.checkBoxDateSearch.Location = new System.Drawing.Point(1014, 13);
            this.checkBoxDateSearch.Name = "checkBoxDateSearch";
            this.checkBoxDateSearch.Size = new System.Drawing.Size(107, 44);
            this.checkBoxDateSearch.TabIndex = 13;
            this.checkBoxDateSearch.Text = "بحث بين تاريخين";
            this.checkBoxDateSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxDateSearch.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Changa Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(970, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "الى";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Changa Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(973, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "من";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerTo.Font = new System.Drawing.Font("Changa Medium", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(802, 40);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(164, 28);
            this.dateTimePickerTo.TabIndex = 10;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Changa Medium", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(802, 6);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(164, 28);
            this.dateTimePickerFrom.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Changa Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(307, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "ادخل كلمة للبحث";
            // 
            // textBoxFilterBuyGrid
            // 
            this.textBoxFilterBuyGrid.Font = new System.Drawing.Font("Changa Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFilterBuyGrid.Location = new System.Drawing.Point(8, 28);
            this.textBoxFilterBuyGrid.Name = "textBoxFilterBuyGrid";
            this.textBoxFilterBuyGrid.Size = new System.Drawing.Size(293, 32);
            this.textBoxFilterBuyGrid.TabIndex = 4;
            this.textBoxFilterBuyGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxFilterBuyGrid.TextChanged += new System.EventHandler(this.textBoxFilterBuyGrid_TextChanged);
            // 
            // buttonPrintBuyGrid
            // 
            this.buttonPrintBuyGrid.AutoSize = true;
            this.buttonPrintBuyGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.buttonPrintBuyGrid.Font = new System.Drawing.Font("Changa Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrintBuyGrid.Location = new System.Drawing.Point(432, 23);
            this.buttonPrintBuyGrid.Name = "buttonPrintBuyGrid";
            this.buttonPrintBuyGrid.Size = new System.Drawing.Size(100, 40);
            this.buttonPrintBuyGrid.TabIndex = 2;
            this.buttonPrintBuyGrid.Text = "طباعة";
            this.buttonPrintBuyGrid.UseVisualStyleBackColor = false;
            this.buttonPrintBuyGrid.Click += new System.EventHandler(this.buttonPrintBuyGrid_Click);
            // 
            // buttonShowBuyInvoices
            // 
            this.buttonShowBuyInvoices.AutoSize = true;
            this.buttonShowBuyInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.buttonShowBuyInvoices.Font = new System.Drawing.Font("Changa Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowBuyInvoices.Location = new System.Drawing.Point(536, 23);
            this.buttonShowBuyInvoices.Name = "buttonShowBuyInvoices";
            this.buttonShowBuyInvoices.Size = new System.Drawing.Size(100, 40);
            this.buttonShowBuyInvoices.TabIndex = 1;
            this.buttonShowBuyInvoices.Text = "عرض الفواتير";
            this.buttonShowBuyInvoices.UseVisualStyleBackColor = false;
            this.buttonShowBuyInvoices.Click += new System.EventHandler(this.buttonShowBuyInvoices_Click);
            // 
            // dataGridViewBuyGridInvoice
            // 
            this.dataGridViewBuyGridInvoice.AllowUserToAddRows = false;
            this.dataGridViewBuyGridInvoice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewBuyGridInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBuyGridInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBuyGridInvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewBuyGridInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Changa Medium", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBuyGridInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBuyGridInvoice.ColumnHeadersHeight = 50;
            this.dataGridViewBuyGridInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnInvoiceNo,
            this.ColumnInvoiceCustomer,
            this.ColumnInvoiceTotal,
            this.ColumnInvoiceDiscount,
            this.ColumnInvoiceTotalAmount,
            this.ColumnInvoiceStatus,
            this.ColumnInvoiceDate,
            this.ColumnInvoiceRunORNot,
            this.ColumnInvoiceType,
            this.ColumnIQPAid,
            this.ColumnUSPaid,
            this.ColumnConversionRate,
            this.ColumnReminder,
            this.ColumnButtonDetails});
            this.dataGridViewBuyGridInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBuyGridInvoice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.dataGridViewBuyGridInvoice.Location = new System.Drawing.Point(0, 125);
            this.dataGridViewBuyGridInvoice.MultiSelect = false;
            this.dataGridViewBuyGridInvoice.Name = "dataGridViewBuyGridInvoice";
            this.dataGridViewBuyGridInvoice.ReadOnly = true;
            this.dataGridViewBuyGridInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewBuyGridInvoice.RowHeadersVisible = false;
            this.dataGridViewBuyGridInvoice.RowHeadersWidth = 45;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewBuyGridInvoice.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBuyGridInvoice.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewBuyGridInvoice.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Changa", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.dataGridViewBuyGridInvoice.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewBuyGridInvoice.RowTemplate.Height = 40;
            this.dataGridViewBuyGridInvoice.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBuyGridInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBuyGridInvoice.Size = new System.Drawing.Size(1125, 575);
            this.dataGridViewBuyGridInvoice.TabIndex = 11;
            this.dataGridViewBuyGridInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBuyGridInvoice_CellContentClick);
            // 
            // ColumnInvoiceNo
            // 
            this.ColumnInvoiceNo.DataPropertyName = "invoiceNo";
            this.ColumnInvoiceNo.HeaderText = "رقم فاتورة";
            this.ColumnInvoiceNo.Name = "ColumnInvoiceNo";
            this.ColumnInvoiceNo.ReadOnly = true;
            // 
            // ColumnInvoiceCustomer
            // 
            this.ColumnInvoiceCustomer.DataPropertyName = "CustomerName";
            this.ColumnInvoiceCustomer.HeaderText = "الـــــزبــــــــون";
            this.ColumnInvoiceCustomer.Name = "ColumnInvoiceCustomer";
            this.ColumnInvoiceCustomer.ReadOnly = true;
            this.ColumnInvoiceCustomer.Width = 200;
            // 
            // ColumnInvoiceTotal
            // 
            this.ColumnInvoiceTotal.DataPropertyName = "InvoiceTotalAmount";
            this.ColumnInvoiceTotal.HeaderText = "مجموع فاتورة";
            this.ColumnInvoiceTotal.Name = "ColumnInvoiceTotal";
            this.ColumnInvoiceTotal.ReadOnly = true;
            // 
            // ColumnInvoiceDiscount
            // 
            this.ColumnInvoiceDiscount.DataPropertyName = "InvoiceDiscount";
            this.ColumnInvoiceDiscount.HeaderText = "خصم القائمة";
            this.ColumnInvoiceDiscount.Name = "ColumnInvoiceDiscount";
            this.ColumnInvoiceDiscount.ReadOnly = true;
            // 
            // ColumnInvoiceTotalAmount
            // 
            this.ColumnInvoiceTotalAmount.DataPropertyName = "InvoiceNetAmount";
            this.ColumnInvoiceTotalAmount.HeaderText = "صافي القائمة";
            this.ColumnInvoiceTotalAmount.Name = "ColumnInvoiceTotalAmount";
            this.ColumnInvoiceTotalAmount.ReadOnly = true;
            // 
            // ColumnInvoiceStatus
            // 
            this.ColumnInvoiceStatus.DataPropertyName = "InvoicePaymentStatus";
            this.ColumnInvoiceStatus.HeaderText = "نوع فاتورة";
            this.ColumnInvoiceStatus.Name = "ColumnInvoiceStatus";
            this.ColumnInvoiceStatus.ReadOnly = true;
            // 
            // ColumnInvoiceDate
            // 
            this.ColumnInvoiceDate.DataPropertyName = "InvoiceDate";
            this.ColumnInvoiceDate.HeaderText = "تاريخ فاتورة";
            this.ColumnInvoiceDate.Name = "ColumnInvoiceDate";
            this.ColumnInvoiceDate.ReadOnly = true;
            // 
            // ColumnInvoiceRunORNot
            // 
            this.ColumnInvoiceRunORNot.DataPropertyName = "InvoiceRunORnot";
            this.ColumnInvoiceRunORNot.HeaderText = "RUNORNOT";
            this.ColumnInvoiceRunORNot.Name = "ColumnInvoiceRunORNot";
            this.ColumnInvoiceRunORNot.ReadOnly = true;
            this.ColumnInvoiceRunORNot.Visible = false;
            // 
            // ColumnInvoiceType
            // 
            this.ColumnInvoiceType.DataPropertyName = "InvoiceType";
            this.ColumnInvoiceType.HeaderText = "INVOICETYPE";
            this.ColumnInvoiceType.Name = "ColumnInvoiceType";
            this.ColumnInvoiceType.ReadOnly = true;
            this.ColumnInvoiceType.Visible = false;
            // 
            // ColumnIQPAid
            // 
            this.ColumnIQPAid.DataPropertyName = "IQAmountPaid";
            this.ColumnIQPAid.HeaderText = "مبلغ عراقي";
            this.ColumnIQPAid.Name = "ColumnIQPAid";
            this.ColumnIQPAid.ReadOnly = true;
            // 
            // ColumnUSPaid
            // 
            this.ColumnUSPaid.DataPropertyName = "USAmountPaid";
            this.ColumnUSPaid.HeaderText = "مبلغ دولار";
            this.ColumnUSPaid.Name = "ColumnUSPaid";
            this.ColumnUSPaid.ReadOnly = true;
            // 
            // ColumnConversionRate
            // 
            this.ColumnConversionRate.DataPropertyName = "ConversionRate";
            this.ColumnConversionRate.HeaderText = "نسبة تحويل";
            this.ColumnConversionRate.Name = "ColumnConversionRate";
            this.ColumnConversionRate.ReadOnly = true;
            // 
            // ColumnReminder
            // 
            this.ColumnReminder.DataPropertyName = "Reminder";
            this.ColumnReminder.HeaderText = "المتبقي";
            this.ColumnReminder.Name = "ColumnReminder";
            this.ColumnReminder.ReadOnly = true;
            // 
            // ColumnButtonDetails
            // 
            this.ColumnButtonDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnButtonDetails.HeaderText = "التفاصيل";
            this.ColumnButtonDetails.Name = "ColumnButtonDetails";
            this.ColumnButtonDetails.ReadOnly = true;
            this.ColumnButtonDetails.Text = "عرض";
            this.ColumnButtonDetails.UseColumnTextForButtonValue = true;
            // 
            // BuyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 700);
            this.Controls.Add(this.dataGridViewBuyGridInvoice);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(150, 12);
            this.Name = "BuyReportForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BuyReportForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuyGridInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonShowBuyInvoices;
        private System.Windows.Forms.Button buttonPrintBuyGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFilterBuyGrid;
        private System.Windows.Forms.CheckBox checkBoxDateSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DataGridView dataGridViewBuyGridInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceRunORNot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIQPAid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUSPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConversionRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReminder;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnButtonDetails;
    }
}