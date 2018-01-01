namespace Rresturant
{
    partial class ReportingMiniForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportingMiniForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAllitemsReport = new System.Windows.Forms.Button();
            this.buttonSaleInvoices = new System.Windows.Forms.Button();
            this.buttonBuyInvoices = new System.Windows.Forms.Button();
            this.buttonCoustomers = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 50);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Changa", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(223, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "التقارير";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Changa", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(500, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "التقارير";
            // 
            // buttonAllitemsReport
            // 
            this.buttonAllitemsReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAllitemsReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAllitemsReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.buttonAllitemsReport.FlatAppearance.BorderSize = 0;
            this.buttonAllitemsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAllitemsReport.ForeColor = System.Drawing.Color.Black;
            this.buttonAllitemsReport.Location = new System.Drawing.Point(34, 143);
            this.buttonAllitemsReport.Name = "buttonAllitemsReport";
            this.buttonAllitemsReport.Size = new System.Drawing.Size(100, 100);
            this.buttonAllitemsReport.TabIndex = 15;
            this.buttonAllitemsReport.Text = "المواد";
            this.buttonAllitemsReport.UseVisualStyleBackColor = true;
            this.buttonAllitemsReport.Click += new System.EventHandler(this.buttonAllitemsReport_Click);
            // 
            // buttonSaleInvoices
            // 
            this.buttonSaleInvoices.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSaleInvoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSaleInvoices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.buttonSaleInvoices.FlatAppearance.BorderSize = 0;
            this.buttonSaleInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaleInvoices.ForeColor = System.Drawing.Color.Black;
            this.buttonSaleInvoices.Location = new System.Drawing.Point(348, 143);
            this.buttonSaleInvoices.Name = "buttonSaleInvoices";
            this.buttonSaleInvoices.Size = new System.Drawing.Size(100, 100);
            this.buttonSaleInvoices.TabIndex = 16;
            this.buttonSaleInvoices.Text = "فواتير الشراء";
            this.buttonSaleInvoices.UseVisualStyleBackColor = true;
            this.buttonSaleInvoices.Click += new System.EventHandler(this.buttonSaleInvoices_Click);
            // 
            // buttonBuyInvoices
            // 
            this.buttonBuyInvoices.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBuyInvoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBuyInvoices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.buttonBuyInvoices.FlatAppearance.BorderSize = 0;
            this.buttonBuyInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuyInvoices.ForeColor = System.Drawing.Color.Black;
            this.buttonBuyInvoices.Location = new System.Drawing.Point(348, 249);
            this.buttonBuyInvoices.Name = "buttonBuyInvoices";
            this.buttonBuyInvoices.Size = new System.Drawing.Size(100, 100);
            this.buttonBuyInvoices.TabIndex = 17;
            this.buttonBuyInvoices.Text = "فواتير البيع";
            this.buttonBuyInvoices.UseVisualStyleBackColor = true;
            this.buttonBuyInvoices.Click += new System.EventHandler(this.buttonBuyInvoices_Click);
            // 
            // buttonCoustomers
            // 
            this.buttonCoustomers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCoustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCoustomers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.buttonCoustomers.FlatAppearance.BorderSize = 0;
            this.buttonCoustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCoustomers.ForeColor = System.Drawing.Color.Black;
            this.buttonCoustomers.Location = new System.Drawing.Point(34, 269);
            this.buttonCoustomers.Name = "buttonCoustomers";
            this.buttonCoustomers.Size = new System.Drawing.Size(100, 100);
            this.buttonCoustomers.TabIndex = 18;
            this.buttonCoustomers.Text = "الزبائن";
            this.buttonCoustomers.UseVisualStyleBackColor = true;
            this.buttonCoustomers.Click += new System.EventHandler(this.buttonCoustomers_Click);
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
            // ReportingMiniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.buttonCoustomers);
            this.Controls.Add(this.buttonBuyInvoices);
            this.Controls.Add(this.buttonSaleInvoices);
            this.Controls.Add(this.buttonAllitemsReport);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportingMiniForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReportingMiniForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAllitemsReport;
        private System.Windows.Forms.Button buttonSaleInvoices;
        private System.Windows.Forms.Button buttonBuyInvoices;
        private System.Windows.Forms.Button buttonCoustomers;
    }
}