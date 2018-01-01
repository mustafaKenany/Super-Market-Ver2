using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rresturant
{
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            this.crystalReportViewer1.RefreshReport();
           
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.Width = 75;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            prices_form.ActiveForm.Close();
        }
    }
}
