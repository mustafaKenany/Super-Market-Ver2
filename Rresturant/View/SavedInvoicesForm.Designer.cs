namespace Rresturant.View
{
    partial class SavedInvoicesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelExit = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridViewSaveInvoices = new System.Windows.Forms.DataGridView();
            this.ColumnInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaveInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.panelTitle.Controls.Add(this.labelExit);
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(2, 2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(671, 30);
            this.panelTitle.TabIndex = 1;
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelExit.Location = new System.Drawing.Point(648, 0);
            this.labelExit.Margin = new System.Windows.Forms.Padding(0);
            this.labelExit.Name = "labelExit";
            this.labelExit.Padding = new System.Windows.Forms.Padding(3);
            this.labelExit.Size = new System.Drawing.Size(23, 30);
            this.labelExit.TabIndex = 3;
            this.labelExit.Text = "X";
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(217, 3);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(85, 24);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "قوائم معلقة";
            // 
            // dataGridViewSaveInvoices
            // 
            this.dataGridViewSaveInvoices.AllowUserToAddRows = false;
            this.dataGridViewSaveInvoices.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.dataGridViewSaveInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSaveInvoices.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridViewSaveInvoices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Changa Medium", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSaveInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSaveInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSaveInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnInvoiceNo,
            this.ColumnCustomerName,
            this.ColumnInvoiceTotal,
            this.ColumnInvoiceDate,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Changa Medium", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSaveInvoices.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSaveInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSaveInvoices.Location = new System.Drawing.Point(2, 32);
            this.dataGridViewSaveInvoices.MultiSelect = false;
            this.dataGridViewSaveInvoices.Name = "dataGridViewSaveInvoices";
            this.dataGridViewSaveInvoices.ReadOnly = true;
            this.dataGridViewSaveInvoices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewSaveInvoices.RowHeadersVisible = false;
            this.dataGridViewSaveInvoices.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewSaveInvoices.RowTemplate.Height = 50;
            this.dataGridViewSaveInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSaveInvoices.Size = new System.Drawing.Size(671, 706);
            this.dataGridViewSaveInvoices.TabIndex = 2;
            this.dataGridViewSaveInvoices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSaveInvoices_CellContentClick);
            this.dataGridViewSaveInvoices.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSaveInvoices_CellContentDoubleClick);
            // 
            // ColumnInvoiceNo
            // 
            this.ColumnInvoiceNo.DataPropertyName = "InvoiceNo";
            this.ColumnInvoiceNo.HeaderText = "رقم القائمة";
            this.ColumnInvoiceNo.Name = "ColumnInvoiceNo";
            this.ColumnInvoiceNo.ReadOnly = true;
            this.ColumnInvoiceNo.Width = 125;
            // 
            // ColumnCustomerName
            // 
            this.ColumnCustomerName.DataPropertyName = "CustomerName";
            this.ColumnCustomerName.HeaderText = "أسم الزبون";
            this.ColumnCustomerName.Name = "ColumnCustomerName";
            this.ColumnCustomerName.ReadOnly = true;
            this.ColumnCustomerName.Width = 175;
            // 
            // ColumnInvoiceTotal
            // 
            this.ColumnInvoiceTotal.DataPropertyName = "InvoiceTotalAmount";
            this.ColumnInvoiceTotal.HeaderText = "مبلغ القائمة";
            this.ColumnInvoiceTotal.Name = "ColumnInvoiceTotal";
            this.ColumnInvoiceTotal.ReadOnly = true;
            this.ColumnInvoiceTotal.Width = 150;
            // 
            // ColumnInvoiceDate
            // 
            this.ColumnInvoiceDate.DataPropertyName = "InvoiceDate";
            this.ColumnInvoiceDate.HeaderText = "تاريخ القائمة";
            this.ColumnInvoiceDate.Name = "ColumnInvoiceDate";
            this.ColumnInvoiceDate.ReadOnly = true;
            this.ColumnInvoiceDate.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "InvoicePaymentStatus";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "InvoiceRunORnot";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "InvoiceType";
            this.Column3.HeaderText = "نوع القائمة";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column4.HeaderText = "تحميل";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Text = "تحميل";
            this.Column4.UseColumnTextForButtonValue = true;
            // 
            // SavedInvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(675, 740);
            this.Controls.Add(this.dataGridViewSaveInvoices);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Changa Medium", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(500, 15);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximumSize = new System.Drawing.Size(675, 740);
            this.Name = "SavedInvoicesForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SavedInvoicesForm";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaveInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridViewSaveInvoices;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}