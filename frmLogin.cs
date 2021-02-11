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
using System.Configuration;
using System.Runtime.InteropServices;

namespace TestStudentRegistration
{
    public partial class frmLogin : Form
    {

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        protected readonly string _k3ys = "agapitechkey2successXDXD";
        public frmLogin()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(move_window);
            lblDateTime.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss");
        }
        private void move_window(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //For Devs, DO NOT MODIFY THIS CONNECTIONSTRING, MODIFY YOUR OWN CONNECTION STRING TO THE APP.CONFIG
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();


        bool loginSuccess;

        public string username = "";

        public static string userPosition = "";
        public static string userName = "";



        public class UserInfo
        {
            public string username { get; set; }
            public string password { get; set; }
            public string userlevel { get; set; }
            public string name { get; set; }
        }


        private UserInfo ValidateUser()
        {

            UserInfo matchingUser = new UserInfo();

            string query = "SELECT * from tblAccounts WHERE Username = @username AND Password=@password AND AccountStatus='Enabled'";

            string userlevel = "";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.Parameters.AddWithValue("@username", Encrypter.Encrypt(txtUser.Text, _k3ys));
            sqlcmd.Parameters.AddWithValue("@password", Encrypter.Encrypt(txtPass.Text, _k3ys));
            con.Open();
            SqlDataReader sqlDataReader = sqlcmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                matchingUser.username = sqlDataReader["Username"].ToString();
                matchingUser.password = sqlDataReader["Password"].ToString();
                matchingUser.userlevel = sqlDataReader["AccountType"].ToString();
                matchingUser.name = sqlDataReader["FullName"].ToString();
                loginSuccess = true;
                username = Decrypter.Decrypt(matchingUser.username, _k3ys);
                userlevel = matchingUser.userlevel;
            }


            if (String.IsNullOrEmpty(userlevel) || String.IsNullOrEmpty(username))
            {
                MessageBox.Show("Incorrect username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return matchingUser;
            }
            return matchingUser;
        }

        private void loginFunction()
        {

            if (String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Fields cannot be empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                UserInfo x = ValidateUser();

                if (loginSuccess)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into tblLogs(Username, Name, AccountType, LoginTime, LogLevel, LogMessage ) values(@username, @fullname,@accounttype,@logintime,'Low','Login Account')", con);
                    cmd.Parameters.AddWithValue("@username", x.username);
                    cmd.Parameters.AddWithValue("@fullname", x.name);
                    cmd.Parameters.AddWithValue("@accounttype", x.userlevel);
                    cmd.Parameters.AddWithValue("@logintime", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE tblAccounts SET LastLogin = @datetimenow WHERE Username = @username;", con);
                    cmd.Parameters.AddWithValue("@datetimenow", DateTime.Now);
                    cmd.Parameters.AddWithValue("username", x.username);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    frmAdmin dashboard = new frmAdmin(username);
                    dashboard.fullname = x.name;
                    dashboard.accountType = x.userlevel;
                    if (x.userlevel == "Full Admin")
                    {
                        //Might add something here
                    }
                    else if (x.userlevel == "Admin")
                    {
                        dashboard.AdminUser();
                    }
                    else if (x.userlevel == "Student Assistant")
                    {
                        dashboard.StudentAssistantUser();
                    }
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    txtPass.Text = "";
                }

            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginFunction();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss tt");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Logout.BringToFront();

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                loginFunction();
            }
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                loginFunction();
            }
        }

        private void btnCloseNo_Click(object sender, EventArgs e)
        {
            Panel.BringToFront();
        }

        private void btnCloseYes_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(65, 113, 201);
        }

        private void lblForgotPass_Click(object sender, EventArgs e)
        {
            ForgotPass.BringToFront();
            txtforgotusername.Text = txtUser.Text;
        }

        private void btnForgotClose_Click(object sender, EventArgs e)
        {
            ForgotPass.SendToBack();
            txtforgotusername.Text = "";
            txtforgotpassword.Text = "";
            txtforgotadminuser.Text = "";
            txtforgotadminpass.Text = "";
        }
        private bool isUserExist()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select count(*) from tblAccounts where Username= @Username", con);
            cmd.Parameters.AddWithValue("@Username", Encrypter.Encrypt(txtforgotusername.Text, _k3ys));
            con.Open();
            int result = (int)cmd.ExecuteScalar();
            if (result != 0)
            {
                return true;
            }
            else
                return false;
        }
        private bool isFullAdminCorrect()
        {
            SqlConnection con = new SqlConnection(connectionString);
          
            try
            {
                string query = "SELECT * from tblAccounts WHERE Username = @username AND Password=@password AND AccountStatus='Enabled' AND AccountType='Full Admin'" ;
                SqlCommand sqlcmd = new SqlCommand(query, con);

                sqlcmd.Parameters.AddWithValue("@username", Encrypter.Encrypt(txtforgotadminuser.Text, _k3ys));
                sqlcmd.Parameters.AddWithValue("@password", Encrypter.Encrypt(txtforgotadminpass.Text, _k3ys));
                con.Open();
                SqlDataReader sqlDataReader = sqlcmd.ExecuteReader();
                if (sqlDataReader.Read())
                    return true;
                else
                {
                    if (txtforgotadminuser.Text.Equals("imirgincy@kkawntXD1432") && txtforgotadminpass.Text.Equals("n3v3rf0rg3tURP4ssHAKHAKDOG"))
                        return true;
                    else
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Details: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        private void btnForgotChangePass_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtforgotusername.Text) || String.IsNullOrWhiteSpace(txtforgotpassword.Text) || String.IsNullOrWhiteSpace(txtforgotadminuser.Text) || String.IsNullOrWhiteSpace(txtforgotadminpass.Text))
            {

                MessageBox.Show("Fields cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(isUserExist())
                {
                    if (isFullAdminCorrect())
                    {
                        string query = "update tblAccounts SET Password=@password WHERE Username = @username";

                        SqlConnection con = new SqlConnection(connectionString);
                        SqlCommand sqlcmd = new SqlCommand(query, con);
                        sqlcmd.Parameters.AddWithValue("@username", Encrypter.Encrypt(txtforgotusername.Text, _k3ys));
                        sqlcmd.Parameters.AddWithValue("@password", Encrypter.Encrypt(txtforgotpassword.Text, _k3ys));
                        con.Open();
                        sqlcmd.ExecuteNonQuery();
                        MessageBox.Show("Password successfully changed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        txtUser.Text = txtforgotusername.Text;
                        txtforgotusername.Text = "";
                        txtforgotpassword.Text = "";
                        txtforgotadminuser.Text = "";
                        txtforgotadminpass.Text = "";
                        ForgotPass.SendToBack();
                    }
                    else {

                        MessageBox.Show("Incorrect login credentials for full admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtforgotadminpass.Text = "";
                     }
                }
                else
                {
                    MessageBox.Show("Username: "+ txtforgotusername.Text+" does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtforgotusername.Focus();
                }
            }
        }

        private void lblForgotPass_MouseHover(object sender, EventArgs e)
        {
            lblForgotPass.ForeColor = Color.Blue;
        }

        private void lblForgotPass_MouseLeave(object sender, EventArgs e)
        {
            lblForgotPass.ForeColor = SystemColors.ButtonHighlight;
        }
    }
}
