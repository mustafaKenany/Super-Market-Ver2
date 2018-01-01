using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Rresturant.View
{
    public partial class SavedInvoicesForm : Form
    {
        public SavedInvoicesForm()
        {
            InitializeComponent ();
            
        }

        public void LoadSaveInvoices(string type)
        {
            var UsedClass = new BasicClass ();
            var dt = new DataTable ();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter ( "@Filter" , SqlDbType.NVarChar , 150 );
            param[0].Value = "SAVE";
            param[1] = new SqlParameter ( "@Type" , SqlDbType.NVarChar , 150 );
            param[1].Value = type;
            dt = UsedClass.selectdata ( "Casher_Select_SaveInvoices" , param );
            dataGridViewSaveInvoices.DataSource = dt.DefaultView;

        }

        private void labelExit_Click(object sender , EventArgs e)
        {
            this.Close ();
        }

        private void dataGridViewSaveInvoices_CellContentDoubleClick(object sender , DataGridViewCellEventArgs e)
        {
            if ( e.ColumnIndex >= 0 )
            {
                if ( e.RowIndex >= 0 )
                {
                    BasicClass.UnrnningBillId = Convert.ToInt16 ( dataGridViewSaveInvoices.Rows[e.RowIndex].Cells["ColumnInvoiceNo"].Value.ToString () );
                    BasicClass.flagModified = true;
                    this.Close ();

                }
            }
        }

        private void dataGridViewSaveInvoices_CellContentClick(object sender , DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex>=0 )
            {
                if ( e.ColumnIndex==0 )
                {
                    var InvoiceType = dataGridViewSaveInvoices.Rows[e.RowIndex].Cells["Column3"].Value.ToString ();
                    if ( InvoiceType=="شراء" )
                    {
                        var form = new View.PurshaceForm ();
                        form.EnableControlling ();
                        BasicClass.UnrnningBillId = Convert.ToInt16 ( dataGridViewSaveInvoices.Rows[e.RowIndex].Cells["ColumnInvoiceNo"].Value.ToString () );

                       
                        form.ShowDialog ();
                        this.Close ();
                    }
                    else
                    {
                        var form = new View.CacherForm ();
                        form.EnableControlling ();
                        BasicClass.UnrnningBillId = Convert.ToInt16 ( dataGridViewSaveInvoices.Rows[e.RowIndex].Cells["ColumnInvoiceNo"].Value.ToString () );


                        form.ShowDialog ();
                        this.Close ();
                    }
                }
            }
        }
    }
}
