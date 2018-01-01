using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Rresturant
{
    public partial class LoginForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public LoginForm()
        {
            InitializeComponent ();
        }

        private void labelExit_Click(object sender , EventArgs e)
        {
            Application.Exit ();
        }

        private void buttonExit_Click(object sender , EventArgs e)
        {
            Application.Exit ();
        }

        private void buttonEnter_Click(object sender , EventArgs e)
        {
            var dt = new DataTable ();
            var UsedClass = new BasicClass ();
            var form = new ControlingForm ();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter ( "@UserName" , SqlDbType.NVarChar , 250 );
            param[1] = new SqlParameter ( "@Passwrod" , SqlDbType.NVarChar , 50 );
            param[0].Value = textBoxUserName.Text;
            param[1].Value = textBoxPassword.Text;
            dt = UsedClass.selectdata ( "Login_Select_Users" , param );
            if ( dt.Rows.Count > 0 )
            {
                BasicClass.UserName = dt.Rows[0]["UserName"].ToString ();
                BasicClass.Password = dt.Rows[0]["Password"].ToString ();
                if ( dt.Rows[0]["ReportPermission"].ToString () == "True" )
                {
                    form.btn_PurshaceForm.Enabled = true;
                }
               
                if ( dt.Rows[0]["CasherPermission"].ToString () == "True" )
                {
                    form.btn_CasherForm.Enabled = true;
                }
               
                if ( dt.Rows[0]["StorePermission"].ToString () == "True" )
                {
                    form.btn_PurshaceForm.Enabled = true;
                    form.btn_ReportingForm.Enabled = true;
                }
                
                if ( dt.Rows[0]["SuperUser"].ToString () == "True" )
                {
                    form.btn_CasherForm.Enabled = true;
                    form.btn_PurshaceForm.Enabled = true;
                    form.btn_ReportingForm.Enabled = true;
                    form.btn_SettingForm.Enabled = true;
                }
                if ( dt.Rows[0]["ReportPermission"].ToString () == "False" && dt.Rows[0]["SuperUser"].ToString () == "False" && dt.Rows[0]["StorePermission"].ToString () == "False" && dt.Rows[0]["CasherPermission"].ToString () == "False" )
                {
                    MessageBox.Show ( "هذا المستخدم تم حضره من قبل مدير النظام" , "MESSAGE" );
                    Application.Exit ();
                }
                BasicClass.UserName = textBoxUserName.Text.Trim ();
                BasicClass.Password = textBoxPassword.Text.Trim ();
                form.ShowDialog ();
                this.Close ();
            }
            else
            {
                MessageBox.Show ( "خطا في ادخال اسم المعلومات" );
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(70, 70, 70);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
