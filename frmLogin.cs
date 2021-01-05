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
            string returnValue = "";

            //For Devs, Change the connection string to your own config.
            string connectionString = @"Server=DESKTOP-8SJ75OR\SQLEXPRESS;Database=DBStudentRegistrationSystem;Trusted_Connection=True;";
          

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUser.Text;
            sqlcmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPass.Text;
            con.Open();

            returnValue = (string)sqlcmd.ExecuteScalar();


            //EDIT to avoid NRE 
            if (String.IsNullOrEmpty(returnValue))
            {
                MessageBox.Show("Incorrect username or password");
                return;
            }
            returnValue = returnValue.Trim();
            if (returnValue == "Admin")
            {
                MessageBox.Show("You are logged in as " + returnValue);
                frmAdmin form = new frmAdmin();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are logged in as " + returnValue);
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
