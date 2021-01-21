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
        //string connectionString = @"Data Source=desktop-40uhahe\mssqlserver01;Initial Catalog=DBStudentRegistrationSystem;Integrated Security=True";
        private string studNumber;
        private string customID = "";
        private string finalStudID = "";




        public frmStudentRegistration()
        {
            InitializeComponent();



        }

        public void timeStamp()
        {
            //timer1.Start();
            //lblTimestamp.Text = DateTime.Today.ToShortDateString() + " " +  DateTime.Now.ToShortTimeString();
            //lblTimestamp.Text = DateTime.Now.ToShortDateString();
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
                    if (control is DateTimePicker)
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
                txtFathersName.Text = myReader[32].ToString();
                txtFatherOccupation.Text = myReader[33].ToString();
                txtFatherContact.Text = myReader[34].ToString();
                txtMotherName.Text = myReader[35].ToString();
                txtMotherOccupation.Text = myReader[36].ToString();
                txtMotherContact.Text = myReader[37].ToString();
                txtGuardianName.Text = myReader[38].ToString();
                txtGuardianOccupation.Text = myReader[39].ToString();
                txtGuardianContact.Text = myReader[40].ToString();
                txtRelationship.Text = myReader[41].ToString();

            }
            connection.Close();
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {

            enableComponents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {



            string studentIDExistQuery = "SELECT studentID FROM tblStudent WHERE StudentID ='" + studNumber + "';" ;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(studentIDExistQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //Update student info  
                dr.Close();
                UpdateStudentInfo();
            }
            else
            {
                //Insert new student
                generateStudentID1();
            }


        }

        public void insertToTblStudent()
        {


            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {

                    //string q = "Insert into tblStudent(StudentID, LRN, FirstName, MiddleName, LastName, Suffix, Gender, Birthdate, Birthplace, CivilStatus, Citizenship,  StreetNo, Street, Subdivision, Barangay, City, Province, ZipCode,  EmailAdd, ContactNo, timestamp, admissionType) values ('" + tbStudID.Text.ToString() + "','" + txtLRN.Text.ToString() + "','" + txtStudFirstName.Text.ToString() + "','" + txtStudMiddleName.Text.ToString() + "','" + txtStudLastName.Text.ToString() + "','" + txtStudSuffix.Text.ToString() + "','" + comboGender.Text.ToString() + "','" + dateOfBirth.Value.Date.ToString("yyyyMMdd") + "','" + txtStudBirthdPlace.Text.ToString() + "','" + txtStudStatus.Text.ToString() + "','" + txtStudCitizenship.Text.ToString() + "','" + txtStreetNum.Text.ToString() + "','" + txtStreet.Text.ToString() + "','" + txtSubdivision.Text.ToString() + "','" + txtBarangay.Text.ToString() + "','" + txtCity.Text.ToString() + "','" + txtProvince.Text.ToString() + "','" + txtZipCode.Text.ToString() + "','" + txtEmail.Text.ToString() + "','" + txtStudContactNum.Text.ToString() + "','" + DateTime.Now.ToString() + "','" + comboAdmissionType.Text.ToString() + "')";
                    //string q = "Insert into tblStudent(LRN, FirstName, MiddleName, LastName, Suffix, Gender, Birthdate, Birthplace, CivilStatus, Citizenship,  StreetNo, Street, Subdivision, Barangay, City, Province, ZipCode,  EmailAdd, ContactNo, admissionType) values ('" + txtLRN.Text.ToString() + "','" + txtStudFirstName.Text.ToString() + "','" + txtStudMiddleName.Text.ToString() + "','" + txtStudLastName.Text.ToString() + "','" + txtStudSuffix.Text.ToString() + "','" + comboGender.Text.ToString() + "','" + dateOfBirth.Value.Date.ToString("yyyyMMdd") + "','" + txtStudBirthdPlace.Text.ToString() + "','" + txtStudStatus.Text.ToString() + "','" + txtStudCitizenship.Text.ToString() + "','" + txtStreetNum.Text.ToString() + "','" + txtStreet.Text.ToString() + "','" + txtSubdivision.Text.ToString() + "','" + txtBarangay.Text.ToString() + "','" + txtCity.Text.ToString() + "','" + txtProvince.Text.ToString() + "','" + txtZipCode.Text.ToString() + "','" + txtEmail.Text.ToString() + "','" + txtStudContactNum.Text.ToString() + "','" + comboAdmissionType.Text.ToString() + "')";
                    string q = "Insert into tblStudent(StudentID, LRN, FirstName, MiddleName, LastName, Suffix, Gender, Birthdate, Birthplace, CivilStatus, Citizenship,  StreetNo, Street, Subdivision, Barangay, City, Province, ZipCode,  EmailAdd, ContactNo, timestamp, admissionType) values ('" + finalStudID + "','" + txtLRN.Text.ToString() + "','" + txtStudFirstName.Text.ToString() + "','" + txtStudMiddleName.Text.ToString() + "','" + txtStudLastName.Text.ToString() + "','" + txtStudSuffix.Text.ToString() + "','" + comboGender.Text.ToString() + "','" + dateOfBirth.Value.Date.ToString("yyyyMMdd") + "','" + txtStudBirthdPlace.Text.ToString() + "','" + txtStudStatus.Text.ToString() + "','" + txtStudCitizenship.Text.ToString() + "','" + txtStreetNum.Text.ToString() + "','" + txtStreet.Text.ToString() + "','" + txtSubdivision.Text.ToString() + "','" + txtBarangay.Text.ToString() + "','" + txtCity.Text.ToString() + "','" + txtProvince.Text.ToString() + "','" + txtZipCode.Text.ToString() + "','" + txtEmail.Text.ToString() + "','" + txtStudContactNum.Text.ToString() + "','" + DateTime.Now + "','" + comboAdmissionType.Text.ToString() + "')";

                    SqlCommand cmd = new SqlCommand(q, con);

                    cmd.ExecuteNonQuery();

                    
                    insertToTblParentGuardian();
                    insertToTblEducation();

                    txtLRN.Text = "";
                    txtStudFirstName.Text = "";
                    txtStudMiddleName.Text = "";
                    txtStudLastName.Text = "";
                    txtStudSuffix.Text = "";
                    comboGender.Text = "";
                    dateOfBirth.Text = "";
                    txtStudBirthdPlace.Text = "";
                    txtStudStatus.Text = "";
                    txtStudCitizenship.Text = "";
                    txtStreetNum.Text = "";
                    txtStreet.Text = "";
                    txtSubdivision.Text = "";
                    txtBarangay.Text = "";
                    txtCity.Text = "";
                    txtProvince.Text = "";
                    txtZipCode.Text = "";
                    txtEmail.Text = "";
                    txtStudContactNum.Text = "";
                    //20 Stud timestamp
                    comboAdmissionType.Text = "";
                    //22education ID 23 studID
                    comboSchoolType.Text = "";
                    txtSchoolName.Text = "";
                    txtProgram.Text = "";
                    txtYear.Text = "";
                    txtDateOfGraduation.Text = "";
                    //27 ParentID, 28 studID
                    txtFathersName.Text = "";
                    txtFatherOccupation.Text = "";
                    txtFatherContact.Text = "";
                    txtMotherName.Text = "";
                    txtMotherOccupation.Text = "";
                    txtMotherContact.Text = "";
                    txtGuardianName.Text = "";
                    txtGuardianOccupation.Text = "";
                    txtGuardianContact.Text = "";
                    txtRelationship.Text = "";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void insertToTblEducation()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "Insert into tblEducation(StudentID, SchoolType, SchoolName, Program, Grade, GradudationDate, ChosenCourse) values ('" + finalStudID + "','" + comboSchoolType.Text.ToString() + "','" + txtSchoolName.Text.ToString() + "','" + txtProgram.Text.ToString() + "','" + txtYear.Text.ToString() + "','" + txtDateOfGraduation.Text.ToString() + "','" + comboCourse.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(q, con);

                    cmd.ExecuteNonQuery();

                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void insertToTblParentGuardian()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "Insert into tblParentGuardianTable(StudentID, FathersName, FathersOccupation, FathersContactNum, MotherName, MotherOccupation, MothersContactNum, GuardiansName, GuardiansOccupation, GuardiansContactNum, GuardiansRelationship ) values ('" + finalStudID + "','" + txtFathersName.Text.ToString() + "','" + txtFatherOccupation.Text.ToString() + "','" + txtFatherContact.Text.ToString() + "','" + txtMotherName.Text.ToString() + "','" + txtMotherOccupation.Text.ToString() + "','" + txtMotherContact.Text.ToString() + "','" + txtGuardianName.Text.ToString() + "','" + txtGuardianOccupation.Text.ToString() + "','" + txtGuardianContact.Text.ToString() + "','" + txtRelationship.Text.ToString() + "')";
                    //string q = "Insert into tblParentGuardian(StudentID, FathersName, FathersOccupation, FathersContactNum, MotherName, MotherOccupation, MothersContactNum, GuardiansName, GuardiansOccupation, GuardiansContactNum, GuardiansRelationship ) values ('" + finalStudID  + "','" + txtFathersName.Text.ToString() + "','" + txtFatherOccupation.Text.ToString() + "','" + txtFatherContact.Text.ToString() + "','" + txtMotherName.Text.ToString() + "','" + txtMotherOccupation.Text.ToString() + "','" + txtMotherContact.Text.ToString() + "','" + txtGuardianName.Text.ToString() + "','" + txtGuardianOccupation.Text.ToString() + "','" + txtGuardianContact.Text.ToString() + "','" + txtRelationship.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(q, con);

                    cmd.ExecuteNonQuery();

                   
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void UpdateStudentInfo()
        {
            string updateQuery =
            @"UPDATE tblStudent
            SET 
            tblStudent.FirstName = @FirstName
            tblStudent.MiddleName = @MiddleName
            tblStudent.LastName = @LastName
            tblStudent.Suffix = @Suffix
            tblStudent.Gender = @Gender
            tblStudent.Birthdate = @Birthdate
            tblStudent.Birthplace = @Birthplace
            tblStudent.CivilStatus = @CivilStatus
            tblStudent.Citizenship = @Citizenship
            tblStudent.StreetNo = @StreetNo
            tblStudent.Street = @Street
            tblStudent.Subdivision = @Subdivision
            tblStudent.Barangay = @Barangay
            tblStudent.City = @City
            tblStudent.Province = @Province
            tblStudent.ZipCode = @ZipCode
            tblStudent.EmailAdd = @EmailAdd
            tblStudent.ContactNo = @ContactNo
            tblStudent.admissionType = @admissionType


            tblEducation.SchoolType = @SchoolType            
            tblEducation.SchoolName = @SchoolName            
            tblEducation.Program = @Program            
            tblEducation.Grade = @Grade
            tblEducation.GradudationDate = @GradudationDate            
            tblEducation.ChosenCourse = @ChosenCourse            


            tblParentGuardianTable.FathersName = @FathersName
            tblParentGuardianTable.FathersOccupation = @FathersOccupation
            tblParentGuardianTable.FathersContactNum = @FathersContactNum
            tblParentGuardianTable.MotherName = @MotherName
            tblParentGuardianTable.MotherOccupation = @MotherOccupation
            tblParentGuardianTable.MothersContactNum = @MothersContactNum
            tblParentGuardianTable.GuardiansName = @GuardiansName
            tblParentGuardianTable.GuardiansOccupation = @GuardiansOccupation
            tblParentGuardianTable.GuardiansContactNum = @GuardiansContactNum
            tblParentGuardianTable.GuardiansRelationship = @GuardiansRelationship
        
        
        
           FROM tblStudent
                LEFT JOIN tblEducation
                ON tblStudent.StudentID = tblEducation.StudentID
                LEFT JOIN tblParentGuardianTable
                ON tblEducation.StudentID = tblParentGuardianTable.StudentID
            WHERE tblStudent.StudentID = @studentID;
            ";

            disableComponents();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(updateQuery, connection);
            connection.Open();
            command.Parameters.AddWithValue("@FirstName", txtStudFirstName.Text);
            command.Parameters.AddWithValue("@MiddleName", txtStudMiddleName.Text);
            command.Parameters.AddWithValue("@LastName", txtStudLastName.Text);
            command.Parameters.AddWithValue("@Suffix", txtStudSuffix.Text);
            command.Parameters.AddWithValue("@Gender", comboGender.Text);
            command.Parameters.AddWithValue("@Birthdate", dateOfBirth.Text);
            command.Parameters.AddWithValue("@Birthplace", txtStudBirthdPlace.Text);
            command.Parameters.AddWithValue("@CivilStatus", txtStudStatus.Text);
            command.Parameters.AddWithValue("@Citizenship", txtStudCitizenship.Text);
            command.Parameters.AddWithValue("@StreetNo", txtStreetNum.Text);
            command.Parameters.AddWithValue("@Street", txtStreet.Text);
            command.Parameters.AddWithValue("@Subdivision", txtSubdivision.Text);
            command.Parameters.AddWithValue("@Barangay", txtBarangay.Text);
            command.Parameters.AddWithValue("@City", txtCity.Text);
            command.Parameters.AddWithValue("@Province", txtProvince.Text);
            command.Parameters.AddWithValue("@ZipCode", txtZipCode.Text);
            command.Parameters.AddWithValue("@EmailAdd", txtEmail.Text);
            command.Parameters.AddWithValue("@ContactNo", txtStudContactNum.Text);
            command.Parameters.AddWithValue("@admissionType", comboAdmissionType.Text);

            command.Parameters.AddWithValue("@SchoolType", comboSchoolType.Text);
            command.Parameters.AddWithValue("@SchoolName", txtSchoolName.Text);
            command.Parameters.AddWithValue("@Program", txtProgram.Text);
            command.Parameters.AddWithValue("@Grade", txtYear.Text);
            command.Parameters.AddWithValue("@GradudationDate", txtDateOfGraduation.Text);
            command.Parameters.AddWithValue("@ChosenCourse", comboCourse.Text);

            command.Parameters.AddWithValue("@FathersName", txtFathersName.Text);
            command.Parameters.AddWithValue("@FathersOccupation", txtFatherOccupation.Text);
            command.Parameters.AddWithValue("@FathersContactNum", txtFatherContact.Text);
            command.Parameters.AddWithValue("@MotherName", txtMotherName.Text);
            command.Parameters.AddWithValue("@MotherOccupation", txtMotherOccupation.Text);
            command.Parameters.AddWithValue("@MothersContactNum", txtMotherContact.Text);
            command.Parameters.AddWithValue("@GuardiansName", txtGuardianName.Text);
            command.Parameters.AddWithValue("@GuardiansOccupation", txtGuardianOccupation.Text);
            command.Parameters.AddWithValue("@GuardiansContactNum", txtGuardianContact.Text);
            command.Parameters.AddWithValue("@GuardiansRelationship", txtRelationship.Text);

            //Kopyahin mo lang nasa taas tapos naka label naman na yung mga yan kung @Firstname, susundan mo ng component niya, txtStudFirstName.Text

            command.ExecuteNonQuery();
            connection.Close();


        }

        private void generateStudentID1()
        {
            SqlConnection con = new SqlConnection(connectionString);

            //string customID = "";
            //string finalStudID = "";
            DateTime dateTime = DateTime.Now;
            customID = dateTime.ToString("yyyyMM");

            SqlCommand cmd = new SqlCommand("SELECT COUNT(studentID) as numrows FROM tblStudent;", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (!dr.HasRows || dr.IsDBNull(0))
            {
                finalStudID = customID + "00001";
            }
            else
            {
                int newID = Convert.ToInt32(dr.GetInt32(0));
                newID++;
                finalStudID = customID + newID.ToString("00000");
            }
            con.Close();

            insertStudData();
            // insertToTblStudent();
            //insertToTblParentGuardian();
            // insertToTblEducation();
        }
        public void insertStudData()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into tblStudent(StudentID, LRN, FirstName, MiddleName, LastName, Suffix, Gender, Birthdate, Birthplace, CivilStatus, Citizenship, StreetNo, Street, Subdivision, Barangay, City, Province, ZipCode, EmailAdd, ContactNo, admissionType) values(@StudentID,@LRN,@FirstName,@MiddleName,@LastName,@Suffix,@Gender,@Birthdate,@Birthplace,@CivilStatus,@Citizenship,@StreetNo,@Street,@Subdivision,@Barangay,@City,@Province,@ZipCode,@EmailAdd,@ContactNo,@admissionType)", con);

                cmd.Parameters.AddWithValue("@StudentID", finalStudID);
                cmd.Parameters.AddWithValue("@LRN", txtLRN.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtStudFirstName.Text);
                cmd.Parameters.AddWithValue("@MiddleName", txtStudMiddleName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtStudLastName.Text);
                cmd.Parameters.AddWithValue("@Suffix", txtStudSuffix.Text);
                cmd.Parameters.AddWithValue("@Gender", comboGender.Text);
                cmd.Parameters.AddWithValue("@Birthdate", dateOfBirth.Value.Date.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@Birthplace", txtStudBirthdPlace.Text);
                cmd.Parameters.AddWithValue("@CivilStatus", txtStudStatus.Text);
                cmd.Parameters.AddWithValue("@Citizenship", txtStudCitizenship.Text);
                cmd.Parameters.AddWithValue("@StreetNo", txtStreetNum.Text);
                cmd.Parameters.AddWithValue("@Street", txtStreet.Text);
                cmd.Parameters.AddWithValue("@Subdivision", txtSubdivision.Text);
                cmd.Parameters.AddWithValue("@Barangay", txtBarangay.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
                cmd.Parameters.AddWithValue("@ZipCode", txtZipCode.Text);
                cmd.Parameters.AddWithValue("@EmailAdd", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ContactNo", txtStudContactNum.Text);
                //cmd.Parameters.AddWithValue("@timestamp", Convert.ToDateTime(lbl.Text);
                cmd.Parameters.AddWithValue("@admissionType", comboAdmissionType.Text);

                MessageBox.Show("Successfully Insert to tblStudent");

                insertToTblEducation();
                insertToTblParentGuardian();

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "gg");
            }
        }

        //public void generateEducationID()
        //{
        //    Class1 objs = new Class1();
        //    int b;
        //    objs.exe("select max(educationID) from tblEducation");
        //    if (objs.dr.Read())
        //    {
        //        if (objs.dr[0] != System.DBNull.Value)
        //        {
        //            b = Convert.ToInt32(objs.dr[0].ToString());
        //            tbEducationID.Text = (b + 1).ToString();
        //        }
        //        else
        //        {
        //            tbEducationID.Text = "1";
        //        }
        //    }
        //}

        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
            timeStamp();
            // tbStudID.Text = finalStudID;
            // generateParentID();
            // generateEducationID();
        }

        private void btnDeleteStudData_Click(object sender, EventArgs e)
        {

        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            //Class1 obj = new Class1();
            //int a;
            //obj.exe("select max(StudentID) from tblStudent");
            //if (obj.dr.Read())
            //{
            //    if (obj.dr[0] != System.DBNull.Value)
            //    {
            //        a = Convert.ToInt32(obj.dr[0].ToString());
            //        tbStudID.Text = (a + 1).ToString();
            //    }
            //    else
            //    {
            //        tbStudID.Text = "1";
            //    }
            //}

        }
    }
}
