using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Rresturant
{
    class BasicClass
    {

        SqlConnection Con = new SqlConnection ( "Data Source=localhost;Initial Catalog=SuperMarket;Persist Security Info=True;User ID=sa;Password=123" );
        public static string CoustomerName = "";
        public static Int16 UnrnningBillId = 0;

        public static Boolean flagModified = false;
        public static string UserName = "";
        public static string Password = "";
        public double PercentageTransfer = 0;
        public void OnlyLettersFunction(KeyPressEventArgs e)
        {
            e.Handled = !( char.IsLetter ( e.KeyChar ) || e.KeyChar == (char) Keys.Back || e.KeyChar == (char) Keys.Space );
        }

        //method to open connection
        public void DBopenConnection()
        {
            if ( Con.State != ConnectionState.Open )
            {
                Con.Open ();
            }
        }

        //method to close connection
        public void DBcloseConnection()
        {
            if ( Con.State == ConnectionState.Open )
            {
                Con.Close ();
            }
        }

        //method to select data from DB
        public DataTable selectdata(string storedProcedure , SqlParameter[] parameter)
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedure;
            cmd.Connection = Con;

            if ( parameter != null )
            {
                for ( int i = 0 ; i < parameter.Length ; i++ )
                {
                    cmd.Parameters.Add ( parameter[i] );
                }
            }
            SqlDataAdapter sda = new SqlDataAdapter ( cmd );
            DataTable dt = new DataTable ();
            sda.Fill ( dt );

            return dt;
        }

        //method to insert, update and delete DATA from DB
        public void ExecuteCommand(string StoredProcedure , SqlParameter[] parameter)
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;
            cmd.Connection = Con;
            if ( parameter != null )
            {
                cmd.Parameters.AddRange ( parameter );
            }
            Con.Open ();
            cmd.ExecuteNonQuery ();
            cmd.Parameters.Clear ();
            Con.Close ();

        }


    }
}
