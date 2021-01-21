﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestStudentRegistration
{
    public partial class frmAdmin : Form
    {
        public static string activeUser;
        public frmAdmin(string username)
        {
            InitializeComponent();
            lblGreetings.Text = "Welcome " +username;
            activeUser = username;
            loadTotalData();
            loadSimpleStudentData();
            loadAccountData();
            UIButtonDashboarClick();
            enableComponents(false);
          
        }
        string connectionString = @"Server=DESKTOP-8SJ75OR\SQLEXPRESS;Database=DBStudentRegistrationSystem;Trusted_Connection=True;";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStudentRegistration form1 = new frmStudentRegistration();
            form1.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }
        public void importFunction()
        {
            string readText = File.ReadAllText("");

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frmLogin form = new frmLogin();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            frmCreateAccount form = new frmCreateAccount();
            
                form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void loadTotalData()
        {
            SqlCommand cmd;
            string totalStud = "SELECT COUNT(StudentID)FROM tblStudent;";
            string totalNewStud = "SELECT COUNT(StudentID)FROM tblStudent WHERE admissionType = 'New Student';";
            string totalTransferee = "SELECT COUNT(StudentID)FROM tblStudent WHERE admissionType='Transferee';";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
           cmd  = new SqlCommand(totalStud, con);
           lblTotalStudents.Text = cmd.ExecuteScalar().ToString();
           cmd = new SqlCommand(totalNewStud, con);
            lblTotalNewStudents.Text = cmd.ExecuteScalar().ToString();
            cmd = new SqlCommand(totalTransferee, con);
            lblTotalTransferees.Text = cmd.ExecuteScalar().ToString();
            con.Close();

        }
        private void loadSimpleStudentData()
        {
            SqlConnection connection = new SqlConnection(connectionString); //use your connection string here


             var bindingSource = new BindingSource();
            string ShowInfo = "SELECT S.StudentID, CONCAT(S.FirstName,' ',S.MiddleName,' ', S.LastName) AS 'Full Name',S.admissionType as 'Admission Type', E.Grade as 'Grade Level' from tblStudent S INNER JOIN tblEducation E ON S.StudentID = E.StudentID ORDER BY S.timestamp desc;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(ShowInfo, connection);
            try
            {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                bindingSource.DataSource = table;
                dataGridSimpleStudentInfo.ReadOnly = true;
                dataGridSimpleStudentInfo.DataSource = bindingSource;
                dataGridSimpleStudentInfo.RowHeadersVisible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR Loading");
            }
            finally
            {
                connection.Close();
            }
        }
            
        private void loadAccountData()
        {
            SqlConnection connection = new SqlConnection(connectionString);


            var bindingSource = new BindingSource();
            string ShowInfo = "  SELECT accountID, FullName, AccountType, AccountType from tblAccounts";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(ShowInfo, connection);
            try
            {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                bindingSource.DataSource = table;
                dataGridAccount.ReadOnly = true;
                dataGridAccount.DataSource = bindingSource;
                dataGridAccount.RowHeadersVisible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR Loading");
            }
            finally
            {
                connection.Close();
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeDate.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss");
        }

        private void dataGridSimpleStudentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridSimpleStudentInfo.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                if (dataGridSimpleStudentInfo.CurrentCell != null && dataGridSimpleStudentInfo.CurrentCell.Value != null) 
                {
                    
                    frmStudentRegistration frmStudent = new frmStudentRegistration();
                    frmStudent.disableComponents();
                    frmStudent.loadStudData(dataGridSimpleStudentInfo.CurrentCell.Value.ToString());
                    frmStudent.ShowDialog();
                   
                }
            }
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            Admin_Control.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            loadSimpleStudentData();
            pnlDashboard.BringToFront();
            UIButtonDashboarClick();
        }
        private void UIButtonDashboarClick()
        {
            btnDashboard.BorderColor = Color.White;
            btnDashboard.ButtonColor = Color.White;
            buttonStudents.ButtonColor = Color.FromArgb(4, 45, 101);
            buttonStudents.BorderColor = Color.FromArgb(4, 45, 101);

        }
        private void UIButtonStudentsClick()
        {
            buttonStudents.ButtonColor = Color.White;
            buttonStudents.BorderColor = Color.White;
            btnDashboard.ButtonColor = Color.FromArgb(4, 45, 101);
            btnDashboard.BorderColor = Color.FromArgb(4, 45, 101);

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlDashboard.BringToFront();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            loadActiveUserInfo();
            Accounts.BringToFront();
        }

        private void buttonStudents_Click(object sender, EventArgs e)
        {
            StudentTab.BringToFront();
        }


         private void buttonLogout1_Click(object sender, EventArgs e)
        {
            LogoutBox logoutBox = new LogoutBox();
            logoutBox.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            LogoutBox logoutBox = new LogoutBox();
            logoutBox.ShowDialog();
        }

        private void btnAccountBack_Click(object sender, EventArgs e)
        {
            pnlDashboard.BringToFront();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enableComponents(true);
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            enableComponents(false);
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
        }

        private void enableComponents(Boolean isTrue)
        {

            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {

                    if (control is TextBox)
                        (control as TextBox).Enabled = isTrue;
                    if (control is ComboBox)
                        (control as ComboBox).Enabled = isTrue;

                    else
                        func(control.Controls);
                }

            };

            func(Controls);

        }


        private void loadActiveUserInfo()
        {

            //Use this query if tblLogs was implemented
            //string query = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin, L.LogMessage FROM tblAccounts A RIGHT JOIN tblLogs L ON A.LogID = L.Logid WHERE A.Username='" + activeUser+"';";
            string query = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin FROM tblAccounts A WHERE A.Username='" + activeUser+"';";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                txtFullname.Text = myReader[0].ToString();
                txtUsername.Text = myReader[1].ToString();
                comboAccountType.Text = myReader[2].ToString();
                comboAccStatus.Text = myReader[3].ToString();
                lblLastLogin.Text = myReader[4].ToString();
                //lblLastActivity.Text = myReader[5].ToString();

            }
            myReader.Close();
            connection.Close();
        }
        private void dataGridAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridAccount.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                if (dataGridAccount.CurrentCell != null && dataGridAccount.CurrentCell.Value != null)
                {

                    //Use this query if tblLogs was implemented
                  //  string query = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin, L.LogMessage FROM tblAccounts A RIGHT JOIN tblLogs L ON A.LogID = L.Logid WHERE A.accountID =" + dataGridAccount.CurrentCell.Value.ToString();
                   
                    string query = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin FROM tblAccounts A WHERE A.accountID =" + dataGridAccount.CurrentCell.Value.ToString();

                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        txtFullname.Text = myReader[0].ToString();
                        txtUsername.Text = myReader[1].ToString();
                        comboAccountType.Text = myReader[2].ToString();
                        comboAccStatus.Text = myReader[3].ToString();
                        lblLastLogin.Text = myReader[4].ToString();
                       // lblLastActivity.Text = myReader[5].ToString();
                    }
                    myReader.Close();
                    connection.Close();
                
                }
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            pnlCreateAccount.BringToFront();
        }

        private void btnAddAccountBack_Click(object sender, EventArgs e)
        {
            pnlDashboard.BringToFront();
        }

        private void buttonStudents_Click_1(object sender, EventArgs e)
        {
            frmStudentRegistration frmStudentRegistration = new frmStudentRegistration();
            frmStudentRegistration.Show();
            UIButtonStudentsClick();
        }
    }
}
