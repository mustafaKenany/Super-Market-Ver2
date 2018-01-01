using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Rresturant
{
    public partial class BuyReportForm : Form
    {
        public BuyReportForm()
        {
            InitializeComponent ();
            dataGridViewBuyGridInvoice.Columns["ColumnInvoiceDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private void Exit_Click(object sender , EventArgs e)
        {
            this.Close ();
        }

        private void buttonShowBuyInvoices_Click(object sender , EventArgs e)
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

                param[0].Value = "بيع";
                param[1].Value = dateTimePickerFrom.Text.ToString ();
                param[2].Value = dateTimePickerTo.Text.ToString ();
                param[3].Value = "RUN";
                dt = usedClass.selectdata ( "Report_Select_invoices_usingDates_and_InvoiceType" , param );
                dataGridViewBuyGridInvoice.DataSource = dt;
            }
            else
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter ( "@InvoiceType" , SqlDbType.NChar , 250 );
                param[1] = new SqlParameter ( "@InvoiceStatus" , SqlDbType.NChar , 250 );
                param[0].Value = "بيع";
                param[1].Value = "RUN";
                dt = usedClass.selectdata ( "Report_SelectAll_Invoices_usingType" , param );
                dataGridViewBuyGridInvoice.DataSource = dt;
            }

        }

        private void textBoxFilterBuyGrid_TextChanged(object sender , EventArgs e)
        {
            var usedClass = new BasicClass ();
            var dt = new DataTable ();
            if ( textBoxFilterBuyGrid.Text != "" )
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter ( "@InvoiceType" , SqlDbType.NChar , 250 );
                param[1] = new SqlParameter ( "@Filter" , SqlDbType.NVarChar , 250 );
                param[2] = new SqlParameter ( "@InvoiceStatus" , SqlDbType.NVarChar , 250 );
                param[0].Value = "بيع";
                param[1].Value = textBoxFilterBuyGrid.Text;
                param[2].Value = "RUN";

                dt = usedClass.selectdata ( "Report_SelectAll_Invoices_usingTypeAndFilter" , param );
                dataGridViewBuyGridInvoice.DataSource = dt;
            }
            else
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter ( "@InvoiceType" , SqlDbType.NChar , 250 );
                param[1] = new SqlParameter ( "@InvoiceStatus" , SqlDbType.NChar , 250 );
                param[0].Value = "بيع";
                param[1].Value = "RUN";
                dt = usedClass.selectdata ( "Report_SelectAll_Invoices_usingType" , param );
                dataGridViewBuyGridInvoice.DataSource = dt;
            }
        }

        private void dataGridViewBuyGridInvoice_CellContentClick(object sender , DataGridViewCellEventArgs e)
        {
            var crp = new Reports.SaleInvoiceReport ();
            var dt = new DataTable ();
            var usedClass = new BasicClass ();
            var form = new PrintForm ();
            if ( e.ColumnIndex == 0 )
            {
                if ( e.RowIndex >= 0 )
                {
                    int InvoiceNo = int.Parse ( dataGridViewBuyGridInvoice.Rows[e.RowIndex].Cells["ColumnInvoiceNo"].Value.ToString () );
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter ( "@InvoiceNo" , SqlDbType.Int );
                    param[0].Value = InvoiceNo;
                    dt = usedClass.selectdata ( "Report_Select_SaleInvoice_usingInvoiceNo" , param );
                    string y = string.Concat ( crp.DataDefinition.FormulaFields["ItemQuantity"].Text , "*-1" );
                    crp.DataDefinition.FormulaFields["ItemQuantity"].Text = y;
                    TextObject InvoicePayment = (TextObject) crp.ReportDefinition.Sections["Section1"].ReportObjects["Text7"];
                    InvoicePayment.Text = dataGridViewBuyGridInvoice.Rows[e.RowIndex].Cells["ColumnInvoiceStatus"].Value.ToString ();
                    TextObject InvoiceType = (TextObject) crp.ReportDefinition.Sections["Section1"].ReportObjects["Text17"];
                    InvoiceType.Text = "قائمة بيع";

                    crp.SetDataSource ( dt );
                    form.crystalReportViewer1.ReportSource = crp;
                    form.ShowDialog ();           
                }
            }
        }

        private void buttonPrintBuyGrid_Click(object sender , EventArgs e)
        {
            var crp = new Reports.InvoicesGridReport ();
            var form = new PrintForm ();
            crp.SetDataSource ( dataGridViewBuyGridInvoice.DataSource );
            TextObject InvoiceType = (TextObject) crp.ReportDefinition.Sections["Section1"].ReportObjects["Text1"];
            InvoiceType.Text = "تقرير شامل لكل قوائم البيع مع كافة تفاصيل";
            form.crystalReportViewer1.ReportSource = crp;
            form.ShowDialog ();
        }
    }
}
