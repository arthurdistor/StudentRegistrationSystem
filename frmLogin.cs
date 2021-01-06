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

namespace TestStudentRegistration
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public string username = "";
        private void button1_Click(object sender, EventArgs e)
        {
          
            if(String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Field/s cannot be empty");
            }
            else
            {
                ValidateUser();
            }
        }
        private void ValidateUser()
        {
            string query = "SELECT _UserRole from _tblUserAccounts WHERE _Username = @username and _Password=@password";
            string query1 = "SELECT _Name from _tblUserAccounts WHERE _Username = @username and _Password=@password";
            string userrole = "";
          
            //For Devs, Change the connection string to your own config.
            string connectionString = @"Server=DESKTOP-8SJ75OR\SQLEXPRESS;Database=DBStudentRegistrationSystem;Trusted_Connection=True;";
          

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand(query, con);
            SqlCommand sqlcmd1 = new SqlCommand(query1, con);
            sqlcmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUser.Text;
            sqlcmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPass.Text;
            sqlcmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUser.Text;
            sqlcmd1.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPass.Text;
            con.Open();

            userrole = (string)sqlcmd.ExecuteScalar();
            username = (string)sqlcmd1.ExecuteScalar();

            if (String.IsNullOrEmpty(userrole) || String.IsNullOrEmpty(username))
            {
                MessageBox.Show("Incorrect username or password");
                return;
            }
            userrole = userrole.Trim();
       
            if (userrole == "Admin")
            {
                MessageBox.Show("You are logged in as " + userrole);
                frmAdmin form = new frmAdmin(username);
                form.Show();
                this.Hide();
                    
            }
            else
            {
                MessageBox.Show("You are logged in as " + userrole);
            }
            /* else if (returnValue == "User")
             {
                 MessageBox.Show("You are logged in as a User");
                 frmUser form = new frmUser();
                 form.Show();
                 this.Hide();
             }*/
        }
    }
}
