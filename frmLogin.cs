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
namespace TestStudentRegistration
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            
        }
        //For Devs, Change the connection string to your own config.
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        bool loginSuccess;

        public string username = "";

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

            string query = "SELECT * from tblAccounts WHERE Username = @username and Password=@password";

            string userlevel = "";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.Parameters.AddWithValue("@username", txtUser.Text);
            sqlcmd.Parameters.AddWithValue("@password", txtPass.Text);
            con.Open();
            SqlDataReader sqlDataReader = sqlcmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                matchingUser.username = sqlDataReader["Username"].ToString();
                matchingUser.password = sqlDataReader["Password"].ToString();
                matchingUser.userlevel = sqlDataReader["AccountType"].ToString();
                matchingUser.name = sqlDataReader["FullName"].ToString();
                loginSuccess = true;
            }

            username = matchingUser.username;
            userlevel = matchingUser.userlevel;

            if (String.IsNullOrEmpty(userlevel) || String.IsNullOrEmpty(username))
            {
                MessageBox.Show("Incorrect username or password");
                return matchingUser;
            }
            userlevel = userlevel.Trim();

            if (userlevel == "Admin")
            {
                //MessageBox.Show("You are logged in as " + userlevel);
                frmAdmin form = new frmAdmin(username);
                form.Show();
                this.Hide();
                return matchingUser;
                
            }
            else
            {
                //MessageBox.Show("You are logged in as " + userlevel);
                return matchingUser;
            }
            /* else if (returnValue == "User")
             {
                 MessageBox.Show("You are logged in as a User");
                 frmUser form = new frmUser();
                 form.Show();
                 this.Hide();
             }*/
        }
        private void loginFunction()
        {

            if (String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Field/s cannot be empty");
            }
            else
            {

                UserInfo x = ValidateUser();

                if (loginSuccess)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into tblLogs(Username, AccountType, LoginTime ) values(@username,@accounttype,@logintime)", con);
                    cmd.Parameters.AddWithValue("@username", x.username);
                    cmd.Parameters.AddWithValue("@accounttype", x.userlevel);
                    cmd.Parameters.AddWithValue("@logintime", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE tblAccounts SET LastLogin = @datetimenow WHERE Username = @username;", con);
                    cmd.Parameters.AddWithValue("@datetimenow", DateTime.Now);
                    cmd.Parameters.AddWithValue("username", x.username);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    frmAdmin admin = new frmAdmin(username);
                    admin.Show();
                    this.Hide();
                }

            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginFunction();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                loginFunction();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                loginFunction();
            }
        }
    }
}
