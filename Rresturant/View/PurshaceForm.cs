using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Rresturant.View
{
    public partial class PurshaceForm : Form
    {
        int counter = 1;
        public PurshaceForm()
        {
            InitializeComponent ();
            InitializeFunction ();
        }

        private void InitializeFunction()
        {
            var dt = new DataTable ();
            dt.Rows.Clear ();
            comboBoxCategories.DataSource = dt;
            listBoxSelectionItems.Items.Clear ();
            comboBoxCategories.Enabled = false;
            listBoxSelectionItems.Enabled = false;
            buttonPausesInvoices.Enabled = false;
            buttonSave.Enabled = false;
            buttonSave_and_Run.Enabled = false;
            //buttonPrintInvoice.Enabled = false;
            textBoxBarCode.Enabled = false;
            dataGridViewItems.Rows.Clear ();
            dataGridViewItems.Enabled = false;
            //textBoxInvoiceNO.Text = "0";

        }

        private void labelExit_Click(object sender , EventArgs e)
        {
            this.Close ();
        }

        private void textBoxBarCode_Enter(object sender , EventArgs e)
        {
            textBoxBarCode.Text = "";
        }

        private void textBoxBarCode_Leave(object sender , EventArgs e)
        {
            textBoxBarCode.Text = "ادخل الباركود";
        }

        private void textBoxCustomerName_Leave(object sender , EventArgs e)
        {

        }

        private void textBoxCustomerName_Enter(object sender , EventArgs e)
        {
            textBoxCustomerName.Text = "";

        }

        private void buttonNewInvoice_Click(object sender , EventArgs e)
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

        public void EnableControlling()
        {
            comboBoxCategories.Enabled = true;
            listBoxSelectionItems.Enabled = true;
            textBoxBarCode.Enabled = true;
            dataGridViewItems.Enabled = true;
            buttonPausesInvoices.Enabled = true;
            buttonSave.Enabled = true;
            buttonSave_and_Run.Enabled = true;
        }

        private void buttonSave_and_Run_Click(object sender , EventArgs e)
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
                    if ( textBoxTotalSaveAmount.Text == "0" )
                    {
                        DialogResult result = MessageBox.Show ( "هل القائمة بالاجل ؟؟" , "Warring" , MessageBoxButtons.YesNoCancel , MessageBoxIcon.Question );
                        if ( result == DialogResult.Yes )
                        {
                            deletePrviousInvoices ();
                            //save invoice to data base with keyword RUN
                            SaveInvoices ( "RUN" , "اجل" );
                            MessageBox.Show ( "DONE" , "Message" );
                            //buttonInvoicePrint_Click ( sender ,e);
                            InitializeFunction ();


                        }
                        else if ( result == DialogResult.No )
                        {
                            MessageBox.Show ( "يرجى ادخال المبالغ المسددة" , "Message" );
                            textBoxLocalSaveAmount.Focus ();
                        }

                    }
                    else
                    {
                        deletePrviousInvoices ();
                        //save invoice to data base with keyword RUN
                        SaveInvoices ( "RUN" , "نقد" );
                        MessageBox.Show ( "DONE" , "Message" );
                        //buttonInvoicePrint_Click ( sender ,e);
                        InitializeFunction ();
                    }


                }
                buttonPrintInvoice.Enabled = true;
            }
        }

        private void SaveInvoices(string RUNORSAVE , string PayOrNot)
        {
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[6];
            for ( int i = 0 ; i < dataGridViewItems.Rows.Count ; i++ )
            {
                //all data will be inserted into Table_orders
                param[0] = new SqlParameter ( "@invoiceNo" , SqlDbType.Int );
                param[0].Value = Int32.Parse ( textBoxInvoiceNO.Text );
                //
                param[1] = new SqlParameter ( "@itemName" , SqlDbType.NVarChar , 50 );
                param[1].Value = dataGridViewItems.Rows[i].Cells["ColumnItemName"].Value;
                //
                param[2] = new SqlParameter ( "@Quantity" , SqlDbType.Int );
                param[2].Value = int.Parse ( dataGridViewItems.Rows[i].Cells["ColumnItemQuantity"].Value.ToString () );
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
            param2[3] = new SqlParameter ( "@InvoiceDate" , SqlDbType.NVarChar , 100 );
            param2[4] = new SqlParameter ( "@InvoicePaymentStatus" , SqlDbType.NVarChar , 100 );
            param2[5] = new SqlParameter ( "@InvoiceRunORnot" , SqlDbType.NVarChar , 100 );
            param2[6] = new SqlParameter ( "@IQAmountPaid" , SqlDbType.Float );
            param2[7] = new SqlParameter ( "@USAmountPaid" , SqlDbType.Float );
            param2[8] = new SqlParameter ( "@ConversionRate" , SqlDbType.Float );
            param2[9] = new SqlParameter ( "@InvoiceDiscount" , SqlDbType.Float );
            param2[10] = new SqlParameter ( "@Reminder" , SqlDbType.Float );
            param2[11] = new SqlParameter ( "@EnteredUser" , SqlDbType.NVarChar , 150 );
            param2[0].Value = int.Parse ( textBoxInvoiceNO.Text );
            param2[1].Value = textBoxCustomerName.Text;
            param2[2].Value = "شراء";
            param2[3].Value = dateTimePickerInvoiceDate.Text.ToString ();
            param2[4].Value = PayOrNot;
            param2[5].Value = RUNORSAVE;
            var currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
            param2[6].Value = IQPaidAmount ();

            param2[7].Value = textBoxDollarSaveAmount.Text;
            param2[8].Value = textBoxPercentageTransfer.Text;
            var FinalAmount = 0.0;
            if ( textBoxDiscountPercentage.Text != "" && textBoxDiscountPercentage.Text != "0" )
            {
                currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                var TotalAmount = Convert.ToDouble ( textBoxTotalInvoice.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ) );
                var PercentageDisount = 0.0;
                PercentageDisount = int.Parse ( textBoxDiscountPercentage.Text );
                PercentageDisount = PercentageDisount * 1 / 100;
                PercentageDisount = PercentageDisount * TotalAmount;
                FinalAmount = PercentageDisount;
            }
            else if ( textBoxDiscountAmount.Text != "" && textBoxDiscountAmount.Text != "0" )
            {
                currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                var TotalAmount = Convert.ToDouble ( textBoxTotalInvoice.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ) );
                var DiscountAmount = int.Parse ( textBoxDiscountAmount.Text );
                FinalAmount = DiscountAmount;
            }
            param2[9].Value = FinalAmount;
            var Reminder = 0.0;
            if ( textBoxReminder.Text != "" || textBoxReminder.Text != "0" )
            {
                if ( textBoxReminder.Text.Contains ( "-" ) )
                {
                    currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                    Reminder = Convert.ToDouble ( textBoxReminder.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ).Replace ( "-" , "" ) );
                    Reminder *= -1;
                }
                else
                {
                    currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                    Reminder = Convert.ToDouble ( textBoxReminder.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ).Replace ( "-" , "" ) );
                }

            }
            param2[10].Value = Reminder;
            param2[11].Value = textBoxUserName.Text;
            UsedClass.ExecuteCommand ( "Casher_InsertNewInvoice" , param2 );
            //}
            //catch ( Exception e )
            //{

            //    MessageBox.Show ( e.Message );
            //}
        }

        private void deletePrviousInvoices()
        {
            var UsedClass = new BasicClass ();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@InvoiceNo" , SqlDbType.Int );
            param[0].Value = int.Parse ( textBoxInvoiceNO.Text );
            UsedClass.ExecuteCommand ( "CasherForm_deletePreviousInvoice" , param );
        }

        private void buttonSave_Click(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                if ( textBoxCustomerName.Text == "" || textBoxCustomerName.Text == "زبون خارجي" )
                {
                    MessageBox.Show ( "يرجى ادخال أسم الزبون" , "Message" );
                    textBoxCustomerName.Focus ();
                }
                else
                {
                    if ( textBoxTotalSaveAmount.Text == "0" )
                    {
                        DialogResult result = MessageBox.Show ( "هل القائمة بالاجل ؟؟" , "Warring" , MessageBoxButtons.YesNoCancel , MessageBoxIcon.Question );
                        if ( result == DialogResult.Yes )
                        {
                            deletePrviousInvoices ();
                            //save invoice to data base with keyword RUN
                            SaveInvoices ( "SAVE" , "اجل" );
                            MessageBox.Show ( "DONE" , "Message" );
                            //buttonInvoicePrint_Click ( sender ,e);
                            InitializeFunction ();

                        }
                        else if ( result == DialogResult.No )
                        {
                            MessageBox.Show ( "يرجى ادخال المبالغ المسددة" , "Message" );
                            textBoxLocalSaveAmount.Focus ();
                        }

                    }
                    else
                    {
                        deletePrviousInvoices ();
                        //save invoice to data base with keyword RUN
                        SaveInvoices ( "SAVE" , "نقد" );
                        MessageBox.Show ( "DONE" , "Message" );
                        //buttonInvoicePrint_Click ( sender ,e);
                        InitializeFunction ();
                    }
                }
                buttonPrintInvoice.Enabled = true;
            }
        }

        private void buttonPrintInvoice_Click(object sender , EventArgs e)
        {
            var UsedClass = new BasicClass ();
            var dt = new DataTable ();
            //if ( dataGridViewItems.Rows.Count > 0 || textBoxInvoiceNO.Text != "" )
            //{
            if ( textBoxCustomerName.Text == "" )
            {
                MessageBox.Show ( "يرجى ادخال أسم الزبون" , "Message" );
                textBoxCustomerName.Focus ();
            }
            else
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter ( "@InvoiceNo" , SqlDbType.Int );
                param[1] = new SqlParameter ( "@CustomerName" , SqlDbType.NVarChar , 250 );
                param[0].Value = textBoxInvoiceNO.Text;
                param[1].Value = textBoxCustomerName.Text.Trim ();

                dt = UsedClass.selectdata ( "Casher_PrintForma" , param );
                var crp = new Reports.PurshaceReport ();
                CrystalDecisions.CrystalReports.Engine.TextObject invoiceType = (CrystalDecisions.CrystalReports.Engine.TextObject) crp.ReportDefinition.Sections["Section2"].ReportObjects["Text15"];
                invoiceType.Text = textBoxInvoiceNO.Text;
                crp.SetDataSource ( dt );
                PrintForm form = new PrintForm ();
                form.crystalReportViewer1.ReportSource = crp;
                form.ShowDialog ();
            }

            //}
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            listBoxSelectionItems.Items.Clear ();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 250 );
            param[0].Value = comboBoxCategories.Text;

            dt = UsedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );

            for ( int i = 0 ; i < dt.Rows.Count ; i++ )
            {
                listBoxSelectionItems.Items.Add ( dt.Rows[i]["ItemName"] );
            }
        }

        private void comboBoxCategories_DropDown(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            dt = UsedClass.selectdata ( "Casher_Get_All_Category" , null );
            comboBoxCategories.DataSource = dt;
            comboBoxCategories.DisplayMember = "CatergoryName";
            comboBoxCategories.ValueMember = "CategoryID";
        }

        private void textBoxBarCode_KeyDown(object sender , KeyEventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            if ( e.KeyValue == (char) Keys.Enter )
            {
                if ( textBoxBarCode.Text != "" )
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 250 );
                    param[0].Value = textBoxBarCode.Text.Trim ();

                    dt = UsedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
                    textBoxBarCode.Text = "";
                    for ( int i = 0 ; i < dt.Rows.Count ; i++ )
                    {
                        var ItemName = dt.Rows[i]["ItemName"].ToString ();
                        var price = dt.Rows[i]["price_for_buy"].ToString ();
                        var StockQuantity = int.Parse ( dt.Rows[i]["StockQuantity"].ToString () );
                        var CriticalRange = int.Parse ( dt.Rows[i]["Critical_Quantity"].ToString () );
                        var ExpireDate = dt.Rows[i]["ItemExpire"].ToString ();
                        //note
                        price = "1";
                        writeIntoGrid ( ItemName , price , StockQuantity , CriticalRange , ExpireDate );
                    }
                }
            }
        }

        private void writeIntoGrid(string itemName , string price , int stockQuantity , int criticalRange , string expireDate)
        {
            if ( CheckDuplicate ( itemName ) )
            {

                int idx = dataGridViewItems.Rows.Add ();

                DataGridViewRow row = dataGridViewItems.Rows[idx];
                row.Cells["ColumnCounter"].Value = counter;     //تسلسل المواد
                row.Cells["ColumnItemName"].Value = itemName;  //اسم المادة
                row.Cells["ColumnItemQuantity"].Value = 1;     //كمية المادة
                row.Cells["ColumnItemPrice"].Value = price;     //   سعر البيع 
                row.Cells["ColumnTotal"].Value = int.Parse ( price ) * 1;   //مجموع
                row.Cells["ColumnStockQuantity"].Value = stockQuantity;
                row.Cells["ColumnCriticalRange"].Value = criticalRange;
                row.Cells["ColumnExpireDate"].Value = expireDate;
                counter++;
                moneyCalcuation ();
            }

        }

        private void moneyCalcuation()
        {
            var totalInvoice = 0.0;
            var FinalTotal = 0.0;
            for ( int i = 0 ; i < dataGridViewItems.Rows.Count ; i++ )
            {
                totalInvoice += float.Parse ( dataGridViewItems.Rows[i].Cells["ColumnTotal"].Value.ToString () );
                FinalTotal = totalInvoice;
            }
            textBoxTotalInvoice.Text = totalInvoice.ToString ();
            textBoxFinalAmount.Text = FinalTotal.ToString ();
            textBoxLocalSaveAmount.Text = "0";
            textBoxDollarSaveAmount.Text = "0";
            textBoxTotalSaveAmount.Text = "0";
            textBoxReminder.Text = "0";
            //textBoxTotalInvoice.Text = string.Format ( System.Globalization.CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{00:C0}" , totalInvoice );
            //textBoxFinalAmount.Text = string.Format ( System.Globalization.CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C00}" , FinalTotal );

        }

        private bool CheckDuplicate(string itemName)
        {
            for ( int i = 0 ; i < dataGridViewItems.Rows.Count ; i++ )
            {
                if ( dataGridViewItems.Rows[i].Cells["ColumnItemName"].Value != null )
                {
                    if ( dataGridViewItems.Rows[i].Cells["ColumnItemName"].Value.ToString () == itemName )
                    {
                        int quantity = Convert.ToInt32 ( dataGridViewItems.Rows[i].Cells["ColumnItemQuantity"].Value.ToString () );
                        int price = Convert.ToInt32 ( dataGridViewItems.Rows[i].Cells["ColumnItemPrice"].Value.ToString () );
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

        private void listBoxSelectionItems_MouseDoubleClick(object sender , MouseEventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            if ( listBoxSelectionItems.Enabled == true )
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter ( "@Item" , SqlDbType.NVarChar , 250 );
                param[0].Value = listBoxSelectionItems.Text;

                dt = UsedClass.selectdata ( "CasherForm_Selectitem_UsingBarcodeORName" , param );
                if ( dt.Rows.Count > 0 )
                {
                    var ItemName = dt.Rows[0]["ItemName"].ToString ();
                    var price = dt.Rows[0]["price_for_buy"].ToString ();
                    var StockQuantity = int.Parse ( dt.Rows[0]["StockQuantity"].ToString () );
                    var CriticalRange = int.Parse ( dt.Rows[0]["Critical_Quantity"].ToString () );
                    var ExpireDate = dt.Rows[0]["ItemExpire"].ToString ();
                    //note
                    price = "1";
                    writeIntoGrid ( ItemName , price , StockQuantity , CriticalRange , ExpireDate );
                }

            }
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
                            var Price = float.Parse ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemPrice"].Value.ToString () );
                            var Quantity = int.Parse ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemQuantity"].Value.ToString () );
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
                        if ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemPrice"].Value != null )
                        {
                            var Price = float.Parse ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemPrice"].Value.ToString () );
                            var Quantity = int.Parse ( dataGridViewItems.Rows[e.RowIndex].Cells["ColumnItemQuantity"].Value.ToString () );
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

                    default:
                        break;
                }
            }
        }

        private void dataGridViewItems_SelectionChanged(object sender , EventArgs e)
        {
            if ( dataGridViewItems.CurrentRow.Index >= 0 )
            {
                if ( dataGridViewItems.Rows[dataGridViewItems.CurrentRow.Index].Cells["ColumnItemName"].Value != null )
                {
                    var ItemExpire = dataGridViewItems.Rows[dataGridViewItems.CurrentRow.Index].Cells["ColumnExpireDate"].Value.ToString ();
                    var StockQuantity = dataGridViewItems.Rows[dataGridViewItems.CurrentRow.Index].Cells["ColumnStockQuantity"].Value.ToString ();
                    var CriticalRange = dataGridViewItems.Rows[dataGridViewItems.CurrentRow.Index].Cells["ColumnCriticalRange"].Value.ToString ();
                    textBoxStockQuantity.Text = StockQuantity;
                    textBoxCriticalRange.Text = CriticalRange;
                    textBoxExpireDate.Text = ItemExpire;
                }

            }
        }

        private void textBoxDiscountPercentage_TextChanged(object sender , EventArgs e)
        {

            if ( textBoxDiscountPercentage.Text != "" && textBoxDiscountPercentage.Text != "0" )
            {

                textBoxDiscountAmount.Enabled = false;
                radioButtonDiscountAmount.Enabled = false;
                radioButtonPercentageDiscount.Checked = true;
                if ( textBoxLocalSaveAmount.Text != "" || textBoxLocalSaveAmount.Text != "0" )
                {
                    textBoxLocalSaveAmount.Text = "0";
                    textBoxTotalSaveAmount.Text = "0";
                    textBoxReminder.Text = "0";
                }
                if ( textBoxDollarSaveAmount.Text != "" || textBoxDollarSaveAmount.Text != "0" )
                {
                    textBoxTotalSaveAmount.Text = "0";
                    textBoxReminder.Text = "0";
                    textBoxDollarSaveAmount.Text = "0";
                }
                var TotalAmount = 0.0;
                var PercentageDisount = 0.0;
                var FinalAmount = 0.0;
                var currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                TotalAmount = Convert.ToDouble ( textBoxTotalInvoice.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ) );
                PercentageDisount = int.Parse ( textBoxDiscountPercentage.Text );
                PercentageDisount = PercentageDisount * 1 / 100;
                PercentageDisount = PercentageDisount * TotalAmount;
                FinalAmount = TotalAmount - PercentageDisount;
                textBoxFinalAmount.Text = FinalAmount.ToString ();
                textBoxFinalAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , FinalAmount );

            }
            else
            {

                textBoxDiscountAmount.Enabled = true;
                radioButtonDiscountAmount.Enabled = true;
                radioButtonPercentageDiscount.Checked = false;
                moneyCalcuation ();

            }
        }

        private double IQPaidAmount()
        {
            if ( textBoxLocalSaveAmount.Text != "" )
            {
                var IQPaidAmount = 0.0;
                var currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                IQPaidAmount = Convert.ToDouble ( textBoxLocalSaveAmount.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ) );
                return IQPaidAmount;
            }
            else
                return 0.0;
        }

        private double USPaidAmount()
        {
            if ( textBoxDollarSaveAmount.Text != "" )
            {
                var USPaidAmount = 0.0;
                var PercentageTransfer = 0.0;
                USPaidAmount = Convert.ToDouble ( textBoxDollarSaveAmount.Text );

                PercentageTransfer = Convert.ToDouble ( textBoxPercentageTransfer.Text );
                USPaidAmount = USPaidAmount * PercentageTransfer;
                return USPaidAmount;
            }
            else
                return 0.0;
        }

        private void reminderFunction()
        {
            var currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
            var InvoiceNetAmount = Convert.ToDouble ( textBoxFinalAmount.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ) );
            var TotalPaidAmount = Convert.ToDouble ( textBoxTotalSaveAmount.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ) );
            var ReminderPaid = 0.0;

            if ( InvoiceNetAmount > TotalPaidAmount )
            {
                ReminderPaid = InvoiceNetAmount - TotalPaidAmount;
                textBoxReminder.BackColor = Color.FromArgb ( 46 , 204 , 113 );
            }
            else if ( InvoiceNetAmount < TotalPaidAmount )
            {
                ReminderPaid = InvoiceNetAmount - TotalPaidAmount;
                textBoxReminder.BackColor = Color.FromArgb ( 192 , 57 , 43 );
                textBoxReminder.ForeColor = Color.FromArgb ( 52 , 73 , 94 );
            }
            else if ( InvoiceNetAmount == TotalPaidAmount )
            {
                textBoxReminder.BackColor = Color.FromArgb ( 149 , 165 , 166 );
                textBoxReminder.ForeColor = Color.FromArgb ( 52 , 73 , 94 );
            }
            textBoxReminder.Text = ReminderPaid.ToString ();
            textBoxReminder.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , ReminderPaid );


        }

        private void textBoxDiscountAmount_TextChanged(object sender , EventArgs e)
        {
            if ( textBoxDiscountAmount.Text != "0" && textBoxDiscountAmount.Text != "" )
            {
                if ( textBoxLocalSaveAmount.Text != "" || textBoxLocalSaveAmount.Text != "0" )
                {
                    textBoxLocalSaveAmount.Text = "0";
                    textBoxTotalSaveAmount.Text = "0";
                    textBoxReminder.Text = "0";
                }
                if ( textBoxDollarSaveAmount.Text != "" || textBoxDollarSaveAmount.Text != "0" )
                {
                    textBoxTotalSaveAmount.Text = "0";
                    textBoxReminder.Text = "0";
                    textBoxDollarSaveAmount.Text = "0";
                }
                textBoxDiscountPercentage.Enabled = false;
                radioButtonPercentageDiscount.Enabled = false;
                radioButtonDiscountAmount.Checked = true;
                var TotalAmount = 0.0;
                var DiscountAmount = 0;
                var FinalAmount = 0.0;
                var currencyformat = CultureInfo.GetCultureInfo ( "AR-iq" );
                TotalAmount = Convert.ToDouble ( textBoxTotalInvoice.Text.Replace ( currencyformat.NumberFormat.CurrencySymbol , "" ) );
                DiscountAmount = int.Parse ( textBoxDiscountAmount.Text );
                FinalAmount = TotalAmount - DiscountAmount;
                textBoxFinalAmount.Text = FinalAmount.ToString ();
                textBoxFinalAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , FinalAmount );
            }
            else
            {
                textBoxDiscountPercentage.Enabled = true;
                radioButtonPercentageDiscount.Enabled = true;
                radioButtonDiscountAmount.Checked = false;
                moneyCalcuation ();


            }
        }

        private void textBoxLocalSaveAmount_TextChanged(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                if ( textBoxLocalSaveAmount.Text != "" )
                {
                    var IQAmount = IQPaidAmount ();
                    var USAmount = USPaidAmount ();
                    var TotalPaidAmount = IQAmount + USAmount;
                    textBoxTotalSaveAmount.Text = TotalPaidAmount.ToString ();
                    textBoxTotalSaveAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , TotalPaidAmount );
                    reminderFunction ();
                }
                else
                {
                    textBoxLocalSaveAmount.SelectAll ();
                }

            }
        }

        private void textBoxDollarSaveAmount_TextChanged(object sender , EventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                if ( textBoxDollarSaveAmount.Text != "" )
                {

                    var IQAmount = IQPaidAmount ();
                    var USAmount = USPaidAmount ();
                    var TotalPaidAmount = IQAmount + USAmount;
                    textBoxTotalSaveAmount.Text = TotalPaidAmount.ToString ();
                    textBoxTotalSaveAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , TotalPaidAmount );
                    reminderFunction ();
                }
                else
                {
                    //textBoxDollarSaveAmount.Text = "0";
                    textBoxDollarSaveAmount.SelectAll ();
                }
            }
        }

        private void getMainInformation()
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            dt = UsedClass.selectdata ( "Casher_select_all_IDs" , null );

            if ( dt.Rows.Count > 0 )
            {
                textBoxInvoiceNO.Text = dt.Rows[0]["InvoiceNo"].ToString ();
                textBoxPercentageTransfer.Text = dt.Rows[0]["PercentageTransfer"].ToString ();

            }
            textBoxUserName.Text = BasicClass.UserName;
        }

        private void textBoxLocalSaveAmount_MouseDoubleClick(object sender , MouseEventArgs e)
        {
            if ( dataGridViewItems.Rows.Count > 0 )
            {
                textBoxLocalSaveAmount.Text = textBoxFinalAmount.Text;
                var TotalPaidAmount = IQPaidAmount () + USPaidAmount ();
                textBoxTotalSaveAmount.Text = TotalPaidAmount.ToString ();
                //textBoxTotalSaveAmount.Text = string.Format ( CultureInfo.CreateSpecificCulture ( "ar-iq" ) , "{0:C0}" , TotalPaidAmount );
                reminderFunction ();
            }
        }

        private void buttonPausesInvoices_Click(object sender , EventArgs e)
        {
            var form = new SavedInvoicesForm ();
            form.LoadSaveInvoices ( "شراء" );
            form.ShowDialog ();
        }

        private void textBoxDollarSaveAmount_Enter(object sender , EventArgs e)
        {
            textBoxDollarSaveAmount.Text = "";
        }

        private void PurshaceForm_Activated(object sender , EventArgs e)
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
                    textBoxInvoiceNO.Text = dt.Rows[0]["invoiceNumber"].ToString ();
                    dateTimePickerInvoiceDate.Text = dt.Rows[0]["InvoiceDate"].ToString ();
                    for ( int i = 0 ; i < dt.Rows.Count ; i++ )
                    {

                        var ItemName = dt.Rows[i]["itemName"].ToString ();
                        var Quantity = int.Parse ( dt.Rows[i]["itemQuantity"].ToString () );

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
    }
}
