using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Rresturant.View
{
    public partial class CacherForm : Form
    {
        int counter = 1;
        public CacherForm()
        {
            InitializeComponent ();
            displayallCategory (); //display All category

        }

        private void getMainInformation()
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            dt = UsedClass.selectdata ( "Casher_select_all_IDs" , null );

            if ( dt.Rows.Count > 0 )
            {
                textBoxInvoiceNo.Text = dt.Rows[0]["InvoiceNo"].ToString ();
                //textBoxPercentageTransfer.Text = dt.Rows[0]["PercentageTransfer"].ToString ();
                UsedClass.PercentageTransfer = double.Parse ( dt.Rows[0]["PercentageTransfer"].ToString () );

            }




        }

        private void displayallCategory()
        {
            //this function is get category and display in flowlayout panel
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            flowLayoutPanelCategories.Controls.Clear ();

            dt = UsedClass.selectdata ( "Casher_Get_All_Category" , null );
            for ( int i = 0 ; i < dt.Rows.Count ; i++ )
            {

                Button btn_Item = new Button ();
                btn_Item.Name = dt.Rows[i][0].ToString ();
                btn_Item.Text = dt.Rows[i][1].ToString ();
                btn_Item.AutoSize = true;
                btn_Item.Height = 60;
                btn_Item.FlatStyle = FlatStyle.Flat;
                btn_Item.FlatAppearance.BorderSize = 1;
                btn_Item.FlatAppearance.MouseOverBackColor = Color.FromArgb ( 245 , 124 , 0 );
                btn_Item.ForeColor = Color.FromArgb ( 255 , 255 , 255 );
                btn_Item.Click += new EventHandler ( set_itemsWithoutarcode );
                flowLayoutPanelCategories.Controls.Add ( btn_Item );

            }
        }

        private void set_itemsWithoutarcode(object sender , EventArgs e)
        {
            Button clickedbutton = sender as Button;
            flowLayoutPanelitemsWithoutBar.Controls.Clear ();
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 250 );

            param[0].Value = clickedbutton.Text;
            dt = UsedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );

            listBoxitemsWithoutBarcode.DataSource = dt;
            listBoxitemsWithoutBarcode.DisplayMember = "ItemName";
            for ( int i = 0 ; i < dt.Rows.Count ; i++ )
            {

                Button btn_Item = new Button ();
                btn_Item.Name = dt.Rows[i]["ItemName"].ToString ();
                btn_Item.Text = dt.Rows[i]["ItemName"].ToString ();
                btn_Item.AutoSize = true;
                btn_Item.Height = 55;
                btn_Item.FlatStyle = FlatStyle.Flat;
                btn_Item.FlatAppearance.BorderSize = 1;
                btn_Item.FlatAppearance.MouseOverBackColor = Color.FromArgb ( 245 , 124 , 0 );
                btn_Item.ForeColor = Color.FromArgb ( 255 , 255 , 255 );
                btn_Item.Click += new EventHandler ( SetItemsGrid );
                flowLayoutPanelitemsWithoutBar.Controls.Add ( btn_Item );
            }
        }

        private void SetItemsGrid(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            Button clicked = sender as Button;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 250 );
            param[0].Value = clicked.Text;
            dt = UsedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
            if ( dt.Rows.Count > 0 )
            {
                var ItemName = dt.Rows[0]["ItemName"].ToString ();
                var price = dt.Rows[0]["price_for_buy"].ToString ();
                var StockQuantity = int.Parse ( dt.Rows[0]["StockQuantity"].ToString () );
                var CriticalRange = int.Parse ( dt.Rows[0]["Critical_Quantity"].ToString () );
                var ExpireDate = dt.Rows[0]["ItemExpire"].ToString ();
                writeIntoGrid ( ItemName , price , StockQuantity , CriticalRange , ExpireDate );

            }
        }

        private void writeIntoGrid(string ItemName , string ItemPrice , int StockQuantity , int CriticalRange , string ExpireDate)
        {
            if ( CheckDuplicate ( ItemName ) )
            {

                int idx = dataGridViewItems.Rows.Add ();

                DataGridViewRow row = dataGridViewItems.Rows[idx];
                row.Cells["ColumnCounter"].Value = counter;     //تسلسل المواد
                row.Cells["ColumnItemName"].Value = ItemName;  //اسم المادة
                row.Cells["ColumnItemQuantity"].Value = 1;     //كمية المادة
                row.Cells["ColumnItemPrice"].Value = ItemPrice;     //   سعر البيع 
                row.Cells["ColumnTotal"].Value = float.Parse ( ItemPrice ) * 1;   //مجموع
                row.Cells["ColumnStockQuantity"].Value = StockQuantity;
                row.Cells["ColumnCriticalRange"].Value = CriticalRange;
                row.Cells["ColumnExpireDate"].Value = ExpireDate;
                counter++;
                moneyCalcuation ();
            }

        }

        private bool CheckDuplicate(string item)
        {
            for ( int i = 0 ; i < dataGridViewItems.Rows.Count ; i++ )
            {
                if ( dataGridViewItems.Rows[i].Cells["ColumnItemName"].Value != null )
                {
                    if ( dataGridViewItems.Rows[i].Cells["ColumnItemName"].Value.ToString () == item )
                    {
                        int quantity = Convert.ToInt32 ( dataGridViewItems.Rows[i].Cells["ColumnItemQuantity"].Value.ToString () );
                        decimal price = Convert.ToDecimal ( dataGridViewItems.Rows[i].Cells["ColumnItemPrice"].Value.ToString () );
                        quantity++;
                        dataGridViewItems.Rows[i].Cells["ColumnItemQuantity"].Value = quantity;
                        dataGridViewItems.Rows[i].Cells["ColumnTotal"].Value = quantity * price;
                        moneyCalcuation ();
                        return false;
                    }
                }
            }
            return true;
        }

        private void moneyCalcuation()
        {
            decimal totalInvoice = 0;
            decimal FinalTotal = 0;
            for ( int i = 0 ; i < dataGridViewItems.Rows.Count ; i++ )
            {
                totalInvoice += totalInvoice + Convert.ToDecimal ( dataGridViewItems.Rows[i].Cells["ColumnTotal"].Value.ToString () );
                FinalTotal = totalInvoice;
            }
            textBoxTotalInvoice.Text = totalInvoice.ToString ();
            textBoxFinalAmount.Text = FinalTotal.ToString ();
            //textBoxTotalInvoice.Text = string.Format ( System.Globalization.CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , totalInvoice );
            //textBoxFinalAmount.Text = string.Format ( System.Globalization.CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , FinalTotal );

        }

        public void EnableControlling()
        {
            tableLayoutPanelCategories.Enabled = true;
            textBoxCustomerName.Enabled = true;
            textBoxBarCodeItem.Enabled = true;
            listBoxitemsWithoutBarcode.Enabled = true;
            buttonInpostInvoices.Enabled = true;
        }

        private void IntializeFunction()
        {
            counter = 1;
            var dt = new DataTable ();
            dt.Rows.Clear ();
            listBoxitemsWithoutBarcode.DataSource = dt;
            dataGridViewItems.Rows.Clear ();
            buttonInpostInvoices.Enabled = false;
            textBoxBarCodeItem.Enabled = false;
            textBoxCustomerName.Enabled = false;
            listBoxitemsWithoutBarcode.Enabled = false;
            tableLayoutPanelCategories.Enabled = false;

            textBoxLocalSaveAmount.Text = "0";
            textBoxDollarSaveAmount.Text = "0";
            textBoxTotalSaveAmount.Text = "0";
            textBoxTotalInvoice.Text = "0";
            textBoxFinalAmount.Text = "0";

        }

        private void deletePrviousInvoices()
        {
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@InvoiceNo" , SqlDbType.Int );
            param[0].Value = int.Parse ( textBoxInvoiceNo.Text );
            UsedClass.ExecuteCommand ( "CasherForm_deletePreviousInvoice" , param );
        }

        private void SaveInvoices(string RUNORSAVE , string PayOrNot)
        {

            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[6];
            for ( int i = 0 ; i < dataGridViewItems.Rows.Count ; i++ )
            {
                //all data will be inserted into Table_orders
                param[0] = new SqlParameter ( "@invoiceNo" , SqlDbType.Int );
                param[0].Value = Int32.Parse ( textBoxInvoiceNo.Text );
                //
                param[1] = new SqlParameter ( "@itemName" , SqlDbType.NVarChar , 50 );
                param[1].Value = dataGridViewItems.Rows[i].Cells["ColumnItemName"].Value;
                //
                param[2] = new SqlParameter ( "@Quantity" , SqlDbType.Int );
                param[2].Value = int.Parse ( dataGridViewItems.Rows[i].Cells["ColumnItemQuantity"].Value.ToString () ) * -1;
                //
                param[3] = new SqlParameter ( "@price" , SqlDbType.Float );
                param[3].Value = float.Parse ( dataGridViewItems.Rows[i].Cells["ColumnItemPrice"].Value.ToString () );
                //
                param[4] = new SqlParameter ( "@totalPrice" , SqlDbType.Float );
                param[4].Value = float.Parse ( dataGridViewItems.Rows[i].Cells["ColumnTotal"].Value.ToString () );
                //
                param[5] = new SqlParameter ( "@CustomerName" , SqlDbType.NVarChar , 250 );
                param[5].Value = textBoxCustomerName.Text;
                //
                UsedClass.ExecuteCommand ( "insert_order" , param );
                //all data will be inserted into Table_orders
            }
            SqlParameter[] param2 = new SqlParameter[12];

            //below data will be inserted into two tables INVOICES_INFORMATION and INVOICES_MONEY
            //try
            //{
            param2[0] = new SqlParameter ( "@InvoiceNo" , SqlDbType.Int );
            param2[1] = new SqlParameter ( "@CustomerName" , SqlDbType.NVarChar , 150 );
            param2[2] = new SqlParameter ( "@InvoiceType" , SqlDbType.NVarChar , 100 );
            param2[3] = new SqlParameter ( "@InvoiceDate" , SqlDbType.Date );
            param2[4] = new SqlParameter ( "@InvoicePaymentStatus" , SqlDbType.NVarChar , 100 );
            param2[5] = new SqlParameter ( "@InvoiceRunORnot" , SqlDbType.NVarChar , 100 );
            param2[6] = new SqlParameter ( "@IQAmountPaid" , SqlDbType.Float );
            param2[7] = new SqlParameter ( "@USAmountPaid" , SqlDbType.Float );
            param2[8] = new SqlParameter ( "@ConversionRate" , SqlDbType.Float );
            param2[9] = new SqlParameter ( "@InvoiceDiscount" , SqlDbType.Float );
            param2[10] = new SqlParameter ( "@Reminder" , SqlDbType.Float );
            param2[11] = new SqlParameter ( "@EnteredUser" , SqlDbType.NVarChar , 150 );
            param2[0].Value = int.Parse ( textBoxInvoiceNo.Text );
            param2[1].Value = textBoxCustomerName.Text;
            param2[2].Value = "بيع";
            param2[3].Value = dateTimePickerInvoiceDate.Text;
            param2[4].Value = PayOrNot;
            param2[5].Value = RUNORSAVE;
            param2[6].Value = IQPaidAmount ();

            param2[7].Value = textBoxDollarSaveAmount.Text;
            param2[8].Value = UsedClass.PercentageTransfer;
            var finalDiscountAmount = 0.0;
            if ( textBoxDiscountPercentage.Text != "" && textBoxDiscountPercentage.Text != "0" )
            {
                var TotalAmount = Convert.ToDouble ( textBoxTotalInvoice.Text.Trim () );
                var PercentageDisount = 0.0;
                PercentageDisount = double.Parse ( textBoxDiscountPercentage.Text );
                PercentageDisount = PercentageDisount * 1 / 100;
                PercentageDisount = PercentageDisount * TotalAmount;
                finalDiscountAmount = PercentageDisount;
            }
            else if ( textBoxDiscountAmount.Text != "" && textBoxDiscountAmount.Text != "0" )
            {
                var TotalAmount = Convert.ToDouble ( textBoxTotalInvoice.Text.Trim () );
                var DiscountAmount = double.Parse ( textBoxDiscountAmount.Text );
                finalDiscountAmount = DiscountAmount;
            }
            param2[9].Value = finalDiscountAmount;
            var Reminder = 0.0;
            if ( textBoxReminderMoney.Text != "" || textBoxReminderMoney.Text != "0" )
            {
                if ( textBoxReminderMoney.Text.Contains ( "-" ) )
                {
                    Reminder = Convert.ToDouble ( textBoxReminderMoney.Text.Trim () );
                    Reminder *= -1;
                }
                else
                {
                    Reminder = Convert.ToDouble ( textBoxReminderMoney.Text.Trim () );
                }

            }
            param2[10].Value = Reminder;
            param2[11].Value = BasicClass.UserName;
            UsedClass.ExecuteCommand ( "Casher_InsertNewInvoice" , param2 );
            //}
            //catch ( Exception e )
            //{

            //    MessageBox.Show ( e.Message );
            //}


        }

        private void buttonCreateInvoice_Click(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                DialogResult Result = MessageBox.Show ( "هل تريد فتح قائمة جديدة والغاء السابقة" , "MESSAGE" , MessageBoxButtons.YesNo );
                if ( Result == DialogResult.Yes )
                {
                    dataGridViewItems.Rows.Clear ();
                }
            }
            else
            {
                EnableControlling ();
                getMainInformation ();
            }
        }

        private void buttonInpostInvoices_Click(object sender , EventArgs e)
        {
            var form = new SavedInvoicesForm ();
            form.LoadSaveInvoices ( "بيع" );
            form.ShowDialog ();
        }

        private void buttonInvoicePause_Click(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                if ( textBoxCustomerName.Text == "" || textBoxCustomerName.Text == "زبون خارجي" )
                {
                    textBoxCustomerName.Text = "";
                    MessageBox.Show ( "يرجى ادخال أسم الزبون" , "Message" );
                    textBoxCustomerName.Focus ();
                }
                else
                {
                    if ( BasicClass.flagModified == true )
                    {
                        //return items to stock and then update invoice
                    }
                    else
                    {
                        //delete previous invoice that have same number
                        deletePrviousInvoices ();
                        //save invoice to data base with keyword RUN
                        SaveInvoices ( "SAVE" , "اجل" );
                        MessageBox.Show ( "DONE" , "Message" );

                        IntializeFunction ();
                    }
                }
            }
        }

        private void buttonInvoiceCancel_Click(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                DialogResult result = MessageBox.Show ( "هل تريد الغاء القائمة الحالية" , "Warring" , MessageBoxButtons.OKCancel , MessageBoxIcon.Question );
                if ( result == DialogResult.OK )
                {

                    dataGridViewItems.Rows.Clear ();
                    moneyCalcuation ();
                    IntializeFunction ();
                }
            }
        }

        private void buttonInvoiceSave_Click(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                if ( textBoxCustomerName.Text == "" )
                {

                    MessageBox.Show ( "يرجى ادخال أسم الزبون" , "Message" );
                    textBoxCustomerName.Focus ();
                }
                else
                {
                    if ( textBoxTotalSaveAmount.Text == "" || textBoxTotalSaveAmount.Text == "0" )
                    {
                        DialogResult result = MessageBox.Show ( "هل القائمة بالاجل" , "Warring" , MessageBoxButtons.YesNo , MessageBoxIcon.Question );
                        if ( result == DialogResult.Yes )
                        {
                            //delete previous invoice that have same number
                            deletePrviousInvoices ();
                            //save invoice to data base with keyword RUN
                            SaveInvoices ( "RUN" , "أجل" );
                            MessageBox.Show ( "DONE" , "Message" );
                            buttonInvoicePrint_Click ( sender , e );
                            IntializeFunction ();
                        }
                        else
                        {
                            MessageBox.Show ( "يرجى ادخال المبلغ المسدد" , "Message" );
                            textBoxLocalSaveAmount.Focus ();

                        }

                    }
                    else
                    {
                        /* if ( BasicClass.flagModified == true )
                         {
                             //return items to stock and then update invoice
                         }
                         else
                         {
                             //delete previous invoice that have same number
                             deletePrviousInvoices ();
                             //save invoice to data base with keyword RUN
                             SaveInvoices ( "RUN" , "نقد" );
                             MessageBox.Show ( "DONE" , "Message" );
                             //buttonInvoicePrint_Click ( sender ,e);
                             IntializeFunction ();
                         }*/


                        //delete previous invoice that have same number
                        deletePrviousInvoices ();
                        //save invoice to data base with keyword RUN
                        SaveInvoices ( "RUN" , "نقد" );
                        MessageBox.Show ( "DONE" , "Message" );
                        buttonInvoicePrint_Click ( sender , e );
                        IntializeFunction ();
                    }
                }
            }
        }

        private void buttonInvoicePrint_Click(object sender , EventArgs e)
        {
            var UsedClass = new BasicClass ();
            var dt = new DataTable ();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter ( "@InvoiceNo" , SqlDbType.Int );
            param[1] = new SqlParameter ( "@CustomerName" , SqlDbType.NVarChar , 250 );
            param[0].Value = int.Parse ( textBoxInvoiceNo.Text );
            param[1].Value = textBoxCustomerName.Text.Trim ();

            dt = UsedClass.selectdata ( "Casher_PrintForma" , param );
            var crp = new Reports.CrystalReport1 ();
            CrystalDecisions.CrystalReports.Engine.TextObject invoiceType = (CrystalDecisions.CrystalReports.Engine.TextObject) crp.ReportDefinition.Sections["Section2"].ReportObjects["Text15"];
            invoiceType.Text = textBoxInvoiceNo.Text;
            crp.SetDataSource ( dt );
            PrintForm form = new PrintForm ();
            form.crystalReportViewer1.ReportSource = crp;
            form.ShowDialog ();
            //crp.PrintToPrinter ( 1 , false , 0 , 0 );

        }

        private void dataGridViewItems_CellContentClick(object sender , DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex >= 0 )
            {
                switch ( e.ColumnIndex )
                {
                    case 5:
                        dataGridViewItems.Rows.RemoveAt ( e.RowIndex );
                        counter--;
                        for ( int i = 0 ; i < dataGridViewItems.Rows.Count ; i++ )
                        {
                            dataGridViewItems.Rows[i].Cells["ColumnCounter"].Value = i + 1;
                        }
                        moneyCalcuation ();
                        break;
                    default:
                        break;
                }
            }
        }

        private void dataGridViewItems_CellValueChanged(object sender , DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex >= 0 )
            {
                switch ( dataGridViewItems.Columns[e.ColumnIndex].Name )
                {
                    case "ColumnItemQuantity":
                        if ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemPrice"].Value != null )
                        {

                            var Price = decimal.Parse ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemPrice"].Value.ToString () );
                            var Quantity = decimal.Parse ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemQuantity"].Value.ToString () );
                            if ( Quantity <= 0 )
                            {
                                MessageBox.Show ( "خطا في ادخال القيمة" , "Message" );
                                dataGridViewItems.Rows[e.RowIndex].Selected = true;
                            }
                            if ( Price <= 0 )
                            {
                                MessageBox.Show ( "يجب اعطاء سعر بيع للمادة" , "Message" );
                                dataGridViewItems.Rows[e.RowIndex].Selected = true;
                            }
                            else
                            {
                                dataGridViewItems.Rows[e.RowIndex].Cells["ColumnTotal"].Value = Price * Quantity;
                                moneyCalcuation ();
                            }
                        }

                        break;
                    case "ColumnItemPrice":
                        if ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemPrice"].Value != null && float.Parse ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemPrice"].Value.ToString () ) <= 0 )
                        {
                            MessageBox.Show ( "يجب اعطاء سعر بيع للمادة" , "Message" );
                            dataGridViewItems.Rows[e.RowIndex].Selected = true;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private void textBoxBarCodeItem_KeyDown(object sender , KeyEventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            if ( e.KeyValue == (char) Keys.Enter )
            {
                if ( textBoxBarCodeItem.Text != "" )
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 250 );
                    param[0].Value = textBoxBarCodeItem.Text.Trim ();

                    dt = UsedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
                    textBoxBarCodeItem.Text = "";
                    for ( int i = 0 ; i < dt.Rows.Count ; i++ )
                    {
                        var ItemName = dt.Rows[i]["ItemName"].ToString ();
                        var price = dt.Rows[i]["price_for_buy"].ToString ();
                        var StockQuantity = int.Parse ( dt.Rows[i]["StockQuantity"].ToString () );
                        var CriticalRange = int.Parse ( dt.Rows[i]["Critical_Quantity"].ToString () );
                        var ExpireDate = dt.Rows[i]["ItemExpire"].ToString ();
                        writeIntoGrid ( ItemName , price , StockQuantity , CriticalRange , ExpireDate );
                    }
                }
            }
        }

        private void listBoxitemsWithoutBarcode_MouseDoubleClick(object sender , MouseEventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            if ( listBoxitemsWithoutBarcode.Enabled == true )
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 250 );
                param[0].Value = listBoxitemsWithoutBarcode.Text;

                dt = UsedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
                if ( dt.Rows.Count > 0 )
                {
                    var ItemName = dt.Rows[0]["ItemName"].ToString ();
                    var price = dt.Rows[0]["price_for_buy"].ToString ();
                    var StockQuantity = int.Parse ( dt.Rows[0]["StockQuantity"].ToString () );
                    var CriticalRange = int.Parse ( dt.Rows[0]["Critical_Quantity"].ToString () );
                    var ExpireDate = dt.Rows[0]["ItemExpire"].ToString ();
                    writeIntoGrid ( ItemName , price , StockQuantity , CriticalRange , ExpireDate );
                }

            }
        }

        private void textBoxDiscountPercentage_TextChanged(object sender , EventArgs e)
        {
            if ( textBoxDiscountPercentage.Text != "" )
            {

                textBoxDiscountAmount.Enabled = false;
                radioButtonDiscountAmount.Enabled = false;
                radioButtonPercentageDiscount.Checked = true;
                if ( textBoxLocalSaveAmount.Text != "" || textBoxLocalSaveAmount.Text != "0" )
                {
                    textBoxLocalSaveAmount.Text = "0";
                    textBoxTotalSaveAmount.Text = "0";
                    textBoxReminderMoney.Text = "0";
                }
                if ( textBoxDollarSaveAmount.Text != "" || textBoxDollarSaveAmount.Text != "0" )
                {
                    textBoxTotalSaveAmount.Text = "0";
                    textBoxReminderMoney.Text = "0";
                    textBoxDollarSaveAmount.Text = "0";
                }
                decimal TotalAmount = 0;
                decimal PercentageDisount = 0;
                decimal FinalAmount = 0;
                //var currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                TotalAmount = Convert.ToDecimal ( textBoxTotalInvoice.Text );
                PercentageDisount = Convert.ToDecimal ( textBoxDiscountPercentage.Text );
                PercentageDisount = PercentageDisount * 1 / 100;
                PercentageDisount = PercentageDisount * TotalAmount;
                FinalAmount = TotalAmount - PercentageDisount;
                textBoxFinalAmount.Text = FinalAmount.ToString ();
                //textBoxFinalAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , FinalAmount );

            }
            else
            {

                textBoxDiscountAmount.Enabled = true;
                radioButtonDiscountAmount.Enabled = true;
                radioButtonPercentageDiscount.Checked = false;
                moneyCalcuation ();

            }
        }

        private void textBoxDiscountAmount_TextChanged(object sender , EventArgs e)
        {
            if ( textBoxDiscountAmount.Text != "" )
            {
                if ( textBoxLocalSaveAmount.Text != "" || textBoxLocalSaveAmount.Text != "0" )
                {
                    textBoxLocalSaveAmount.Text = "0";
                    textBoxTotalSaveAmount.Text = "0";
                    textBoxReminderMoney.Text = "0";
                }
                if ( textBoxDollarSaveAmount.Text != "" || textBoxDollarSaveAmount.Text != "0" )
                {
                    textBoxTotalSaveAmount.Text = "0";
                    textBoxReminderMoney.Text = "0";
                    textBoxDollarSaveAmount.Text = "0";
                }
                textBoxDiscountPercentage.Enabled = false;
                radioButtonPercentageDiscount.Enabled = false;
                radioButtonDiscountAmount.Checked = true;
                decimal TotalAmount = 0;
                decimal DiscountAmount = 0;
                decimal FinalAmount = 0;
                //var currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                TotalAmount = Convert.ToDecimal ( textBoxTotalInvoice.Text );
                DiscountAmount = decimal.Parse ( textBoxDiscountAmount.Text );
                FinalAmount = TotalAmount - DiscountAmount;
                textBoxFinalAmount.Text = FinalAmount.ToString ();
                //textBoxFinalAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , FinalAmount );
            }
            else
            {
                textBoxDiscountPercentage.Enabled = true;
                radioButtonPercentageDiscount.Enabled = true;
                radioButtonDiscountAmount.Checked = false;
                moneyCalcuation ();


            }
        }

        private void textBoxLocalSaveAmount_MouseDoubleClick(object sender , MouseEventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                textBoxLocalSaveAmount.Text = textBoxFinalAmount.Text;
                decimal TotalPaidAmount = IQPaidAmount () + USPaidAmount ();
                textBoxTotalSaveAmount.Text = TotalPaidAmount.ToString ();
                reminderFunction ();
                //textBoxTotalSaveAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , TotalPaidAmount );
            }


        }

        private void textBoxDollarSaveAmount_TextChanged(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                if ( textBoxDollarSaveAmount.Text != "" )
                {

                    decimal IQAmount = IQPaidAmount ();
                    decimal USAmount = USPaidAmount ();
                    decimal TotalPaidAmount = IQAmount + USAmount;
                    textBoxTotalSaveAmount.Text = TotalPaidAmount.ToString ();
                    reminderFunction ();
                    //textBoxTotalSaveAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , TotalPaidAmount );
                }
                else
                {
                    textBoxDollarSaveAmount.Text = "0";
                    textBoxDollarSaveAmount.SelectAll ();
                }
            }
        }

        private void textBoxLocalSaveAmount_TextChanged(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                if ( textBoxLocalSaveAmount.Text != "" )
                {
                    decimal IQAmount = IQPaidAmount ();
                    decimal USAmount = USPaidAmount ();
                    decimal TotalPaidAmount = IQAmount + USAmount;
                    textBoxTotalSaveAmount.Text = TotalPaidAmount.ToString ();
                    reminderFunction ();
                    //textBoxTotalSaveAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , TotalPaidAmount );
                }
                else
                {
                    textBoxLocalSaveAmount.Text = "0";
                    textBoxLocalSaveAmount.SelectAll ();
                }

            }
        }

        private void reminderFunction()
        {
            //var currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
            //var InvoiceNetAmount = Convert.ToDouble ( textBoxFinalAmount.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ) );
            //var TotalPaidAmount = Convert.ToDouble ( textBoxTotalSaveAmount.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ) );
            //var ReminderPaid = 0.0;
            decimal InvoiceNetAmount, TotalPaidAmount, ReminderPaid;
            InvoiceNetAmount = TotalPaidAmount = ReminderPaid = 0;
            InvoiceNetAmount = Convert.ToDecimal ( textBoxFinalAmount.Text );
            TotalPaidAmount = Convert.ToDecimal ( textBoxTotalSaveAmount.Text );
            if ( InvoiceNetAmount > TotalPaidAmount )
            {
                ReminderPaid = InvoiceNetAmount - TotalPaidAmount;
                textBoxReminderMoney.BackColor = Color.FromArgb ( 46 , 204 , 113 );
            }
            else if ( InvoiceNetAmount < TotalPaidAmount )
            {
                ReminderPaid = InvoiceNetAmount - TotalPaidAmount;
                textBoxReminderMoney.BackColor = Color.FromArgb ( 192 , 57 , 43 );
                textBoxReminderMoney.ForeColor = Color.FromArgb ( 52 , 73 , 94 );
            }
            else if ( InvoiceNetAmount == TotalPaidAmount )
            {
                textBoxReminderMoney.BackColor = Color.FromArgb ( 149 , 165 , 166 );
                textBoxReminderMoney.ForeColor = Color.FromArgb ( 52 , 73 , 94 );
            }
            textBoxReminderMoney.Text = ReminderPaid.ToString ();
            //textBoxReminderMoney.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , ReminderPaid );


        }

        private decimal IQPaidAmount()
        {
            if ( textBoxLocalSaveAmount.Text != "" )
            {
                decimal IQPaidAmount = 0;
                //var currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                IQPaidAmount = Convert.ToDecimal ( textBoxLocalSaveAmount.Text );
                return IQPaidAmount;
            }
            else
                return 0;
        }

        private decimal USPaidAmount()
        {
            if ( textBoxDollarSaveAmount.Text != "" )
            {
                decimal USPaidAmount = 0;
                decimal PercentageTransfer = 0;
                var UsedClass = new BasicClass ();
                USPaidAmount = Convert.ToDecimal ( textBoxDollarSaveAmount.Text );

                PercentageTransfer = Convert.ToDecimal ( UsedClass.PercentageTransfer.ToString () );
                USPaidAmount = USPaidAmount * PercentageTransfer;

                return USPaidAmount;
            }
            else
                return 0;
        }

        private void CacherForm_Activated(object sender , EventArgs e)
        {
            if ( BasicClass.UnrnningBillId > 0 )
            {
                dataGridViewItems.Rows.Clear ();
                counter = 1;
                var UsedClass = new BasicClass ();
                var dt = new DataTable ();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter ( "@InvoiceFilter" , SqlDbType.NVarChar , 150 );
                param[0].Value = BasicClass.UnrnningBillId.ToString ();
                dt = UsedClass.selectdata ( "Casher_Select_Invoices_with_all_Information" , param );
                if ( dt.Rows.Count > 0 )
                {
                    textBoxCustomerName.Text = dt.Rows[0]["CustomerName"].ToString ();
                    textBoxInvoiceNo.Text = dt.Rows[0]["invoiceNumber"].ToString ();
                    dateTimePickerInvoiceDate.Text = dt.Rows[0]["InvoiceDate"].ToString ();
                    for ( int i = 0 ; i < dt.Rows.Count ; i++ )
                    {

                        var ItemName = dt.Rows[i]["itemName"].ToString ();
                        var Quantity = int.Parse ( dt.Rows[i]["itemQuantity"].ToString () );
                        Quantity = Quantity * -1;
                        var ItemPrice = dt.Rows[i]["itemPrice"].ToString ();
                        var TotalPrice = dt.Rows[i]["totalPrice"].ToString ();
                        var ItemExpire = dt.Rows[i]["ItemExpire"];
                        var StockQuantity = dt.Rows[i]["StockQuantity"].ToString ();
                        var CriticalRange = dt.Rows[i]["Critical_Quantity"].ToString ();
                        dataGridViewItems.Rows.Add ( counter , ItemName , Quantity , ItemPrice , TotalPrice , 0 , ItemExpire , StockQuantity , CriticalRange );
                        counter++;
                    }
                    BasicClass.UnrnningBillId = 0;
                    moneyCalcuation ();
                }
            }
        }

        private void dataGridViewItems_SelectionChanged(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                if ( dataGridViewItems.CurrentRow.Index >= 0 )
                {
                    if ( dataGridViewItems.Rows[dataGridViewItems.CurrentRow.Index].Cells["ColumnItemName"].Value != null )
                    {
                        var ItemExpire = dataGridViewItems.Rows[dataGridViewItems.CurrentRow.Index].Cells["ColumnExpireDate"].Value.ToString ();
                        var StockQuantity = dataGridViewItems.Rows[dataGridViewItems.CurrentRow.Index].Cells["ColumnStockQuantity"].Value.ToString ();
                        var CriticalRange = dataGridViewItems.Rows[dataGridViewItems.CurrentRow.Index].Cells["ColumnCriticalRange"].Value.ToString ();
                        //textBoxStockQuantity.Text = StockQuantity;
                        //textBoxExpireDate.Text = ItemExpire;
                        //textBoxCritiCalRange.Text = CriticalRange;
                    }

                }
            }
        }

        private void buttonDailyReport_Click(object sender , EventArgs e)
        {
            //var dt = new DataTable ();
            //var UsedClass = new BasicClass ();
            //SqlParameter[] param = new SqlParameter[1];
            //param[0] = new SqlParameter ( "@InvoiceFilter" , SqlDbType.NVarChar , 150 );
            //param[0].Value = BasicClass.UserName;

            //dt = UsedClass.selectdata ( "Casher_Select_Invoices_with_all_Information" , param );
            //var crp = new Reports.DailyCasherReport ();
            ////CrystalDecisions.CrystalReports.Engine.TextObject invoiceType = (CrystalDecisions.CrystalReports.Engine.TextObject) crp.ReportDefinition.Sections["Section2"].ReportObjects["Text15"];
            ////invoiceType.Text = textBoxInvoiceNo.Text;
            //crp.SetDataSource ( dt );
            //PrintForm form = new PrintForm ();
            //form.crystalReportViewer1.ReportSource = crp;
            //form.ShowDialog ();
        }

        private void labelExitForm_Click(object sender , EventArgs e)
        {
            this.Close ();

        }

        private void dataGridViewItems_EditingControlShowing(object sender , DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler ( Control_KeyPress );

        }

        private void Control_KeyPress(object sender , KeyPressEventArgs e)
        {
            if ( !char.IsControl ( e.KeyChar ) && !char.IsDigit ( e.KeyChar ) )
            {
                e.Handled = true;
            }
        }
    }
}
