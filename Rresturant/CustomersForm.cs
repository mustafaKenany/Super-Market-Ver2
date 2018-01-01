using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Rresturant
{
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent ();
        }

        private void Exit_Click(object sender , EventArgs e)
        {
            this.Close ();
        }

        private void button_showAllCustomers_Click(object sender , EventArgs e)
        {
            var usedClass = new BasicClass ();
            var dt = new DataTable ();

            dt = usedClass.selectdata ( "Reports_Select_Users" , null );
            dataGridView_displayCustomers.DataSource = dt;
        }

        private void dataGridView_displayCustomers_CellContentClick(object sender , DataGridViewCellEventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            var crp = new Reports.CustomerReports_Sale_buy ();
            var form = new PrintForm ();
            TextObject CustomerName = (TextObject) crp.ReportDefinition.Sections["Section1"].ReportObjects["Text2"];
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter ( "@CustomerName" , SqlDbType.NVarChar , 250 );
            param[1] = new SqlParameter ( "@InvoiceType" , SqlDbType.NVarChar , 250 );
            param[2] = new SqlParameter ( "@InvoiceStatus" , SqlDbType.NVarChar , 250 );


            if ( e.RowIndex >= 0 )
            {
                param[0].Value = dataGridView_displayCustomers.Rows[e.RowIndex].Cells["ColumnCustomerName"].Value.ToString ();
                CustomerName.Text = dataGridView_displayCustomers.Rows[e.RowIndex].Cells["ColumnCustomerName"].Value.ToString ();
                switch ( e.ColumnIndex )
                {
                    case 0:
                        //invoiceType.Text = "فواتير الشراء";
                        param[1].Value = "شراء";
                        param[2].Value = "Run";
                        dt = UsedClass.selectdata ( "Reports_Customers_Select_invoicesDepandonInvoiceType_and_invoiceStatus" , param );
                        crp.SetDataSource ( dt );
                        form.crystalReportViewer1.ReportSource = crp;
                        if ( dt.Rows.Count == 0 )
                        {

                            MessageBox.Show ( "لا توجد بيانات لعرضها" , "MESSAGE" );
                        }
                        else
                        {
                            form.ShowDialog ();
                        }
                        break;
                    case 1:
                        //invoiceType.Text = "فواتير البيع";
                        param[1].Value = "بيع";
                        param[2].Value = "Run";
                        dt = UsedClass.selectdata ( "Reports_Customers_Select_invoicesDepandonInvoiceType_and_invoiceStatus" , param );
                        crp.SetDataSource ( dt );
                        form.crystalReportViewer1.ReportSource = crp;
                        if ( dt.Rows.Count == 0 )
                        {
                            MessageBox.Show ( "لا توجد بيانات لعرضها" , "MESSAGE" );
                        }
                        else
                        {
                            form.ShowDialog ();
                        }
                        //crp.SetDataSource ( dt );
                        //form.crystalReportViewer1.ReportSource = crp;
                        //form.ShowDialog ();
                        break;
                    case 2:
                        //invoiceType.Text = "فواتير المحجوزة";
                        param[1].Value = "بيع";
                        param[2].Value = "Save";
                        dt = UsedClass.selectdata ( "Reports_Customers_Select_invoicesDepandonInvoiceType_and_invoiceStatus" , param );
                        crp.SetDataSource ( dt );
                        form.crystalReportViewer1.ReportSource = crp;
                        if ( dt.Rows.Count == 0 )
                        {
                            MessageBox.Show ( "لا توجد بيانات لعرضها" , "MESSAGE" );
                        }
                        else
                        {
                            form.ShowDialog ();
                        }

                        break;
                    case 3:
                        param[1].Value = "شراء";
                        param[2].Value = "Save";
                        dt = UsedClass.selectdata ( "Reports_Customers_Select_invoicesDepandonInvoiceType_and_invoiceStatus" , param );
                        crp.SetDataSource ( dt );
                        form.crystalReportViewer1.ReportSource = crp;
                        if ( dt.Rows.Count == 0 )
                        {
                            MessageBox.Show ( "لا توجد بيانات لعرضها" , "MESSAGE" );
                        }
                        else
                        {
                            form.ShowDialog ();
                        }

                        break;
                    case 4:
                        SqlParameter[] parameter = new SqlParameter[1];
                        parameter[0] = new SqlParameter ( "@CustomerName" , SqlDbType.NVarChar , 150 );
                        parameter[0].Value = dataGridView_displayCustomers.Rows[e.RowIndex].Cells["ColumnCustomerName"].Value.ToString ();
                        dt = UsedClass.selectdata ( "Reports_Summery" , parameter );
                        var Crp2 = new Reports.SummeryReport ();
                        Crp2.SetDataSource ( dt );
                        form.crystalReportViewer1.ReportSource = Crp2;
                        if ( dt.Rows.Count == 0 )
                        {
                            MessageBox.Show ( "لا توجد بيانات لعرضها" , "MESSAGE" );
                        }
                        else
                        {
                            form.ShowDialog ();
                        }
                       
                        break;
                    default:
                        break;
                }
            }
        }

        private void textBoxFilteritemsGrid_TextChanged(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@Filter" , SqlDbType.NVarChar );

            if ( textBoxFilteritemsGrid.Text != "" )
            {
                param[0].Value = textBoxFilteritemsGrid.Text.Trim ();
                dt = UsedClass.selectdata ( "Reports_SelectUsers_byFilter" , param );
                dataGridView_displayCustomers.DataSource = dt;
            }
            else
            {

                dt = UsedClass.selectdata ( "Reports_Select_Users" , null );
                dataGridView_displayCustomers.DataSource = dt;
            }
        }
    }
}
