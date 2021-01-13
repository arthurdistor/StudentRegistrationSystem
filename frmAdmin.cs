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

namespace TestStudentRegistration
{
    public partial class frmAdmin : Form
    {
        public static string activeUser;
        public frmAdmin(string username)
        {
            InitializeComponent();
            lblGreetings.Text = username;
            activeUser = username;
            loadData();
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
        private void loadData()
        {
            SqlCommand cmd;
            string totalStud = "SELECT COUNT(StudentID)FROM tblStudent;";
            string totalNewStud = "SELECT COUNT(StudentID)FROM tblStudent WHERE admissionType = 'New';";
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeDate.Text = DateTime.Now.ToString("dddd , MMM dd yyyy " + Environment.NewLine + "hh:mm:ss");
        }
    }
}
