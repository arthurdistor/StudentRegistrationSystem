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
        //For Devs, Change the connection string to your own config.
        string connectionString = @"Server=DESKTOP-8SJ75OR\SQLEXPRESS;Database=DBStudentRegistrationSystem;Trusted_Connection=True;";


        public string username = "";
        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Field/s cannot be empty");
            }
            else
            {
            
                UserInfo x = ValidateUser();
               

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tblUserLogs values(@username,@accounttype,@logintime)", con);
                cmd.Parameters.AddWithValue("@username", x.username);
                cmd.Parameters.AddWithValue("@accounttype", x.userlevel);
                cmd.Parameters.AddWithValue("@logintime", DateTime.Now);
                MessageBox.Show(x.username);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
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

            string query = "SELECT * from _tblUserAccounts WHERE _Username = @username and _Password=@password";
            string query1 = "SELECT _Name from _tblUserAccounts WHERE _Username = @username and _Password=@password";



            string userlevel = "";




            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.Parameters.AddWithValue("@username", txtUser.Text);
            sqlcmd.Parameters.AddWithValue("@password", txtPass.Text);
            con.Open();
            SqlDataReader sqlDataReader = sqlcmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                matchingUser.username = sqlDataReader["_Username"].ToString();
                matchingUser.password = sqlDataReader["_Password"].ToString();
                matchingUser.userlevel = sqlDataReader["_UserRole"].ToString();
                matchingUser.name = sqlDataReader["_Name"].ToString();
            }



            /*SqlCommand sqlcmd1 = new SqlCommand(query1, con);
            sqlcmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUser.Text;
            sqlcmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPass.Text;
            sqlcmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUser.Text;
            sqlcmd1.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPass.Text;
            con.Open();

            userrole = (string)sqlcmd.ExecuteScalar();
            username = (string)sqlcmd1.ExecuteScalar();
            */

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
                MessageBox.Show("You are logged in as " + userlevel);
                frmAdmin form = new frmAdmin(username);
                form.Show();
                this.Hide();
                insertLogs();
                return matchingUser;
                
            }
            else
            {
                MessageBox.Show("You are logged in as " + userlevel);
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


        private void insertLogs()
            {
            
    
            

        }
    }
}
