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
    public partial class frmStudentRegistration : Form
    {
        string connectionString = @"Server=DESKTOP-8SJ75OR\SQLEXPRESS;Database=DBStudentRegistrationSystem;Trusted_Connection=True;";
        public frmStudentRegistration()
        {
            InitializeComponent();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void disableComponents()
        {
            
                Action<Control.ControlCollection> func = null;

                func = (controls) =>
                {
                    foreach (Control control in controls)
                    {

                        if (control is TextBox)
                            (control as TextBox).Enabled = false;

                        if (control is ComboBox)
                            (control as ComboBox).Enabled = false;
                        if(control is DateTimePicker)
                            (control as DateTimePicker).Enabled = false;
                        else
                            func(control.Controls);
                    }

                };

                func(Controls);
       
        }
        private void enableComponents()
        {

            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {

                    if (control is TextBox)
                        (control as TextBox).Enabled = true;

                    if (control is ComboBox)
                        (control as ComboBox).Enabled = true;
                    if (control is DateTimePicker)
                        (control as DateTimePicker).Enabled = true;
                    else
                        func(control.Controls);
                }

            };

            func(Controls);
           
        }
        public void loadStudData(string studNum)
        {
            
            string query = "  SELECT * FROM tblStudent S RIGHT JOIN tblEducation E ON S.StudentID = E.StudentID RIGHT JOIN tblParentGuardianTable P ON S.StudentID = P.StudentID WHERE S.StudentID =" + studNum;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader myReader = command.ExecuteReader();
            
            while (myReader.Read())
            {
                txtLRN.Text = myReader[1].ToString();
                txtStudFirstName.Text = myReader[2].ToString();
                txtStudMiddleName.Text = myReader[3].ToString();
                txtStudLastName.Text = myReader[4].ToString();
                txtStudSuffix.Text = myReader[5].ToString();
                comboGender.Text = myReader[6].ToString();
                dateOfBirth.Text = myReader[7].ToString();
                txtStudBirthdPlace.Text = myReader[8].ToString();
                txtStudStatus.Text = myReader[9].ToString();
                txtStudCitizenship.Text = myReader[10].ToString();
                txtStreetNum.Text = myReader[11].ToString();
                txtStreet.Text = myReader[12].ToString();
                txtSubdivision.Text = myReader[13].ToString();
                txtBarangay.Text = myReader[14].ToString();
                txtCity.Text = myReader[15].ToString();
                txtProvince.Text = myReader[16].ToString();
                txtZipCode.Text = myReader[17].ToString();
                txtEmail.Text = myReader[18].ToString();
                txtStudContactNum.Text = myReader[19].ToString();
                //20 Stud timestamp
                comboAdmissionType.Text = myReader[21].ToString();
                //22education ID 23 studID
                comboSchoolType.Text = myReader[24].ToString();
                txtSchoolName.Text = myReader[25].ToString();
                txtProgram.Text = myReader[26].ToString();
                txtYear.Text = myReader[27].ToString();
                txtDateOfGraduation.Text = myReader[28].ToString();
                //27 ParentID, 28 studID
                txtFathersName.Text = myReader[31].ToString();
                txtFatherOccupation.Text  = myReader[32].ToString();
                txtFatherContact.Text = myReader[33].ToString();
                txtMotherName.Text = myReader[34].ToString();
                txtMotherOccupation.Text = myReader[35].ToString();
                txtMotherContact.Text = myReader[36].ToString();
                txtGuardianName.Text = myReader[37].ToString();
                txtGuardianOccupation.Text = myReader[38].ToString();
                txtGuardianContact.Text = myReader[39].ToString();
                txtRelationship.Text = myReader[40].ToString();

            }
            connection.Close();
        }

     

        private void btnEdit_Click(object sender, EventArgs e)
        {
        
            enableComponents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            disableComponents();
        }
    }
}
