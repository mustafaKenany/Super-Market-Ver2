using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Rresturant
{
    public partial class prices_form : Form
    {
        DataTable dt = new DataTable ();
        DataTable changes = new DataTable ();
        BasicClass usedClass = new BasicClass ();
        bool changesInPriceFlag, changesInQuantityFlag;
        public prices_form()
        {
            InitializeComponent ();
            changes.Columns.Add ( "itemName" );
            changes.Columns.Add ( "column_price_or_quantity" );
            changesInPriceFlag = false;
            changesInQuantityFlag = false;

        }

        private void Exit_Click(object sender , EventArgs e)
        {
            prices_form.ActiveForm.Close ();
        }

        private void checkBox_all_items_without_price_CheckedChanged_1(object sender , EventArgs e)
        {
            if ( !checkBox_all_items_without_price.Checked )
            {
                dt.Rows.Clear ();
                dataGridViewPrices_displayitems.DataSource = dt;
            }
            else
            {
                dt.Rows.Clear ();

                txtprice_searchByitemName.Text = "";
                dataGridViewPrices_displayitems.Enabled = true;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter ( "@item" , SqlDbType.NVarChar , 150 );
                param[0].Value = 0;
                dt = usedClass.selectdata ( "Cahser_selectItemsPrices" , param );
                dataGridViewPrices_displayitems.DataSource = dt;
            }
        }

        private void txtprice_searchByitemName_KeyDown(object sender , KeyEventArgs e)
        {
            dt.Rows.Clear ();
            dataGridViewPrices_displayitems.DataSource = dt;

            checkBox_all_items_without_price.Checked = false;
            if ( e.KeyValue == (char) Keys.Enter )
            {
                if ( txtprice_searchByitemName.Text != "" )
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 50 );
                    param[0].Value = txtprice_searchByitemName.Text.Trim ();

                    dt = usedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
                    txtprice_searchByitemName.Text = "";
                    dataGridViewPrices_displayitems.DataSource = dt;
                }
            }
        }

        private void dataGridViewPrices_displayitems_CellValueChanged(object sender , DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex >= 0 )
            {
                switch ( dataGridViewPrices_displayitems.Columns[e.ColumnIndex].Name )
                {
                    case "Column_price_for_buy":
                        if ( dataGridViewPrices_displayitems.Rows[e.RowIndex].Cells["Column_price_for_buy"].Value.ToString () == "" )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "MESSAGE" );
                            dataGridViewPrices_displayitems.Rows[e.RowIndex].Cells["Column_price_for_buy"].Value = "1";

                        }
                        else if ( int.Parse ( dataGridViewPrices_displayitems.Rows[e.RowIndex].Cells["Column_price_for_buy"].Value.ToString () ) == 0 )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "MESSAGE" );
                            dataGridViewPrices_displayitems.Rows[e.RowIndex].Cells["Column_price_for_buy"].Value = "1";
                        }
                        else
                        {
                            changesInPriceFlag = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void button_changePrices_Click(object sender , EventArgs e)
        {
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter ( "@ID" , SqlDbType.Int );
            parameter[1] = new SqlParameter ( "@Price" , SqlDbType.Float );
            if ( dataGridViewPrices_displayitems.Rows.Count >= 0 && changesInPriceFlag )
            {
                for ( int i = 0 ; i < dataGridViewPrices_displayitems.Rows.Count ; i++ )
                {
                    parameter[0].Value = int.Parse ( dataGridViewPrices_displayitems.Rows[i].Cells["ColumnitemID"].Value.ToString () );
                    parameter[1].Value = float.Parse ( dataGridViewPrices_displayitems.Rows[i].Cells["Column_price_for_buy"].Value.ToString () );
                    usedClass.ExecuteCommand ( "Casher_UpdateItemsPrices" , parameter );
                }
                MessageBox.Show ( "DONE" , "MESSAGE" );
                changesInPriceFlag = false;
                dt.Rows.Clear ();
                dataGridViewPrices_displayitems.DataSource = dt;
                checkBox_all_items_without_price.Checked = false;
                txtprice_searchByitemName.Text = "";
                comboBoxPriceChooseCatg.DataSource = dt;
            }


        }

        private void comboBoxPriceChooseCatg_DropDown(object sender , EventArgs e)
        {
            dt = usedClass.selectdata ( "Casher_Get_All_Category" , null );
            comboBoxPriceChooseCatg.DataSource = dt;
            comboBoxPriceChooseCatg.DisplayMember = "CatergoryName";
            comboBoxPriceChooseCatg.ValueMember = "CategoryID";
        }

        private void comboBoxPriceChooseCatg_SelectedIndexChanged(object sender , EventArgs e)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 250 );
            param[0].Value = comboBoxPriceChooseCatg.Text;
            dt = usedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
            dataGridViewPrices_displayitems.DataSource = dt;
        }
        /// <summary>
        /// ///////////////////////////////////////////Above is Tab page 1 and below is TabPage 2////////////

        private void tabControl1_SelectedIndexChanged(object sender , EventArgs e)
        {
            DialogResult Result = new DialogResult ();
            if ( tabControlpricesAndQuantity.SelectedTab == tabPage_CorrectPrices )
            {
                if ( changesInQuantityFlag )
                {
                    Result = MessageBox.Show ( "هناك ارصدة تم تعديلها لم يتم حفظها اذا كنت تريد الحفظ اضغط نعم" , "Message" , MessageBoxButtons.YesNo , MessageBoxIcon.Exclamation );
                    if ( Result == DialogResult.Yes )
                    {
                        button_changePrices_Click ( sender , e );
                    }
                }

            }
            if ( tabControlpricesAndQuantity.SelectedTab == tabPage_correctQuantity )
            {
                if ( changesInPriceFlag )
                {
                    Result = MessageBox.Show ( "هناك اسعار تم تعديلها لم يتم حفظها اذا كنت تريد الحفظ اضغط نعم" , "Message" , MessageBoxButtons.YesNo , MessageBoxIcon.Exclamation );
                    if ( Result == DialogResult.Yes )
                    {
                        button_changeQuantity_Click ( sender , e );
                    }
                }
            }
        }

        private void checkBox_Allitems_without_quantity_CheckedChanged(object sender , EventArgs e)
        {
            if ( !checkBox_Allitems_without_quantity.Checked )
            {
                dt.Rows.Clear ();
                dataGridViewQuantity_displayitems.DataSource = dt;
            }
            else
            {
                dt.Rows.Clear ();
                comboBoxQuantity_allCategories.DataSource = dt;

                textBoxQuantity_itemName.Text = "";
                dataGridViewQuantity_displayitems.Enabled = true;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter ( "@item" , SqlDbType.NVarChar , 100 );
                param[0].Value = "0";
                dt = usedClass.selectdata ( "Casher_selectItemsWithoutQuantity" , param );
                dataGridViewQuantity_displayitems.DataSource = dt;
            }
        }

        private void textBoxQuantity_itemName_KeyDown(object sender , KeyEventArgs e)
        {
            dt.Rows.Clear ();
            dataGridViewQuantity_displayitems.DataSource = dt;
            comboBoxQuantity_allCategories.DataSource = dt;
            checkBox_Allitems_without_quantity.Checked = false;
            if ( e.KeyValue == (char) Keys.Enter )
            {
                if ( textBoxQuantity_itemName.Text != "" )
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 50 );
                    param[0].Value = textBoxQuantity_itemName.Text.Trim ();

                    dt = usedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
                    textBoxQuantity_itemName.Text = "";
                    dataGridViewQuantity_displayitems.DataSource = dt;
                }
            }
        }

        private void comboBoxQuantity_allCategories_SelectedIndexChanged(object sender , EventArgs e)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 250 );
            param[0].Value = comboBoxQuantity_allCategories.Text;
            dt = usedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
            dataGridViewQuantity_displayitems.DataSource = dt;
        }

        private void comboBoxQuantity_allCategories_DropDown(object sender , EventArgs e)
        {
            dt = usedClass.selectdata ( "Casher_Get_All_Category" , null );
            comboBoxQuantity_allCategories.DataSource = dt;
            comboBoxQuantity_allCategories.DisplayMember = "CatergoryName";
            comboBoxQuantity_allCategories.ValueMember = "CategoryID";
        }

        private void dataGridViewQuantity_displayitems_CellValueChanged(object sender , DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex >= 0 )
            {
                switch ( dataGridViewQuantity_displayitems.Columns[e.ColumnIndex].Name )
                {
                    case "ColumnQuantityCitical":
                        if ( dataGridViewQuantity_displayitems.Rows[e.RowIndex].Cells["ColumnQuantityCitical"].Value.ToString () == "" )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "MESSAGE" );
                            dataGridViewQuantity_displayitems.Rows[e.RowIndex].Cells["ColumnQuantityCitical"].Value = "0";
                        }
                        else
                        {
                            changesInQuantityFlag = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void button_changeQuantity_Click(object sender , EventArgs e)
        {
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter ( "@ID" , SqlDbType.Int );
            parameter[1] = new SqlParameter ( "@Quantity" , SqlDbType.Int );
            if ( dataGridViewQuantity_displayitems.Rows.Count >= 0 && changesInQuantityFlag )
            {
                for ( int i = 0 ; i < dataGridViewQuantity_displayitems.Rows.Count ; i++ )
                {
                    parameter[0].Value = int.Parse ( dataGridViewQuantity_displayitems.Rows[i].Cells["ColumnQuanItemID"].Value.ToString () );
                    parameter[1].Value = int.Parse ( dataGridViewQuantity_displayitems.Rows[i].Cells["ColumnQuantityCitical"].Value.ToString () );
                    usedClass.ExecuteCommand ( "Casher_UpdateStockQuantity" , parameter );
                }
                MessageBox.Show ( "DONE" , "MESSAGE" );
                changesInPriceFlag = false;
                dt.Rows.Clear ();
                dataGridViewQuantity_displayitems.DataSource = dt;
                checkBox_Allitems_without_quantity.Checked = false;
                textBoxQuantity_itemName.Text = "";
                comboBoxQuantity_allCategories.DataSource = dt;
            }
        }

    }
}
