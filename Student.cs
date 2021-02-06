using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStudentRegistration
{
    class Student
    {
        private string firstName; // field
        private string middleName; // field
        private string lastName; // field
        private string suffix; // field
        private string gender; // field
        private string dateOfBirth; // field
        private string birthPlace; // field
        private string civilStatus; // field
        private string citizenship; // field
        private string streetUnit; // field
        private string street; // field
        private string barangay; // field
        private string subdivisionVillage; // field
        private string cityMunicipality; // field
        private string province; // field
        private string zipcode; // field
        private string contactNumber; // field
        private string emailAddress; // field
        private string fatherFullname; // field
        private string fatherOccupation; // field
        private string fatherContactNumber; // field  
        private string motherFullname; // field
        private string motherOccupation; // field
        private string motherContactNumber; // field  
        private string guardianFullname; // field
        private string guardianOccupation; // field
        private string guardianContactNumber; // field     
        private string guardianRelationship; // field
        private string schoolType; // field
        private string referenceNumber; // field
        private string nameOfSchool; // field
        private string yearGrade; // field
        private string programTrack; // field
        private string yearGraduation; // field

        public DateTime getDateOfBirth()
        {

            var str = dateOfBirth;
            DateTime dt;
            var isValidDate = DateTime.TryParse(str, out dt);
            if (isValidDate)
            {
                Console.WriteLine(dt);
                string[] date = dateOfBirth.Split('/');
                return new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[0]), Convert.ToInt32(date[1]));
            }
            else
            {
                dt = DateTime.Now;
                Console.WriteLine($"{str} is not a valid date string");
                return dt;
            }

        }

        public static Student getStudentByAttachment(string[] lines)
        {
            Student attachStudent = new Student();

            foreach (string line in lines)
            {
                //MessageBox.Show(line);
                string[] word = line.Split(':');
                if (line.Contains("First Name:"))
                {
                    //if (!(String.IsNullOrEmpty(word[1]) || String.IsNullOrWhiteSpace(word[1])))
                    //{
                    attachStudent.FirstName = word[1];
                    //}
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Middle Name:"))
                {
                    attachStudent.MiddleName = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Last Name:"))
                {
                    attachStudent.LastName = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Gender:"))
                {
                    attachStudent.Gender = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Suffix:"))
                {
                    attachStudent.Suffix = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Date Of Birth:"))
                {
                    attachStudent.DateOfBirth = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Birthplace:"))
                {
                    attachStudent.BirthPlace = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Civil Status:"))
                {
                    attachStudent.CivilStatus = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Citizenship:"))
                {
                    attachStudent.Citizenship = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Street#/Unit#:"))
                {
                    attachStudent.streetUnit = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Street:"))
                {
                    attachStudent.Street = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Subdivision/Village:"))
                {
                    attachStudent.SubdivisionVillage = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Barangay:"))
                {
                    attachStudent.Barangay = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("City/Municipality:"))
                {
                    attachStudent.CityMunicipality = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Province:"))
                {
                    attachStudent.Province = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Zip Code:"))
                {
                    attachStudent.Zipcode = word[1];
                    //MessageBox.Show(word[1]);
                }
                //if (line.Contains("Contact Number:"))
                //{
                //    attachStudent.ContactNumber = word[1];
                //    //MessageBox.Show(word[1]);
                //} 
                if (line.Contains("Mobile Number:"))
                {
                    attachStudent.ContactNumber = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Email Address:"))
                {
                    attachStudent.EmailAddress = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Father's Full Name:"))
                {
                    attachStudent.FatherFullname = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Father's Occupation:"))
                {
                    attachStudent.FatherOccupation = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Father's Contact Number:"))
                {
                    attachStudent.FatherContactNumber = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Mother's Full Name:"))
                {
                    attachStudent.MotherFullname = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Mother's Occupation:"))
                {
                    attachStudent.MotherOccupation = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Mother's Contact Number:"))
                {
                    attachStudent.MotherContactNumber = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Guardian's Full Name:"))
                {
                    attachStudent.GuardianFullname = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Guardian's Occupation:"))
                {
                    attachStudent.GuardianOccupation = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Guardian's Contact Number:"))
                {
                    attachStudent.GuardianContactNumber = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Guardian's Relationship:"))
                {
                    attachStudent.GuardianRelationship = word[1];
                    //MessageBox.Show(word[1]);
                }  if (line.Contains("School Type:"))
                {
                    attachStudent.SchoolType = word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Learner's Reference Number:"))
                {
                    attachStudent.ReferenceNumber = word[1];
                    //MessageBox.Show(word[1]);
                } if (line.Contains("Name Of School:"))
                {
                    attachStudent.NameOfSchool= word[1];
                    //MessageBox.Show(word[1]);
                }
                if (line.Contains("Year/Grade:"))
                {
                    attachStudent.YearGrade = word[1];
                    //MessageBox.Show(word[1]);
                }if (line.Contains("Program/Track and Strand/Specialization:"))
                {
                    attachStudent.ProgramTrack = word[1];
                    //MessageBox.Show(word[1]);
                }if (line.Contains("Year Of Graduation:"))
                {
                    attachStudent.YearGraduation = word[1];
                    //MessageBox.Show(word[1]);
                }
            }
            return attachStudent;
        }

        public string FirstName   // property
        {
            get { return firstName; }   // get method
            set { firstName = value; }  // set method
        }

        public string MiddleName   // property
        {
            get { return middleName; }   // get method
            set { middleName = value; }  // set method
        }
        public string LastName   // property
        {
            get { return lastName; }   // get method
            set { lastName = value; }  // set method
        } public string Suffix   // property
        {
            get { return suffix; }   // get method
            set { suffix = value; }  // set method
        }

        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string BirthPlace { get => birthPlace; set => birthPlace = value; }
        public string CivilStatus { get => civilStatus; set => civilStatus = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public string StreetUnit { get => streetUnit; set => streetUnit = value; }
        public string Street { get => street; set => street = value; }
        public string Barangay { get => barangay; set => barangay = value; }
        public string CityMunicipality { get => cityMunicipality; set => cityMunicipality = value; }
        public string Province { get => province; set => province = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public string FatherFullname { get => fatherFullname; set => fatherFullname = value; }
        public string FatherOccupation { get => fatherOccupation; set => fatherOccupation = value; }
        public string FatherContactNumber { get => fatherContactNumber; set => fatherContactNumber = value; }
        public string MotherFullname { get => motherFullname; set => motherFullname = value; }
        public string MotherOccupation { get => motherOccupation; set => motherOccupation = value; }
        public string MotherContactNumber { get => motherContactNumber; set => motherContactNumber = value; }
        public string GuardianFullname { get => guardianFullname; set => guardianFullname = value; }
        public string GuardianOccupation { get => guardianOccupation; set => guardianOccupation = value; }
        public string GuardianContactNumber { get => guardianContactNumber; set => guardianContactNumber = value; }
        public string GuardianRelationship { get => guardianRelationship; set => guardianRelationship = value; }
        public string SchoolType { get => schoolType; set => schoolType = value; }
        public string ReferenceNumber { get => referenceNumber; set => referenceNumber = value; }
        public string NameOfSchool { get => nameOfSchool; set => nameOfSchool = value; }
        public string YearGrade { get => yearGrade; set => yearGrade = value; }
        public string ProgramTrack { get => programTrack; set => programTrack = value; }
        public string YearGraduation { get => yearGraduation; set => yearGraduation = value; }
        public string Gender { get => gender; set => gender = value; }
        public string SubdivisionVillage { get => subdivisionVillage; set => subdivisionVillage = value; }
    }
}
