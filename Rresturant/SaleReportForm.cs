using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Rresturant
{
    public partial class SaleReportForm : Form
    {
        public SaleReportForm()
        {
            InitializeComponent ();
            dataGridViewSaleGrid.Columns["ColumnInvoiceDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private void Exit_Click(object sender , EventArgs e)
        {
            this.Close ();
        }

        private void buttonShowSaleInvoices_Click(object sender , EventArgs e)
        {
            var usedClass = new BasicClass ();
            var dt = new DataTable ();
            if ( checkBoxDateSearch.Checked )
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter ( "@InvoiceType" , SqlDbType.NVarChar , 250 );
                param[1] = new SqlParameter ( "@beginDate" , SqlDbType.NVarChar , 250 );
                param[2] = new SqlParameter ( "@endDate" , SqlDbType.NVarChar , 250 );
                param[3] = new SqlParameter ( "@invoiceStatus" , SqlDbType.NVarChar , 150 );

                param[0].Value = "شراء";
                param[1].Value = dateTimePickerFrom.Text.ToString ();
                param[2].Value = dateTimePickerTo.Text.ToString ();
                param[3].Value = "RUN";
                dt = usedClass.selectdata ( "Report_Select_invoices_usingDates_and_InvoiceType" , param );
                dataGridViewSaleGrid.DataSource = dt;
            }
            else
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter ( "@InvoiceType" , SqlDbType.NChar , 250 );
                param[1] = new SqlParameter ( "@InvoiceStatus" , SqlDbType.NChar , 250 );
                param[0].Value = "شراء";
                param[1].Value = "RUN";
                dt = usedClass.selectdata ( "Report_SelectAll_Invoices_usingType" , param );
                dataGridViewSaleGrid.DataSource = dt;
            }

        }

        private void textBoxFilterSalesGrid_TextChanged(object sender , EventArgs e)
        {
            var usedClass = new BasicClass ();
            var dt = new DataTable ();
            if ( textBoxFilterSalesGrid.Text != "" )
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter ( "@InvoiceType" , SqlDbType.NChar , 250 );
                param[1] = new SqlParameter ( "@Filter" , SqlDbType.NVarChar , 250 );
                param[2] = new SqlParameter ( "@InvoiceStatus" , SqlDbType.NVarChar , 250 );
                param[0].Value = "شراء";
                param[1].Value = textBoxFilterSalesGrid.Text;
                param[2].Value = "RUN";

                dt = usedClass.selectdata ( "Report_SelectAll_Invoices_usingTypeAndFilter" , param );
                dataGridViewSaleGrid.DataSource = dt;
            }
            else
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter ( "@InvoiceType" , SqlDbType.NChar , 250 );
                param[1] = new SqlParameter ( "@InvoiceStatus" , SqlDbType.NChar , 250 );
                param[0].Value = "شراء";
                param[1].Value = "RUN";
                dt = usedClass.selectdata ( "Report_SelectAll_Invoices_usingType" , param );
                dataGridViewSaleGrid.DataSource = dt;
            }
        }

        private void dataGridViewSaleGrid_CellContentClick(object sender , DataGridViewCellEventArgs e)
        {
            var crp = new Reports.SaleInvoiceReport ();
            var dt = new DataTable ();
            var usedClass = new BasicClass ();
            var form = new PrintForm ();

            if ( e.ColumnIndex == 0 )
            {
                if ( e.RowIndex >= 0 )
                {

                    string InvoiceNo = dataGridViewSaleGrid.Rows[e.RowIndex].Cells["ColumnInvoiceNo"].Value.ToString ();
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter ( "@InvoiceNo" , SqlDbType.Int );
                    param[0].Value = int.Parse ( InvoiceNo );
                    dt = usedClass.selectdata ( "Report_Select_SaleInvoice_usingInvoiceNo" , param );
                    TextObject InvoicePayment = (TextObject) crp.ReportDefinition.Sections["Section1"].ReportObjects["Text7"];
                    InvoicePayment.Text = dataGridViewSaleGrid.Rows[e.RowIndex].Cells["ColumnInvoiceStatus"].Value.ToString ();
                    TextObject InvoiceType = (TextObject) crp.ReportDefinition.Sections["Section1"].ReportObjects["Text17"];
                    InvoiceType.Text = "قائمة شراء";
                    crp.SetDataSource ( dt );
                    form.crystalReportViewer1.ReportSource = crp;
                    form.ShowDialog ();

                }
            }
        }

        private void buttonPrintSalesGrid_Click(object sender , EventArgs e)
        {
            var crp = new Reports.InvoicesGridReport ();
            var form = new PrintForm ();
            crp.SetDataSource ( dataGridViewSaleGrid.DataSource );
            TextObject InvoiceType = (TextObject) crp.ReportDefinition.Sections["Section1"].ReportObjects["Text1"];
            InvoiceType.Text = "تقرير شامل لكل قوائم الشراء مع كافة تفاصيل";
            form.crystalReportViewer1.ReportSource = crp;
            form.ShowDialog ();
        }
    }
}
