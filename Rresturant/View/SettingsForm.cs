using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Rresturant.View
{
    public partial class SettingsForm : Form
    {

        //DataTable changesInItems = new DataTable ();
        //DataTable changesInUsers = new DataTable ();
        Boolean changesInItemFlag = false;
        Boolean changesInUserFlag = false;
        public SettingsForm()
        {
            InitializeComponent ();
            //changesInItems.Columns.Add ( "itemID" );
            //changesInItems.Columns.Add ( "itemName" );
            //changesInItems.Columns.Add ( "itemCategory" );
            //changesInItems.Columns.Add ( "itemCriticalRange" );
            //changesInItems.Columns.Add ( "itemPCS" );
            //changesInItems.Columns.Add ( "itemExpireDate" );
            //changesInItems.Columns.Add ( "itemBarCode" );
            //changesInUsers.Columns.Add ( "FullName" );

            labelUserName.Text = BasicClass.UserName;
        }

        private void labelExit_Click(object sender , EventArgs e)
        {
            this.Close ();
        }

        private void comboBoxnewItemCategory_DropDown(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            dt = UsedClass.selectdata ( "Casher_Get_All_Category" , null );
            comboBoxnewItemCategory.DataSource = dt;
            comboBoxnewItemCategory.DisplayMember = "CatergoryName";
            comboBoxnewItemCategory.ValueMember = "CategoryID";
        }

        private void buttonnewItemSave_Click(object sender , EventArgs e)
        {
            if ( textBoxnewItemEnterName.Text == "" || comboBoxnewItemCategory.Text == "" )
            {
                MessageBox.Show ( "يرجى التأكد من ادخال المعلومات بشكل كامل" , "خــــطأ" , MessageBoxButtons.OK , MessageBoxIcon.Warning );

            }
            else
            {

                var dt = new DataTable ();
                var UsedClass = new BasicClass ();
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter ( "@ItemID" , SqlDbType.Int );
                param[1] = new SqlParameter ( "@itemName" , SqlDbType.NVarChar , 150 );
                param[2] = new SqlParameter ( "@itemCategory" , SqlDbType.NVarChar , 150 );
                param[3] = new SqlParameter ( "@PcsInsideCarton" , SqlDbType.Int );
                param[4] = new SqlParameter ( "@CriticalQuantity" , SqlDbType.Int );
                param[5] = new SqlParameter ( "@ItemBarcode" , SqlDbType.NVarChar , 150 );
                param[6] = new SqlParameter ( "@EnteredUser" , SqlDbType.NVarChar , 150 );
                param[7] = new SqlParameter ( "@ItemExpire" , SqlDbType.NVarChar , 150 );
                param[0].Value = getInformation ( "ItemID" );
                param[1].Value = textBoxnewItemEnterName.Text.Trim ();
                param[2].Value = comboBoxnewItemCategory.Text.Trim ();
                param[3].Value = int.Parse ( textBoxnewItemEnterPCS.Text.Trim () );
                param[4].Value = int.Parse ( textBoxnewItemEnterCriticalRange.Text.Trim () );
                param[5].Value = textBoxnewItemEnterBarcode.Text.Trim ();
                param[6].Value = BasicClass.UserName;
                if ( checkBoxnewItemExpire.Checked )
                {
                    param[7].Value = dateTimePickernewItemExpire.Text.Trim ();
                }
                else
                {
                    param[7].Value = "لايوجد";
                }
                UsedClass.ExecuteCommand ( "Casher_create_new_items" , param );
                MessageBox.Show ( "DONE" , "Message" );
                ClearRecords ();

            }
        }

        private void ClearRecords()
        {
            var dt = new DataTable ();
            dt.Rows.Clear ();
            comboBoxnewItemCategory.DataSource = dt;
            textBoxnewItemEnterName.Text = "";
            textBoxnewItemEnterBarcode.Text = "0";
            checkBoxnewItemExpire.Checked = false;
            textBoxnewItemEnterCriticalRange.Text = "0";
            textBoxnewItemEnterPCS.Text = "0";

            //Users Section
            textBoxnewUserFullName.Text = "";
            textBoxnewUserUserName.Text = "";
            textBoxnewUserPassword.Text = "";
            checkBoxSuperUser.Checked = false;
            checkBoxCasherPermision.Checked = false;
            checkBoxReportPermision.Checked = false;
            checkBoxPurshacePermision.Checked = false;

        }

        private int getInformation(string ID)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            dt = UsedClass.selectdata ( "Casher_select_all_IDs" , null );

            if ( dt.Rows.Count > 0 )
            {
                switch ( ID )
                {
                    case "ItemID":
                        var ItemID = int.Parse ( dt.Rows[0]["ItemID"].ToString () );
                        return ItemID;
                    case "CatID":
                        var CatID = int.Parse ( dt.Rows[0]["CategoryID"].ToString () );
                        return CatID;

                    default:
                        break;
                }
            }
            return 0;

        }

        private void buttonnewItemCancel_Click(object sender , EventArgs e)
        {
            ClearRecords ();
        }

        private void textBoxEditItemSearch_TextChanged(object sender , EventArgs e)
        {
            if ( textBoxEditItemSearch.Text != "" )
            {
                var dt = new DataTable ();
                var UsedClass = new BasicClass ();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 200 );
                param[0].Value = textBoxEditItemSearch.Text.Trim ();
                dt = UsedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
                dataGridVieweditItem.DataSource = dt;
                //changesInItems = dt;  //make copy from this dataTable         

            }
        }

        private void dataGridVieweditItem_CellValueChanged(object sender , DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex >= 0 )
            {
                switch ( dataGridVieweditItem.Columns[e.ColumnIndex].Name )
                {
                    case "ColumnItemName":
                        if ( dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnItemName"].Value.ToString () == "" )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );

                        }
                        else
                        {
                            //changesInItems.Rows[e.RowIndex]["itemName"] = dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnItemName"].Value.ToString ();
                            changesInItemFlag = true;
                        }
                        break;
                    case "ColumnpcsCarton":
                        if ( dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnpcsCarton"].Value.ToString () == "" )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
                        }
                        else
                        {
                            //changesInItems.Rows[e.RowIndex]["Pcs_InsideCarton"] = dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnpcsCarton"].Value.ToString ();
                            changesInItemFlag = true;
                        }
                        break;
                    case "ColumnCriticalRange":
                        if ( dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnCriticalRange"].Value.ToString () == "" )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
                        }
                        else
                        {
                            //changesInItems.Rows[e.RowIndex]["Critical_Quantity"] = dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnCriticalRange"].Value.ToString ();
                            changesInItemFlag = true;
                        }
                        break;
                    case "ColumnBarcode":
                        if ( dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnBarcode"].Value.ToString () == "" )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
                        }
                        else
                        {
                            //changesInItems.Rows[e.RowIndex]["ItemBarCode"] = dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnBarcode"].Value.ToString ();
                            changesInItemFlag = true;
                        }
                        break;
                    case "ColumnExpireDate":
                        if ( dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnExpireDate"].Value.ToString () == "" )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
                        }
                        else
                        {
                            //changesInItems.Rows[e.RowIndex]["ItemExpire"] = dataGridVieweditItem.Rows[e.RowIndex].Cells["ColumnExpireDate"].Value.ToString ();
                            changesInItemFlag = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void buttonedititem_Click(object sender , EventArgs e)
        {
            var UsedClass = new BasicClass ();
            var dt = new DataTable ();
            SqlParameter[] param = new SqlParameter[7];
            if ( changesInItemFlag )
            {
                param[0] = new SqlParameter ( "@itemID" , SqlDbType.Int );
                param[1] = new SqlParameter ( "@itemName" , SqlDbType.NVarChar , 100 );
                param[2] = new SqlParameter ( "@itemCategory" , SqlDbType.NVarChar , 100 );
                param[3] = new SqlParameter ( "@Barcode" , SqlDbType.NVarChar , 100 );
                param[4] = new SqlParameter ( "@ExpireDate" , SqlDbType.NVarChar , 100 );
                param[5] = new SqlParameter ( "@CriticalRange" , SqlDbType.Int );
                param[6] = new SqlParameter ( "@PCS" , SqlDbType.Int );
                for ( int i = 0 ; i < dataGridVieweditItem.Rows.Count ; i++ )
                {
                    param[0].Value = int.Parse ( dataGridVieweditItem.Rows[i].Cells["ColumnItemID"].Value.ToString () );
                    param[1].Value = dataGridVieweditItem.Rows[i].Cells["ColumnItemName"].Value.ToString ();
                    param[2].Value = dataGridVieweditItem.Rows[i].Cells["ColumnItemCategory"].Value.ToString ();
                    param[3].Value = dataGridVieweditItem.Rows[i].Cells["ColumnBarcode"].Value.ToString ();
                    param[4].Value = dataGridVieweditItem.Rows[i].Cells["ColumnExpireDate"].Value.ToString ();
                    param[5].Value = int.Parse ( dataGridVieweditItem.Rows[i].Cells["ColumnCriticalRange"].Value.ToString () );
                    param[6].Value = int.Parse ( dataGridVieweditItem.Rows[i].Cells["ColumnpcsCarton"].Value.ToString () );
                    UsedClass.ExecuteCommand ( "Casher_settingUpdateItem" , param );
                }
                changesInItemFlag = false;
                MessageBox.Show ( "DONE" , "MESSAGE" );
                textBoxEditItemSearch_TextChanged ( sender , e );
            }
            else
            {

            }

            //if ( changesInItems.Rows.Count > 0 && changesInItemFlag == true )
            //{
            //    param[0] = new SqlParameter ( "@itemID" , SqlDbType.Int );
            //    param[1] = new SqlParameter ( "@itemName" , SqlDbType.NVarChar , 100 );
            //    param[2] = new SqlParameter ( "@itemCategory" , SqlDbType.NVarChar , 100 );
            //    param[3] = new SqlParameter ( "@Barcode" , SqlDbType.NVarChar , 100 );
            //    param[4] = new SqlParameter ( "@ExpireDate" , SqlDbType.NVarChar , 100 );
            //    param[5] = new SqlParameter ( "@CriticalRange" , SqlDbType.Int );
            //    param[6] = new SqlParameter ( "@PCS" , SqlDbType.Int );

            //    for ( int i = 0 ; i < changesInItems.Rows.Count ; i++ )
            //    {
            //        param[0].Value = changesInItems.Rows[i]["ItemID"].ToString ();
            //        param[1].Value = changesInItems.Rows[i]["ItemName"].ToString ();
            //        param[2].Value = changesInItems.Rows[i]["itemCategory"].ToString ();
            //        param[3].Value = changesInItems.Rows[i]["ItemBarCode"].ToString ();
            //        param[4].Value = changesInItems.Rows[i]["ItemExpire"].ToString ();
            //        param[5].Value = int.Parse ( changesInItems.Rows[i]["Critical_Quantity"].ToString () );
            //        param[6].Value = int.Parse ( changesInItems.Rows[i]["Pcs_InsideCarton"].ToString () );
            //        UsedClass.ExecuteCommand ( "Casher_settingUpdateItem" , param );
            //    }
            //    changesInItemFlag = false;
            //    MessageBox.Show ( "DONE" , "MESSAGE" );
            //    textBoxEditItemSearch_TextChanged ( sender , e );
            //}

        }

        private void buttondeleteItem_Click(object sender , EventArgs e)
        {
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@ItemID" , SqlDbType.Int );
            if ( dataGridVieweditItem.CurrentRow.Index >= 0 )
            {
                if ( dataGridVieweditItem.Rows[dataGridVieweditItem.CurrentRow.Index].Cells["ColumnItemID"].Value.ToString () != "" )
                {
                    param[0].Value = int.Parse ( dataGridVieweditItem.Rows[dataGridVieweditItem.CurrentRow.Index].Cells["ColumnItemID"].Value.ToString () );
                    UsedClass.ExecuteCommand ( "Casher_deleteItem" , param );
                    MessageBox.Show ( "DONE" , "MESSAGE" );
                    textBoxEditItemSearch_TextChanged ( sender , e );
                }
            }
        }

        private void buttonnewCatSave_Click(object sender , EventArgs e)
        {
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter ( "@CategoryID" , SqlDbType.Int );
            param[1] = new SqlParameter ( "@categoryName" , SqlDbType.NVarChar , 50 );
            param[2] = new SqlParameter ( "@EnteredUser" , SqlDbType.NVarChar , 50 );
            if ( textBoxnewCatEnterCatName.Text == "" )
            {
                MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
            }
            else
            {
                param[0].Value = getInformation ( "CatID" );
                param[1].Value = textBoxnewCatEnterCatName.Text.Trim ();
                param[2].Value = BasicClass.UserName;
                UsedClass.ExecuteCommand ( "Casher_create_new_category" , param );
                MessageBox.Show ( "DONE" , "MESSAGE" );
                textBoxnewCatEnterCatName.Text = "";
            }
        }

        private void comboBoxeditChooseCat_DropDown(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            dt = UsedClass.selectdata ( "Casher_Get_All_Category" , null );
            comboBoxeditChooseCat.DataSource = dt;
            comboBoxeditChooseCat.DisplayMember = "CatergoryName";
            comboBoxeditChooseCat.ValueMember = "CategoryID";

        }

        private void buttoneditCatSave_Click(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter ( "@CategoryID" , SqlDbType.Int );
            param[1] = new SqlParameter ( "@CategoryName" , SqlDbType.NVarChar , 100 );
            if ( textBoxeditCatEnter.Text == "" )
            {
                MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
            }
            else
            {
                param[0].Value = int.Parse ( comboBoxeditChooseCat.SelectedValue.ToString () );
                param[1].Value = textBoxeditCatEnter.Text.Trim ();
                UsedClass.ExecuteCommand ( "Casher_Re_nameCategory" , param );
                MessageBox.Show ( "DONE" , "MESSAGE" );
                textBoxeditCatEnter.Text = "";
                dt.Rows.Clear ();
                comboBoxeditChooseCat.DataSource = dt;

            }
        }

        private void comboBoxdeletechooseCat_DropDown(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            dt = UsedClass.selectdata ( "Casher_Get_All_Category" , null );
            comboBoxdeletechooseCat.DataSource = dt;
            comboBoxdeletechooseCat.DisplayMember = "CatergoryName";
            comboBoxdeletechooseCat.ValueMember = "CategoryID";
        }

        private void buttondeleteCatSave_Click(object sender , EventArgs e)
        {
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@CategoryID" , SqlDbType.Int );
            if ( comboBoxdeletechooseCat.Text == "" )
            {
                MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
            }
            else
            {
                param[0].Value = int.Parse ( ( comboBoxdeletechooseCat.SelectedValue.ToString () ) );
                DialogResult Result = MessageBox.Show ( "عملية الحذف سوف تؤدي الى حذف العناصر التي تنتمي لهذا الصنف" , "Confirmation" , MessageBoxButtons.YesNo , MessageBoxIcon.Hand );
                if ( Result == DialogResult.Yes )
                {
                    UsedClass.ExecuteCommand ( "Casher_deleteCategory" , param );
                    MessageBox.Show ( "DONE" , "MESSAGE" );
                    comboBoxdeletechooseCat_DropDown ( sender , e );
                }
                else
                {

                }

            }
        }

        private void checkBoxSuperUser_CheckedChanged(object sender , EventArgs e)
        {
            if ( checkBoxSuperUser.Checked )
            {
                checkBoxCasherPermision.Checked = true;
                checkBoxPurshacePermision.Checked = true;
                checkBoxReportPermision.Checked = true;
            }
            else
            {
                checkBoxCasherPermision.Checked = false;
                checkBoxPurshacePermision.Checked = false;
                checkBoxReportPermision.Checked = false;
            }
        }

        private void buttonnewUserSave_Click(object sender , EventArgs e)
        {
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter ( "@UserFullName" , SqlDbType.NVarChar , 150 );
            param[1] = new SqlParameter ( "@UserName" , SqlDbType.NVarChar , 150 );
            param[2] = new SqlParameter ( "@UserPassword" , SqlDbType.NVarChar , 150 );
            param[3] = new SqlParameter ( "@SuperUserPermission" , SqlDbType.Bit );
            param[4] = new SqlParameter ( "@CasherPermsion" , SqlDbType.Bit );
            param[5] = new SqlParameter ( "@ReportPermision" , SqlDbType.Bit );
            param[6] = new SqlParameter ( "@PurshacePermision" , SqlDbType.Bit );
            param[7] = new SqlParameter ( "@AddbyUser" , SqlDbType.NVarChar , 150 );
            if ( textBoxnewUserFullName.Text == "" || textBoxnewUserUserName.Text == "" || textBoxnewUserPassword.Text == "" )
            {
                MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
            }
            else
            {
                if ( !checkBoxSuperUser.Checked && !checkBoxCasherPermision.Checked && !checkBoxPurshacePermision.Checked && !checkBoxReportPermision.Checked )
                {
                    MessageBox.Show ( "يجب ادخال صلاحية واحدة على الاقل او الغاء العملية" , "Message" );
                }
                else
                {
                    try
                    {

                        param[0].Value = textBoxnewUserFullName.Text.Trim ();
                        param[1].Value = textBoxnewUserUserName.Text.Trim ();
                        param[2].Value = textBoxnewUserPassword.Text.Trim ();
                        param[3].Value = checkBoxSuperUser.Checked;
                        param[4].Value = checkBoxCasherPermision.Checked;
                        param[5].Value = checkBoxReportPermision.Checked;
                        param[6].Value = checkBoxPurshacePermision.Checked;
                        param[7].Value = BasicClass.UserName;
                        UsedClass.ExecuteCommand ( "Casher_InsertNewUser" , param );
                        MessageBox.Show ( "DONE" , "MESSAGE" );
                        ClearRecords ();
                    }
                    catch ( Exception )
                    {

                        MessageBox.Show ( "المعلومات المدخلة موجودة مسبقا" , "MESSAGE" );
                    }
                }
            }
        }

        private void buttonnewUserCancel_Click(object sender , EventArgs e)
        {
            ClearRecords ();
        }

        private void tabControlControling_SelectedIndexChanged(object sender , EventArgs e)
        {
            var UsedClass = new BasicClass ();
            var dt = new DataTable ();
            if ( tabControlControling.SelectedTab == tabPageUsers )
            {
                dt = UsedClass.selectdata ( "Casher_SelectUsers" , null );
                dataGridViewUsers.DataSource = dt;
                //changesInUsers = dt;

            }
            else
            {
                //dataGridVieweditItem.Rows.Clear ();
            }
        }

        private void dataGridViewUsers_CellClick(object sender , DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex >= 0 )
            {

                switch ( e.ColumnIndex )
                {
                    case 6: //super user
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnCasherPermsion"].Value = true;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnReportPermsion"].Value = true;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnStorePermsion"].Value = true;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnSuper"].Value = true;
                        changesInUserFlag = true;
                        break;
                    case 3:  //ColumnReportPermsion
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnCasherPermsion"].Value = false;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnReportPermsion"].Value = true;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnStorePermsion"].Value = false;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnSuper"].Value = false;
                        changesInUserFlag = true;
                        break;
                    case 4:  //ColumnCasherPermsion
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnCasherPermsion"].Value = true;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnReportPermsion"].Value = false;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnStorePermsion"].Value = false;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnSuper"].Value = false;
                        changesInUserFlag = true;
                        break;
                    case 5:  //ColumnStorePermsion
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnCasherPermsion"].Value = false;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnReportPermsion"].Value = false;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnStorePermsion"].Value = true;
                        dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnSuper"].Value = false;
                        changesInUserFlag = true;
                        break;
                    default:
                        break;
                }
            }
        }


        private void dataGridViewUsers_CellValueChanged_1(object sender , DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex >= 0 )
            {
                switch ( dataGridViewUsers.Columns[e.ColumnIndex].Name )
                {
                    case "ColumnUserFullName":
                        if ( dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnUserFullName"].Value.ToString () == "" )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
                        }
                        else
                        {
                            changesInUserFlag = true;
                        }


                        break;
                    case "ColumnUserName":
                        if ( dataGridViewUsers.Rows[e.RowIndex].Cells["ColumnUserName"].Value.ToString () == "" )
                        {
                            MessageBox.Show ( "خطأ في ادخال المعلومات" , "Message" );
                        }
                        else
                        {
                            changesInUserFlag = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void buttonModifyUsers_Click(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter ( "@ID" , SqlDbType.Int );
            param[1] = new SqlParameter ( "@FullName" , SqlDbType.NVarChar , 150 );
            param[2] = new SqlParameter ( "@UserName" , SqlDbType.NVarChar , 150 );
            param[3] = new SqlParameter ( "@ReportPermision" , SqlDbType.Bit );
            param[4] = new SqlParameter ( "@StorePermision" , SqlDbType.Bit );
            param[5] = new SqlParameter ( "@CasherPermision" , SqlDbType.Bit );
            param[6] = new SqlParameter ( "@SuperUser" , SqlDbType.Bit );
            if ( dataGridViewUsers.CurrentRow.Index >= 0 && changesInUserFlag == true )
            {
                for ( int i = 0 ; i < dataGridViewUsers.Rows.Count ; i++ )
                {
                    param[0].Value = Int32.Parse ( dataGridViewUsers.Rows[i].Cells["ColumnUserID"].Value.ToString () );
                    param[1].Value = dataGridViewUsers.Rows[i].Cells["ColumnUserFullName"].Value.ToString ();
                    param[2].Value = dataGridViewUsers.Rows[i].Cells["ColumnUserName"].Value.ToString ();
                    param[3].Value = Convert.ToBoolean ( dataGridViewUsers.Rows[i].Cells["ColumnReportPermsion"].Value.ToString () );
                    param[4].Value = Convert.ToBoolean ( dataGridViewUsers.Rows[i].Cells["ColumnStorePermsion"].Value.ToString () );
                    param[5].Value = Convert.ToBoolean ( dataGridViewUsers.Rows[i].Cells["ColumnCasherPermsion"].Value.ToString () );
                    param[6].Value = Convert.ToBoolean ( dataGridViewUsers.Rows[i].Cells["ColumnSuper"].Value.ToString () );

                    UsedClass.ExecuteCommand ( "Casher_UpdateUsers" , param );
                }
                MessageBox.Show ( "DONE" , "MESSAGE" );
                Application.Exit ();
            }
            else
            {
                //nothing
            }


        }

        private void buttonPreventUser_Click(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter ( "@ID" , SqlDbType.Int );
            param[1] = new SqlParameter ( "@FullName" , SqlDbType.NVarChar , 150 );
            param[2] = new SqlParameter ( "@UserName" , SqlDbType.NVarChar , 150 );
            param[3] = new SqlParameter ( "@ReportPermision" , SqlDbType.Bit );
            param[4] = new SqlParameter ( "@StorePermision" , SqlDbType.Bit );
            param[5] = new SqlParameter ( "@CasherPermision" , SqlDbType.Bit );
            param[6] = new SqlParameter ( "@SuperUser" , SqlDbType.Bit );
            if ( dataGridViewUsers.CurrentRow.Index >= 0 )
            {

                param[0].Value = Int32.Parse ( dataGridViewUsers.Rows[dataGridViewUsers.CurrentRow.Index].Cells["ColumnUserID"].Value.ToString () );
                param[1].Value = dataGridViewUsers.Rows[dataGridViewUsers.CurrentRow.Index].Cells["ColumnUserFullName"].Value.ToString ();
                param[2].Value = dataGridViewUsers.Rows[dataGridViewUsers.CurrentRow.Index].Cells["ColumnUserName"].Value.ToString ();
                param[3].Value = 0;
                param[4].Value = 0;
                param[5].Value = 0;
                param[6].Value = 0;

                UsedClass.ExecuteCommand ( "Casher_UpdateUsers" , param );

                MessageBox.Show ( "تم حضر هذا المستخدم سوف يتم الخروج من البرنامج" , "MESSAGE" );

                Application.Exit ();
            }
        }

        private void textBoxEditDeleteUserSearch_TextChanged(object sender , EventArgs e)
        {
            var UsedClass = new BasicClass ();
            var dt = new DataTable ();
            if ( textBoxEditDeleteUserSearch.Text != "" )
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter ( "@Filter" , SqlDbType.NVarChar , 150 );
                param[0].Value = textBoxEditDeleteUserSearch.Text.Trim ();
                dt = UsedClass.selectdata ( "Casher_selectUsersUsingFilter" , param );
                dataGridViewUsers.DataSource = dt;

            }
            else
            {
                dt = UsedClass.selectdata ( "Casher_SelectUsers" , null );
                dataGridViewUsers.DataSource = dt;
            }
        }
    }
}
