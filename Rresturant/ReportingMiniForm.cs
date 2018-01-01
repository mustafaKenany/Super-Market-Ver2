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
    public partial class ReportingMiniForm : Form
    {
        public ReportingMiniForm()
        {
            InitializeComponent ();
        }

        private void Exit_Click(object sender , EventArgs e)
        {
            this.Close ();
        }

        private void buttonAllitemsReport_Click(object sender , EventArgs e)
        {
            var form = new itemsReportForm ();
            form.ShowDialog ();
        }

        private void buttonSaleInvoices_Click(object sender , EventArgs e)
        {
            var form = new SaleReportForm ();
            form.ShowDialog ();
        }

        private void buttonBuyInvoices_Click(object sender , EventArgs e)
        {
            var form = new BuyReportForm ();
            form.ShowDialog ();
        }

        private void buttonCoustomers_Click(object sender , EventArgs e)
        {
            var form = new CustomersForm ();
            form.ShowDialog ();
        }
    }
}
