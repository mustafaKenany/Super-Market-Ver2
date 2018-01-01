namespace Rresturant
{
    partial class CustomersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFilteritemsGrid = new System.Windows.Forms.TextBox();
            this.buttonPrintitemsGrid = new System.Windows.Forms.Button();
            this.button_showAllCustomers = new System.Windows.Forms.Button();
            this.dataGridView_displayCustomers = new System.Windows.Forms.DataGridView();
            this.ColumnCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalingInvoices = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnBuyingInvoices = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnSavedInvoices = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnSavePurshace = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNetAmount = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_displayCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 50);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Changa", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(500, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "الزبائن";
            // 
            // Exit
            // 
            this.Exit.Dock = System.Windows.Forms.DockStyle.Left;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Location = new System.Drawing.Point(0, 0);
            this.Exit.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(42, 50);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Exit.TabIndex = 2;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxFilteritemsGrid);
            this.panel2.Controls.Add(this.buttonPrintitemsGrid);
            this.panel2.Controls.Add(this.button_showAllCustomers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1125, 50);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Changa Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "ادخل كلمة للبحث";
            // 
            // textBoxFilteritemsGrid
            // 
            this.textBoxFilteritemsGrid.Font = new System.Drawing.Font("Changa Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.textBoxFilteritemsGrid.Location = new System.Drawing.Point(21, 9);
            this.textBoxFilteritemsGrid.Name = "textBoxFilteritemsGrid";
            this.textBoxFilteritemsGrid.Size = new System.Drawing.Size(293, 30);
            this.textBoxFilteritemsGrid.TabIndex = 6;
            this.textBoxFilteritemsGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxFilteritemsGrid.TextChanged += new System.EventHandler(this.textBoxFilteritemsGrid_TextChanged);
            // 
            // buttonPrintitemsGrid
            // 
            this.buttonPrintitemsGrid.AutoSize = true;
            this.buttonPrintitemsGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.buttonPrintitemsGrid.Font = new System.Drawing.Font("Changa Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrintitemsGrid.Location = new System.Drawing.Point(498, 3);
            this.buttonPrintitemsGrid.Name = "buttonPrintitemsGrid";
            this.buttonPrintitemsGrid.Size = new System.Drawing.Size(100, 40);
            this.buttonPrintitemsGrid.TabIndex = 5;
            this.buttonPrintitemsGrid.Text = "طباعة";
            this.buttonPrintitemsGrid.UseVisualStyleBackColor = false;
            // 
            // button_showAllCustomers
            // 
            this.button_showAllCustomers.AutoSize = true;
            this.button_showAllCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.button_showAllCustomers.Font = new System.Drawing.Font("Changa Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_showAllCustomers.Location = new System.Drawing.Point(604, 3);
            this.button_showAllCustomers.Name = "button_showAllCustomers";
            this.button_showAllCustomers.Size = new System.Drawing.Size(100, 40);
            this.button_showAllCustomers.TabIndex = 4;
            this.button_showAllCustomers.Text = "عرض الزبائن";
            this.button_showAllCustomers.UseVisualStyleBackColor = false;
            this.button_showAllCustomers.Click += new System.EventHandler(this.button_showAllCustomers_Click);
            // 
            // dataGridView_displayCustomers
            // 
            this.dataGridView_displayCustomers.AllowUserToAddRows = false;
            this.dataGridView_displayCustomers.AllowUserToDeleteRows = false;
            this.dataGridView_displayCustomers.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView_displayCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_displayCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_displayCustomers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_displayCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Changa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_displayCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_displayCustomers.ColumnHeadersHeight = 40;
            this.dataGridView_displayCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCustomerName,
            this.ColumnSalingInvoices,
            this.ColumnBuyingInvoices,
            this.ColumnSavedInvoices,
            this.ColumnSavePurshace,
            this.ColumnNetAmount});
            this.dataGridView_displayCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_displayCustomers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.dataGridView_displayCustomers.Location = new System.Drawing.Point(0, 100);
            this.dataGridView_displayCustomers.MultiSelect = false;
            this.dataGridView_displayCustomers.Name = "dataGridView_displayCustomers";
            this.dataGridView_displayCustomers.ReadOnly = true;
            this.dataGridView_displayCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_displayCustomers.RowHeadersVisible = false;
            this.dataGridView_displayCustomers.RowHeadersWidth = 45;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridView_displayCustomers.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_displayCustomers.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_displayCustomers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Changa", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.dataGridView_displayCustomers.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView_displayCustomers.RowTemplate.Height = 40;
            this.dataGridView_displayCustomers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_displayCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_displayCustomers.Size = new System.Drawing.Size(1125, 600);
            this.dataGridView_displayCustomers.TabIndex = 10;
            this.dataGridView_displayCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_displayCustomers_CellContentClick);
            // 
            // ColumnCustomerName
            // 
            this.ColumnCustomerName.DataPropertyName = "CustomerName";
            this.ColumnCustomerName.HeaderText = "اسم الزبون";
            this.ColumnCustomerName.Name = "ColumnCustomerName";
            this.ColumnCustomerName.ReadOnly = true;
            this.ColumnCustomerName.Width = 200;
            // 
            // ColumnSalingInvoices
            // 
            this.ColumnSalingInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSalingInvoices.HeaderText = "قوائم الشراء";
            this.ColumnSalingInvoices.Name = "ColumnSalingInvoices";
            this.ColumnSalingInvoices.ReadOnly = true;
            this.ColumnSalingInvoices.Text = "عرض";
            this.ColumnSalingInvoices.UseColumnTextForButtonValue = true;
            // 
            // ColumnBuyingInvoices
            // 
            this.ColumnBuyingInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnBuyingInvoices.HeaderText = "قوائم البيع";
            this.ColumnBuyingInvoices.Name = "ColumnBuyingInvoices";
            this.ColumnBuyingInvoices.ReadOnly = true;
            this.ColumnBuyingInvoices.Text = "عرض";
            this.ColumnBuyingInvoices.UseColumnTextForButtonValue = true;
            // 
            // ColumnSavedInvoices
            // 
            this.ColumnSavedInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSavedInvoices.HeaderText = "قوائم الببع المحفوظة";
            this.ColumnSavedInvoices.Name = "ColumnSavedInvoices";
            this.ColumnSavedInvoices.ReadOnly = true;
            this.ColumnSavedInvoices.Text = "عرض";
            this.ColumnSavedInvoices.UseColumnTextForButtonValue = true;
            this.ColumnSavedInvoices.Width = 150;
            // 
            // ColumnSavePurshace
            // 
            this.ColumnSavePurshace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSavePurshace.HeaderText = "قوائم الشراء المحفوظة";
            this.ColumnSavePurshace.Name = "ColumnSavePurshace";
            this.ColumnSavePurshace.ReadOnly = true;
            this.ColumnSavePurshace.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSavePurshace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSavePurshace.Text = "عرض";
            this.ColumnSavePurshace.UseColumnTextForButtonValue = true;
            this.ColumnSavePurshace.Width = 150;
            // 
            // ColumnNetAmount
            // 
            this.ColumnNetAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnNetAmount.HeaderText = "مجمل";
            this.ColumnNetAmount.Name = "ColumnNetAmount";
            this.ColumnNetAmount.ReadOnly = true;
            this.ColumnNetAmount.Text = "عرض";
            this.ColumnNetAmount.UseColumnTextForButtonValue = true;
            // 
            // CustomersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 700);
            this.Controls.Add(this.dataGridView_displayCustomers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(150, 15);
            this.Name = "CustomersForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CustomersForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_displayCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_showAllCustomers;
        private System.Windows.Forms.Button buttonPrintitemsGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFilteritemsGrid;
        private System.Windows.Forms.DataGridView dataGridView_displayCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerName;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSalingInvoices;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBuyingInvoices;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSavedInvoices;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSavePurshace;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnNetAmount;
    }
}