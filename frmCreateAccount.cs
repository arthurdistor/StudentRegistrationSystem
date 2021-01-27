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
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }
        //For Devs, DO NOT MODIFY THIS CONNECTIONSTRING, MODIFY YOUR OWN CONNECTION STRING TO THE APP.CONFIG
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(comboRole.Text) || String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(txtPassword.Text) || String.IsNullOrWhiteSpace(txtSecurityPass.Text))
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                CreateAccount();
            }
        }


        private void ClearText()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {

                    if (control is TextBox)
                        (control as TextBox).Clear();

                    if (control is ComboBox)
                        (control as ComboBox).Text = "";

                    else
                        func(control.Controls);
                }
               
            };

            func(Controls);
        }
        private void CreateAccount()
        {
            
          
          

            
            
            SqlConnection con = new SqlConnection(connectionString);
            //to be updated
            SqlCommand scmd = new SqlCommand("select _Password from _tblUserAccounts where _Name ='" + frmAdmin.activeUser + "'", con);
            con.Open();
            string user = (string)scmd.ExecuteScalar();
            con.Close();
            MessageBox.Show(user);
            if (txtSecurityPass.Text == user)
            {
                SqlCommand cmd = new SqlCommand("select * from _tblUserAccounts where _Username ='" + txtUsername.Text + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dr.Close();
                    cmd = new SqlCommand("insert into _tblUserAccounts values(@username,@password,@name,@userrole)", con);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@userrole", comboRole.SelectedItem);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Account is created. You may now login.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    ClearText();
                }

            }
            else
            {
                MessageBox.Show("Incorrect security password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

