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
using System.Runtime.InteropServices;

namespace TestStudentRegistration
{
    public partial class frmAdmin : Form
    {
        protected readonly string _k3ys = "agapitechkey2successXDXD";
        public static string activeUser;
        public string fullname;
        public string accountType = "";
        public static string userName = "";

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        public frmAdmin(string username)
        {
            InitializeComponent();
            
            activeUser = username;
            loadTotalData();
            loadAccountData();
            UIButtonDashboarClick();
            enableComponents(false);
            this.MouseDown += new MouseEventHandler(move_window);

        }
        private void move_window(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public void insertLogs(string fullname, string accountType, string logLevel, string logMessage)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblLogs(Name, Username, AccountType, LoginTime, LogLevel, LogMessage ) values(@fullname, @username, @accounttype,@logintime,@loglevel,@logMessage)", con);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@username", userName);
            cmd.Parameters.AddWithValue("@accounttype", accountType);
            cmd.Parameters.AddWithValue("@logintime", DateTime.Now);
            cmd.Parameters.AddWithValue("@loglevel", logLevel);
            cmd.Parameters.AddWithValue("@logmessage", logMessage);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            lblGreetings.Text = "Welcome " + fullname;
            lblTimeDate.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss tt");
            studentDataGrid();
            loadSimpleStudentData();
            loadTotalData();
        }
        //For Devs, DO NOT MODIFY THIS CONNECTIONSTRING, MODIFY YOUR OWN CONNECTION STRING TO THE APP.CONFIG
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();




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
                dataGridSimpleStudentInfo.AllowUserToResizeRows = false;

            }
           
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot load data. Error Message: " + ex.Message, "Error Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dataGridAccount.AllowUserToResizeRows = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot load data. Error Message: " + ex.Message, "Error Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            lblLogsDateTime.Text = DateTime.Now.ToString("dddd , MMM dd yyyy" + Environment.NewLine + "hh:mm:ss tt");
            lblArcDateTime.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss tt");
            lblStudDateTime.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss tt");
            lblTimeDate.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss tt");
            lblAccTimeDate.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss tt");
            lblAdminTimeDate.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss tt");
        }

        private void dataGridSimpleStudentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
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
            btnDashboard.BorderColor = Color.FromArgb(192, 229, 237);
            btnDashboard.ButtonColor = Color.FromArgb(192, 229, 237);
            buttonStudents.ButtonColor = Color.FromArgb(4, 45, 101);
            buttonStudents.BorderColor = Color.FromArgb(4, 45, 101);
            btnControlPanel.ButtonColor = Color.FromArgb(4, 45, 101);
            btnControlPanel.BorderColor = Color.FromArgb(4, 45, 101);
        }
        private void UIButtonStudentsClick()
        {
            buttonStudents.ButtonColor = Color.FromArgb(192, 229, 237);
            buttonStudents.BorderColor = Color.FromArgb(192, 229, 237);
            btnDashboard.ButtonColor = Color.FromArgb(4, 45, 101);
            btnDashboard.BorderColor = Color.FromArgb(4, 45, 101);
            btnControlPanel.ButtonColor = Color.FromArgb(4, 45, 101);
            btnControlPanel.BorderColor = Color.FromArgb(4, 45, 101);
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
            btnSave.Enabled = false;
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
        private void UpdateAccount()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string AccType;
                int totalFA;
                bool isTrue =true;
                string countFullAdmin = "SELECT COUNT(tblAccounts.AccountType) from tblAccounts WHERE tblAccounts.AccountType='Full Admin' AND tblAccounts.AccountStatus='Enabled';";
                string checkAccountType = "SELECT AccountType from tblAccounts WHERE accountID = '" + dataGridAccount.CurrentRow.Cells["AccountID"].FormattedValue.ToString() + "';";
                var cmd = new SqlCommand(checkAccountType, connection);
                AccType = cmd.ExecuteScalar().ToString();
                cmd = new SqlCommand(countFullAdmin, connection);
                totalFA = (int)cmd.ExecuteScalar();

                if (AccType.Equals("Full Admin") && totalFA == 1)
                {
                    if (!comboAccountType.Text.Equals("Full Admin"))
                    {
                        MessageBox.Show("Account Type cannot be change if there is only 1 Full Admin", "Information cannot be change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboAccountType.Text = "Full Admin";
                        comboAccStatus.Text = "Enabled";
                        isTrue = false;
                    }
                    else if (comboAccStatus.Text.Equals("Disabled"))
                    {
                        MessageBox.Show("Account Status cannot be change if there is only 1 Full Admin", "Information cannot be changen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboAccStatus.Text = "Enabled";
                        comboAccountType.Text = "Full Admin";
                        isTrue = false;
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                if(isTrue)
                {
                    string query = @"
                        UPDATE tblAccounts
                        SET
                        FullName = @Fullname,            
                        Username = @Username,           
                        AccountType = @AccountType,            
                        AccountStatus = @AccountStatus
                        WHERE accountID ='" + dataGridAccount.CurrentRow.Cells["AccountID"].FormattedValue.ToString() + "';";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Fullname", txtFullname.Text);
                    command.Parameters.AddWithValue("@Username", Encrypter.Encrypt(txtUsername.Text, _k3ys));
                    command.Parameters.AddWithValue("@AccountType", comboAccountType.Text);
                    command.Parameters.AddWithValue("@AccountStatus", comboAccStatus.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Account information updated successfully", "Information cannot be changen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    insertLogs(fullname, accountType, "High", "Update Account Information for user: " + txtFullname.Text);

                }
                
            }
            
            catch (Exception ex)
            {

                MessageBox.Show("Details: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                loadAccountData();
            }
        }
           
        private void btnSave_Click(object sender, EventArgs e)
        {
            enableComponents(false);
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            UpdateAccount();
            
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
            string query = "SELECT TOP 1 A.FullName, A.Username, A.AccountType, A.AccountStatus, L.LoginTime, L.LogMessage FROM tblAccounts A RIGHT JOIN tblLogs L ON A.FullName = L.Name where A.Username ='" + Encrypter.Encrypt(activeUser, _k3ys) + "'ORDER BY L.LoginTime DESC;";
           // string query = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin FROM tblAccounts A WHERE A.Username='" + Encrypter.Encrypt(activeUser, _k3ys) + "';";
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
                lblLastActivity.Text = myReader[5].ToString();
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
                   string query = "SELECT TOP 1 A.FullName, A.Username, A.AccountType, A.AccountStatus, L.LoginTime, L.LogMessage FROM tblAccounts A RIGHT JOIN tblLogs L ON A.Username = L.Username where A.AccountID =" + dataGridAccount.Rows[e.RowIndex].Cells["accountID"].FormattedValue.ToString() + " ORDER BY L.LoginTime DESC;";
                   // string query = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin FROM tblAccounts A WHERE A.accountID =" + dataGridAccount.Rows[e.RowIndex].Cells["accountID"].FormattedValue.ToString();

                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader myReader = command.ExecuteReader();

                    if (myReader.Read())
                    {
                        txtFullname.Text = myReader[0].ToString();
                        txtUsername.Text = Decrypter.Decrypt(myReader[1].ToString(), _k3ys);
                        comboAccountType.Text = myReader[2].ToString();
                        comboAccStatus.Text = myReader[3].ToString();
                        lblLastLogin.Text = myReader[4].ToString();
                        lblLastActivity.Text = myReader[5].ToString();
                    }
                    
                    else
                    {
                        myReader.Close();
                        string queryNoLogs = "SELECT A.FullName, A.Username, A.AccountType, A.AccountStatus, A.LastLogin FROM tblAccounts A WHERE A.accountID =" + dataGridAccount.Rows[e.RowIndex].Cells["accountID"].FormattedValue.ToString();
                        command = new SqlCommand(queryNoLogs, connection);
                        myReader = command.ExecuteReader();
                        if (myReader.Read())
                        {
                            txtFullname.Text = myReader[0].ToString();
                            txtUsername.Text = Decrypter.Decrypt(myReader[1].ToString(), _k3ys);
                            comboAccountType.Text = myReader[2].ToString();
                            comboAccStatus.Text = myReader[3].ToString();
                            lblLastLogin.Text = "---";
                            lblLastActivity.Text="---";
                        }

                    }
                    myReader.Close();
                    connection.Close();
                    enableComponents(false);
                    btnSave.Enabled = false;
                    btnEdit.Enabled = true;
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
            clearTextAccount();
            pnlCreateAccount.BringToFront();
        }

        private void btnAddAccountBack_Click(object sender, EventArgs e)
        {
            Accounts.BringToFront();
            clearTextAccount();
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
                        MessageBox.Show("Your Account is created. You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch(Exception ex)
            {
                MessageBox.Show("Details: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCreateAccAdd_Click(object sender, EventArgs e)
        {
            createUserAccount();
        }

        private void btnCreateAccCancel_Click(object sender, EventArgs e)
        {
            Accounts.BringToFront();
            clearTextAccount();
           
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
                dataGridFullStudent.AllowUserToResizeRows = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Details: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            buttonLogout1.ButtonColor = Color.FromArgb(192, 229, 237);
            buttonLogout1.BorderColor = Color.FromArgb(192, 229, 237);
            pictureBox8.BackColor = Color.FromArgb(192, 229, 237);

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
            btnControlPanel.Visible = false;
            btnExport.Visible = false;
            btnFolder.Visible = false;
            btnEditStudent.Visible = false;
            btnAddStudent.Visible = false;
            btnExportStudent.Visible = false;
        }
        public void AdminUser()
        {
            btnControlPanel.Visible = false;
            btnAdminPanel.Visible = false;
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            loadSimpleStudentData();
            pnlDashboard.BringToFront();
            UIButtonDashboarClick();
            clearTextAccount();
        }

        private void buttonStudents_Click_2(object sender, EventArgs e)
        {
            UIButtonStudentsClick();
            enableComponents(true);
            loadFullStudentData();
            StudentTab.BringToFront();
            clearTextAccount();

        }

        private void buttonLogout1_Click_1(object sender, EventArgs e)
        {
            LogoutDialogBox.BringToFront();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            LogoutBox logoutBox = new LogoutBox();
            logoutBox.ShowDialog();
        }

        private void pictureBox8_MouseHover_1(object sender, EventArgs e)
        {
            buttonLogout1.ButtonColor = Color.FromArgb(192, 229, 237);
            buttonLogout1.BorderColor = Color.FromArgb(192, 229, 237);
            pictureBox8.BackColor = Color.FromArgb(192, 229, 237);
        }

        private void buttonLogout1_MouseHover_1(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromArgb(192, 229, 237);
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
            frmStudentRegistration.name = fullname;
            frmStudentRegistration.accounttype = accountType;
            frmStudentRegistration.Show();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridFullStudent.Rows.Count == 0)
                {
                    MessageBox.Show("No Data found!", "Edit Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                        frmStudentRegistration.loadStudData(dataGridFullStudent.CurrentRow.Cells["StudentID"].FormattedValue.ToString());
                        frmStudentRegistration.studentNumberFromAdmin = dataGridFullStudent.CurrentRow.Cells["StudentID"].FormattedValue.ToString();
                    frmStudentRegistration.name = fullname;
                    frmStudentRegistration.accounttype = accountType;
                    frmStudentRegistration.btnEdit.Visible = false;
                    frmStudentRegistration.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Details: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                MessageBox.Show("Please include what data to search", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Please include what data to search", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                DataGridArchive.AllowUserToResizeRows = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot load data. Error Message: " + ex.Message, "Error Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            folderArcback = false;
            enableComponents(true);
            loadArchiveStudentData();
            Archive.BringToFront();
        }

        private void btnArchiveBack_Click(object sender, EventArgs e)
        {
            if(folderArcback)
            {
                StudentTab.BringToFront();
            }
            else
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
              
                frmStudentRegistration.loadStudData(DataGridArchive.CurrentRow.Cells["StudentID"].FormattedValue.ToString());
                frmStudentRegistration.studentNumberFromAdmin = DataGridArchive.CurrentRow.Cells["StudentID"].FormattedValue.ToString();
                frmStudentRegistration.name = fullname;
                frmStudentRegistration.accounttype = accountType;
                frmStudentRegistration.btnEdit.Visible = false;
                frmStudentRegistration.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data found!", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        bool folderArcback;
        private void btnFolder_Click(object sender, EventArgs e)
        {
            folderArcback = true;
            if (accountType.Equals("Student Assistant"))
            {
                btnEditArc.Visible = false;
                
            }

            Archive.BringToFront();
            loadArchiveStudentData();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            Logs.BringToFront();
            loadLogs();
        }

        private void btnLogsBack_Click(object sender, EventArgs e)
        {
            Admin_Control.BringToFront();
        }
        private void clearTextAccount()
        {
            txtCreateAccName.Clear();
            txtCreateAccUsername.Clear();
            txtCreateAccPass.Clear();
            txtCreateAccSecPass.Clear();
            cmbCreateAccType.Text = "";
        }
        private void loadLogs()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            var bindingSource = new BindingSource();
            string ShowInfo = "SELECT Name, AccountType, LogLevel, LogMessage, LoginTime from tblLogs ORDER BY LoginTime desc";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(ShowInfo, connection);
            try
            {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                bindingSource.DataSource = table;
                dataGridLogs.ReadOnly = true;
                dataGridLogs.DataSource = bindingSource;
                dataGridLogs.RowHeadersVisible = false;
                dataGridLogs.AllowUserToResizeRows = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot load data. Error Message: " + ex.Message, "Error Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportStudentData();

        }
        private void exportStudentData()
        {
            if (dataGridStudentFullData.Rows.Count == 0)
            {
                MessageBox.Show("No Data found!", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = false;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;

                    for (int i = 1; i < dataGridStudentFullData.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dataGridStudentFullData.Columns[i - 1].HeaderText;
                    }
                    //for (int i = 0; i < dataGridStudentFullData.Rows.Count - 1; i++)
                    for (int i = 0; i < dataGridStudentFullData.Rows.Count + 0; i++)
                    {
                        for (int j = 0; j < dataGridStudentFullData.Columns.Count; j++)
                        {
                            if (dataGridStudentFullData.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridStudentFullData.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }
                    worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

                    var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = "Student Data Reports " + DateTime.Now.ToString("MMMM-dd-yyyy HH-mm");
                    saveFileDialog.DefaultExt = ".xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Details: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnExportStudent_Click(object sender, EventArgs e)
        {
            exportStudentData();
        }

        private void studentDataGrid()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlquery = "select tblStudent.StudentID, tblStudent.LRN, tblStudent.FirstName, tblStudent.MiddleName, tblStudent.LastName, tblStudent.Suffix, tblStudent.Gender, tblStudent.Birthdate, tblStudent.Birthplace, tblStudent.CivilStatus, tblStudent.Citizenship, tblStudent.StreetNo, tblStudent.Street, tblStudent.Subdivision, tblStudent.Barangay, tblStudent.City, tblStudent.Province, tblStudent.ZipCode, tblStudent.EmailAdd, tblStudent.ContactNo, tblStudent.ContactNo, tblParentGuardianTable.FathersName, tblParentGuardianTable.FathersOccupation, tblParentGuardianTable.FathersContactNum, tblParentGuardianTable.MotherName, tblParentGuardianTable.MotherOccupation, tblParentGuardianTable.MothersContactNum, tblParentGuardianTable.GuardiansName, tblParentGuardianTable.GuardiansOccupation, tblParentGuardianTable.GuardiansContactNum, tblParentGuardianTable.GuardiansRelationship, tblEducation.SchoolType, tblEducation.SchoolName, tblEducation.Program, tblEducation.Grade, tblEducation.GradudationDate, tblEducation.ChosenCourse, tblRegistrationInfo.Remarks, tblRegistrationInfo.Status, tblRegistrationInfo.DateTime as 'Last Modified Date' from [dbo].[tblStudent] inner join [dbo].[tblParentGuardianTable]";
            sqlquery += "on tblStudent.StudentID = tblParentGuardianTable.StudentID inner join [dbo].[tblEducation] on tblParentGuardianTable.StudentID=tblEducation.StudentID INNER JOIN [dbo].[tblRegistrationInfo] on tblEducation.StudentID=tblRegistrationInfo.StudentID WHERE tblRegistrationInfo.Status = 'Enrolled' OR tblRegistrationInfo.Status = 'Registered'";
            SqlCommand com = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridStudentFullData.DataSource = dt;
            con.Close();
        }



        private void dataGridFullStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dataGridFullStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
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
                        frmStudent.loadStudData(dataGridFullStudent.Rows[e.RowIndex].Cells["StudentID"].FormattedValue.ToString());
                        frmStudent.studentNumberFromAdmin = dataGridFullStudent.Rows[e.RowIndex].Cells["StudentID"].FormattedValue.ToString();
                        frmStudent.name = fullname;
                        frmStudent.accounttype = accountType;
                        frmStudent.Show();
                    }
                }
            }

            catch (NullReferenceException ex)
            {
                MessageBox.Show("No Data Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Details: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogoutNo_Click(object sender, EventArgs e)
        {
            LogoutDialogBox.SendToBack();
        }

        private void btnLogoutYes_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            EnableContentAddAccountPanel(pnlCreateAccountComponents, true);
            clearTextAccount();
            pnlCreateAccount.BringToFront();
        }

        private void txtCreateAccName_KeyPress(object sender, KeyPressEventArgs e)
        {

            txtCreateAccName.MaxLength = 100;
        }

        private void btnExportLogs_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = false;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                for (int i = 1; i < dataGridLogs.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridLogs.Columns[i - 1].HeaderText;
                }
                
                for (int i = 0; i < dataGridLogs.Rows.Count + 0; i++)
                {
                    for (int j = 0; j < dataGridLogs.Columns.Count; j++)
                    {
                        if (dataGridLogs.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridLogs.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = "";
                        }
                    }
                }
                worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "System Logs Reports " + DateTime.Now.ToString("MMMM-dd-yyyy HH-mm");
                saveFileDialog.DefaultExt = ".xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Details: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridSimpleStudentInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                        frmStudent.name = fullname;
                        frmStudent.accounttype = accountType;
                        frmStudent.Show();
                    }
                }
            }

            catch (NullReferenceException ex)
            {
                MessageBox.Show("No Data Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnControlPanel_Click(object sender, EventArgs e)
        {
             Admin_Control.BringToFront();
            btnControlPanel.ButtonColor = Color.FromArgb(192, 229, 237);
            btnControlPanel.BorderColor = Color.FromArgb(192, 229, 237);
            btnDashboard.ButtonColor = Color.FromArgb(4, 45, 101);
            btnDashboard.BorderColor = Color.FromArgb(4, 45, 101);
            buttonStudents.ButtonColor = Color.FromArgb(4, 45, 101);
            buttonStudents.BorderColor = Color.FromArgb(4, 45, 101);
        }

        private void txtCreateAccUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}
