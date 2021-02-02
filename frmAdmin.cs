using System;
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
using System.Configuration;
namespace TestStudentRegistration
{
    public partial class frmAdmin : Form
    {
        protected readonly string _k3ys = "agapitechkey2successXDXD";
        public static string activeUser;
        public frmAdmin(string username)
        {
            InitializeComponent();
            lblGreetings.Text = "Welcome " + username;
            activeUser = username;
            loadTotalData();
            loadAccountData();
            UIButtonDashboarClick();
            enableComponents(false);

        }
        //For Devs, DO NOT MODIFY THIS CONNECTIONSTRING, MODIFY YOUR OWN CONNECTION STRING TO THE APP.CONFIG
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        public string accountType = "";
        public static string userName = "";


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
            string totalStud = "SELECT COUNT(S.StudentID)FROM tblStudent S INNER JOIN tblRegistrationInfo R ON S.StudentID = R.StudentID WHERE R.Status = 'Enrolled' OR R.Status = 'Registered';";
            string totalNewStud = "SELECT COUNT(S.StudentID)FROM tblStudent S INNER JOIN tblRegistrationInfo R ON S.StudentID = R.StudentID WHERE admissionType = 'New Student' AND (R.Status = 'Enrolled' OR R.Status = 'Registered') ;";
            string totalTransferee = "SELECT COUNT(S.StudentID)FROM tblStudent S INNER JOIN tblRegistrationInfo R ON S.StudentID = R.StudentID WHERE admissionType = 'Transferee' AND (R.Status = 'Enrolled' OR R.Status = 'Registered') ;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand(totalStud, con);
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
            string ShowInfo = "SELECT S.StudentID, CONCAT(S.FirstName,' ',S.MiddleName,' ', S.LastName) AS 'Full Name',S.admissionType as 'Admission Type', E.Grade as 'Grade Level' from tblStudent S INNER JOIN tblEducation E ON S.StudentID = E.StudentID INNER JOIN tblRegistrationInfo R ON S.StudentID = R.StudentID WHERE R.Status = 'Enrolled' OR R.Status = 'Registered' ORDER BY  S.timestamp asc;";
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
            string ShowInfo = "  SELECT accountID, FullName as 'Full Name', AccountType as 'Account Type', AccountStatus as 'Account Status' from tblAccounts";
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

            loadSimpleStudentData();
            loadTotalData();
            lblStudDateTime.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss");
            lblTimeDate.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss");
            lblAccTimeDate.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss");
            lblAdminTimeDate.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss");
        }

        private void dataGridSimpleStudentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dataGridSimpleStudentInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        frmStudentRegistration frmStudent = new frmStudentRegistration();
                        if (accountType.Equals("Full Admin"))
                        {
                            frmStudent.FullAdmin();
                        }
                        else if (accountType.Equals("Admin"))
                        {
                            frmStudent.AdminUser();
                        }
                        else if (accountType.Equals("Student Assistant"))
                        {
                            frmStudent.StudentAssistantUser();
                        }
                        frmStudent.disableComponents();
                        frmStudent.loadStudData(dataGridSimpleStudentInfo.Rows[e.RowIndex].Cells["StudentID"].FormattedValue.ToString());
                        frmStudent.studentNumberFromAdmin = dataGridSimpleStudentInfo.Rows[e.RowIndex].Cells["StudentID"].FormattedValue.ToString();
                        frmStudent.ShowDialog();
                    }
                }
            }

            catch (NullReferenceException ex)
            {
                MessageBox.Show("No Data Found");
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
            loadAccountData();
            enableComponents(false);
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
            Admin_Control.BringToFront();
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
            string query = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin FROM tblAccounts A WHERE A.Username='" + Encrypter.Encrypt(activeUser, _k3ys) + "';";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                txtFullname.Text = myReader[0].ToString();
                txtUsername.Text = Decrypter.Decrypt(myReader[1].ToString(), _k3ys);
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
            if ( e.RowIndex != -1)
            {
                if (dataGridAccount.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
                {

                    //Use this query if tblLogs was implemented
                    //  string query = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin, L.LogMessage FROM tblAccounts A RIGHT JOIN tblLogs L ON A.LogID = L.Logid WHERE A.accountID =" + dataGridAccount.CurrentCell.Value.ToString();

                    string query = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin FROM tblAccounts A WHERE A.accountID =" + dataGridAccount.Rows[e.RowIndex].Cells["accountID"].FormattedValue.ToString();

                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        txtFullname.Text = myReader[0].ToString();
                        txtUsername.Text = Decrypter.Decrypt(myReader[1].ToString(), _k3ys);
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
        private void EnableContentAddAccountPanel(Panel panel, bool enabled)
        {
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Enabled = enabled;
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
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            EnableContentAddAccountPanel(pnlCreateAccountComponents, true);

            pnlCreateAccount.BringToFront();
        }

        private void btnAddAccountBack_Click(object sender, EventArgs e)
        {
            Accounts.BringToFront();
        }

        private void buttonStudents_Click_1(object sender, EventArgs e)
        {
            UIButtonStudentsClick();
            enableComponents(true);
            loadFullStudentData();
            StudentTab.BringToFront();
        }
        private void createUserAccount()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                //to be updated
                SqlCommand scmd = new SqlCommand("select Password from tblAccounts where Username ='" + Encrypter.Encrypt(activeUser, _k3ys) + "'", con);
                con.Open();
                string user = (string)scmd.ExecuteScalar();
                con.Close();

                if (Encrypter.Encrypt(txtCreateAccSecPass.Text, _k3ys) == user)
                {
                    SqlCommand cmd = new SqlCommand("select * from tblAccounts where Username ='" + Encrypter.Encrypt(txtCreateAccUsername.Text, _k3ys) + "'", con);
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
                        cmd = new SqlCommand("insert into tblAccounts (Username, Password, FullName, AccountType, AccountStatus) values(@username,@password,@name,@userrole,@accstatus)", con);
                        cmd.Parameters.AddWithValue("@username", Encrypter.Encrypt(txtCreateAccUsername.Text, _k3ys));
                        cmd.Parameters.AddWithValue("@password", Encrypter.Encrypt(txtCreateAccPass.Text, _k3ys));
                        cmd.Parameters.AddWithValue("@name", txtCreateAccName.Text);
                        cmd.Parameters.AddWithValue("@userrole", cmbCreateAccType.SelectedItem);
                        cmd.Parameters.AddWithValue("@accstatus", "Enabled");

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created. You can now login.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadAccountData();
                        con.Close();
                        ClearText();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Security Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show("An error Occured \n" + Ex.Message);

            }
        }

        private void btnCreateAccAdd_Click(object sender, EventArgs e)
        {
            createUserAccount();
        }

        private void btnCreateAccCancel_Click(object sender, EventArgs e)
        {
            Admin_Control.BringToFront();
        }
        private void loadFullStudentData()
        {
            SqlConnection connection = new SqlConnection(connectionString); //use your connection string here


            var bindingSource = new BindingSource();
            string ShowInfo = "SELECT S.StudentID, S.LastName as 'Last Name', S.FirstName as 'First Name', S.MiddleName as 'Middlde Name', S.Gender, S.admissionType as 'Admission Type', E.ChosenCourse as 'Course' from tblStudent S INNER JOIN tblEducation E ON S.StudentID = E.StudentID INNER JOIN tblRegistrationInfo R ON S.StudentID = R.StudentID WHERE R.Status = 'Enrolled' OR R.Status = 'Registered' ORDER BY S.timestamp desc;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(ShowInfo, connection);
            try
            {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                bindingSource.DataSource = table;
                dataGridFullStudent.ReadOnly = true;
                dataGridFullStudent.DataSource = bindingSource;
                dataGridFullStudent.RowHeadersVisible = false;
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

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            buttonLogout1.ButtonColor = Color.White;
            buttonLogout1.BorderColor = Color.White;
            pictureBox8.BackColor = Color.White;

        }

        private void buttonLogout1_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.White;

        }

        private void buttonLogout1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromArgb(4, 45, 101);
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromArgb(4, 45, 101);
            buttonLogout1.ButtonColor = Color.FromArgb(4, 45, 101); ;
            buttonLogout1.BorderColor = Color.FromArgb(4, 45, 101); ;
        }
        public void StudentAssistantUser()
        {
            button_WOC4.Visible = false;
            btnAdminPanel.Visible = false;
            btnExport.Visible = false;
            btnFolder.Visible = false;
            btnEditStudent.Visible = false;
            btnAddStudent.Visible = false;
            btnExportStudent.Visible = false;
        }
        public void AdminUser()
        {
            btnAdminPanel.Visible = false;
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            loadSimpleStudentData();
            pnlDashboard.BringToFront();
            UIButtonDashboarClick();
        }

        private void buttonStudents_Click_2(object sender, EventArgs e)
        {
            UIButtonStudentsClick();
            enableComponents(true);
            loadFullStudentData();
            StudentTab.BringToFront();

        }

        private void buttonLogout1_Click_1(object sender, EventArgs e)
        {
            LogoutBox logoutBox = new LogoutBox();
            logoutBox.ShowDialog();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            LogoutBox logoutBox = new LogoutBox();
            logoutBox.ShowDialog();
        }

        private void pictureBox8_MouseHover_1(object sender, EventArgs e)
        {
            buttonLogout1.ButtonColor = Color.White;
            buttonLogout1.BorderColor = Color.White;
            pictureBox8.BackColor = Color.White;
        }

        private void buttonLogout1_MouseHover_1(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.White;
        }

        private void buttonLogout1_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromArgb(4, 45, 101);
        }

        private void pictureBox8_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromArgb(4, 45, 101);
            buttonLogout1.ButtonColor = Color.FromArgb(4, 45, 101);
            buttonLogout1.BorderColor = Color.FromArgb(4, 45, 101);
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmStudentRegistration frmStudentRegistration = new frmStudentRegistration();
            frmStudentRegistration.userName = activeUser;
            if (accountType.Equals("Full Admin"))
            {
                frmStudentRegistration.FullAdmin();
            }
            else if (accountType.Equals("Admin"))
            {
                frmStudentRegistration.AdminUser();
            }
            else if (accountType.Equals("Student Assistant"))
            {
                frmStudentRegistration.StudentAssistantUser();
            }
            frmStudentRegistration.btnEdit.Visible = false;
            frmStudentRegistration.ShowDialog();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridFullStudent.Rows.Count == 0)
                {
                    MessageBox.Show("No Data Found");
                }
                else
                {
                    frmStudentRegistration frmStudentRegistration = new frmStudentRegistration();
                    frmStudentRegistration.userName = activeUser;


                    if (accountType.Equals("Full Admin"))
                    {
                        frmStudentRegistration.FullAdmin();
                    }
                    else if (accountType.Equals("Admin"))
                    {
                        frmStudentRegistration.AdminUser();
                    }
                    else if (accountType.Equals("Student Assistant"))
                    {
                        frmStudentRegistration.StudentAssistantUser();
                    }
                    foreach (DataGridViewRow row in dataGridFullStudent.Rows)
                    {
                        frmStudentRegistration.loadStudData(dataGridFullStudent.Rows[row.Index].Cells["StudentID"].FormattedValue.ToString());
                        frmStudentRegistration.studentNumberFromAdmin = dataGridFullStudent.Rows[row.Index].Cells["StudentID"].FormattedValue.ToString();
                    }

                    frmStudentRegistration.btnEdit.Visible = false;
                    frmStudentRegistration.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data to show");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadFullStudentData();
            txtSearch.Clear();
        }
        private void searchStudent()
        {
            if (comboSearchType.Text.Equals("") || comboSearchType.Text.Equals(null))
            {
                MessageBox.Show("Please include what data to search");
                comboSearchType.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT S.StudentID, S.LastName as 'Last Name', S.FirstName as 'First Name', S.MiddleName as 'Middlde Name', S.Gender, S.admissionType as 'Admission Type', E.ChosenCourse as 'Course' from tblStudent S INNER JOIN tblEducation E ON S.StudentID = E.StudentID INNER JOIN tblRegistrationInfo R ON S.StudentID = R.StudentID where S." + comboSearchType.Text + " like'" + txtSearch.Text + "%' AND (R.Status = 'Enrolled' OR R.Status = 'Registered') ;", con);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridFullStudent.DataSource = dt;
                con.Close();
            }
        }
        private void searchStudentArc()
        {
            if (comboSearchTypeArc.Text.Equals("") || comboSearchTypeArc.Text.Equals(null))
            {
                MessageBox.Show("Please include what data to search");
                comboSearchType.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT S.StudentID, S.LastName as 'Last Name', S.FirstName as 'First Name', S.MiddleName as 'Middlde Name', S.Gender, S.admissionType as 'Admission Type', E.ChosenCourse as 'Course' from tblStudent S INNER JOIN tblEducation E ON S.StudentID = E.StudentID INNER JOIN tblRegistrationInfo R ON S.StudentID = R.StudentID where S." + comboSearchTypeArc.Text + " like'" + txtArcSearch.Text + "%' AND R.Status = 'Archived';", con);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                DataGridArchive.DataSource = dt;
                con.Close();
            }
        }
        private void loadArchiveStudentData()
        {
            SqlConnection connection = new SqlConnection(connectionString); 
            var bindingSource = new BindingSource();
            string ShowInfo = "SELECT S.StudentID, S.LastName as 'Last Name', S.FirstName as 'First Name', S.MiddleName as 'Middlde Name', S.Gender, S.admissionType as 'Admission Type', E.ChosenCourse as 'Course' from tblStudent S INNER JOIN tblEducation E ON S.StudentID = E.StudentID INNER JOIN tblRegistrationInfo R ON S.StudentID = R.StudentID WHERE R.Status = 'Archived' ORDER BY S.timestamp desc;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(ShowInfo, connection);
            try
            {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                bindingSource.DataSource = table;
                DataGridArchive.ReadOnly = true;
                DataGridArchive.DataSource = bindingSource;
                DataGridArchive.RowHeadersVisible = false;
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchStudent();
        }

        private void comboSearchType_TextChanged(object sender, EventArgs e)
        {
            searchStudent();
        }

        private void txtArcSearch_TextChanged(object sender, EventArgs e)
        {
            searchStudentArc();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            searchStudentArc();

        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            enableComponents(true);
            loadArchiveStudentData();
            Archive.BringToFront();
        }

        private void btnArchiveBack_Click(object sender, EventArgs e)
        {
            Admin_Control.BringToFront();
        }

        private void btnEditArc_Click(object sender, EventArgs e)
        {


            try
            {
                frmStudentRegistration frmStudentRegistration = new frmStudentRegistration();
                frmStudentRegistration.userName = activeUser;


                if (accountType.Equals("Full Admin"))
                {
                    frmStudentRegistration.FullAdmin();
                }
                else if (accountType.Equals("Admin"))
                {
                    frmStudentRegistration.AdminUser();
                }
                else if (accountType.Equals("Student Assistant"))
                {
                    frmStudentRegistration.StudentAssistantUser();
                }
                foreach (DataGridViewRow row in DataGridArchive.Rows)
                {
                    frmStudentRegistration.loadStudData(DataGridArchive.Rows[row.Index].Cells["StudentID"].FormattedValue.ToString());
                    frmStudentRegistration.studentNumberFromAdmin = DataGridArchive.Rows[row.Index].Cells["StudentID"].FormattedValue.ToString();
                }

                frmStudentRegistration.btnEdit.Visible = false;
                frmStudentRegistration.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data to show");
            }
            /*
            try
            {
                
                if (DataGridArchive.Rows != -1)
                {
                    if (DataGridArchive.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        frmStudentRegistration frmStudent = new frmStudentRegistration();
                        if (accountType.Equals("Full Admin"))
                        {
                            frmStudent.FullAdmin();
                        }
                        else if (accountType.Equals("Admin"))
                        {
                            frmStudent.AdminUser();
                        }
                        else if (accountType.Equals("Student Assistant"))
                        {
                            frmStudent.StudentAssistantUser();
                        }

                        frmStudent.disableComponents();
                        frmStudent.loadStudData(dataGridSimpleStudentInfo.Rows[e.RowIndex].Cells["StudentID"].FormattedValue.ToString());
                        frmStudent.ShowDialog();
                    }
                
                }
            }

            catch (NullReferenceException ex)
            {
                MessageBox.Show("No Data Found");
            }
            */
        }

        private void dataGridFullStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefreshArc_Click(object sender, EventArgs e)
        {
            loadArchiveStudentData();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (accountType.Equals("Full Admin"))
            {
               
            }
            else if (accountType.Equals("Admin"))
            {
               
            }
            else if (accountType.Equals("Student Assistant"))
            {
                btnEditArc.Visible = false;
               
            }
            Archive.BringToFront();
            loadArchiveStudentData();
        }
    }
}
