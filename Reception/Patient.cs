using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Reception
{
    public class Patient
    {
        
        private string name;
        private string surname;
        private string pesel;
        private byte sex;
        private string address;
        private DateTime dateOfBirth;
        private string email;
        private string phoneNumber;
        private int status;

        public Patient(string name, string surname, string pesel, byte sex, string email, string address, string phoneNumber, DateTime dateOfBirth)
        {
            
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
            this.address = address;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
            this.sex = sex;
            this.phoneNumber = phoneNumber;
            
        }

        public Patient(int status)
        {
            this.status = status;
        }
        public void AddPatientToDb()
        {
            string cmd = "INSERT INTO dbo.Patients(Name, Surname, Pesel, Sex, Date_of_birth, Correspondence_adress, Email, Phone_number, Active) VALUES(@Name, @Surname, @Pesel, @Sex, @DoB, @Address,@Email, @Phone, 1)";
            SqlCommand query = new SqlCommand(cmd);

            query.Parameters.AddWithValue("@Name", name);
            query.Parameters.AddWithValue("@Surname", surname);
            query.Parameters.AddWithValue("@Pesel", pesel);
            query.Parameters.AddWithValue("@Sex", sex);
            query.Parameters.AddWithValue("@Email", email);
            query.Parameters.AddWithValue("@DoB", dateOfBirth);
            query.Parameters.AddWithValue("@Address", address);
            query.Parameters.AddWithValue("@Phone", phoneNumber);
            
            DBSystem.DBSystem.InsertToDB(query);
            
        }

        public void UpdatePatientToDb(int id)
        {
            string cmd = "UPDATE Patients SET Name = @Name, Surname = @Surname, Pesel = @Pesel, Sex = @Sex, Date_of_birth = @DoB, Correspondence_adress = @Address, Email = @Email, Phone_number = @Phone WHERE Id_Patients = @Id_input";
            SqlCommand query = new SqlCommand(cmd);

            query.Parameters.AddWithValue("@Id_input", id);
            query.Parameters.AddWithValue("@Name", name);
            query.Parameters.AddWithValue("@Surname", surname);
            query.Parameters.AddWithValue("@Pesel", pesel);
            query.Parameters.AddWithValue("@Sex", sex);
            query.Parameters.AddWithValue("@Email", email);
            query.Parameters.AddWithValue("@DoB", dateOfBirth);
            query.Parameters.AddWithValue("@Address", address);
            query.Parameters.AddWithValue("@Phone", phoneNumber);

            DBSystem.DBSystem.UpdateDB(query);
        }

    

        public void UpdateStatusToDB(int id)
        {
            string cmd = "UPDATE dbo.Patients SET Active = @Status WHERE Id_Patients = @Id";
            SqlCommand query = new SqlCommand(cmd);

            query.Parameters.AddWithValue("@Id", id);
            query.Parameters.AddWithValue("@Status", status);

            DBSystem.DBSystem.UpdateDB(query);
        }

        public static void DeletePatientFromDB(int patientId)
        {
            // = PasswordHashing.hashPassword();
            /*string cmd = "";
            SqlCommand query = new SqlCommand(cmd);

            query.Parameters.AddWithValue("Id", patientId);
            DBSystem.DBSystem.DeleteFromDB(query);

            string cmd2 = "";
            SqlCommand query2 = new SqlCommand(cmd2);
            query.Parameters.AddWithValue("Id", patientId);
            DBSystem.DBSystem.DeleteFromDB(query2);*/
        }
        
        public static bool ValidateName(string name)
        {
            Regex regex = new Regex(@"^[\p{Lu}\p{Ll}][\p{Ll}]*(([,.] |[ '-])[\p{Lu}\p{Ll}][\p{Ll}]*)*(\.?)$");
            Match match = regex.Match(name);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateSurname(string surname)
        {
            Regex regex = new Regex(@"^[\p{Lu}\p{Ll}][\p{Ll}]*(([,.] |[ '-])[\p{Lu}\p{Ll}][\p{Ll}]*)*(\.?)$");
            Match match = regex.Match(surname);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
            Match match = regex.Match(email);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }

        public static bool ValidatePhoneNumber(string phonenumber)
        {
            Regex regex = new Regex(@"^([1-9]{1})[0-9]{8}$");
            Match match = regex.Match(phonenumber);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }

        public static bool ValidatePesel(string pesel, DateTime dateofbirth, byte sex)
        {
            string dayOfBirth, monthOfBirth;
            bool result = false;

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 }; //Weights of digits in pesel number

            


            List<int> peselDigits = new List<int>(); //List which contains all digits of given pesel number
            foreach (char digit in pesel)
            {
                if (char.IsDigit(digit))
                {
                    peselDigits.Add(Convert.ToInt32(digit.ToString()));
                }
                else
                {
                    return result;
                }
            }

            if (peselDigits.Count == 11)
            {
                dayOfBirth = dateofbirth.Day.ToString("00");
                monthOfBirth = dateofbirth.Month.ToString("00");

                string thirdAndFourthDigit;

                if (dateofbirth.Year >= 2000 && dateofbirth.Year < 2400) //assigning the month of birth which should be in a correct pesel number
                {

                    int digitOfHundreds = (dateofbirth.Year - 2000) / 100; //taking hundreds digit of the year of birth if its earlier than 2000
                    int addToMonth = 0;
                    switch (digitOfHundreds)
                    {
                        case 0:
                            addToMonth = 20;
                            break;
                        case 1:
                            addToMonth = 40;
                            break;
                        case 2:
                            addToMonth = 60;
                            break;
                        case 3:
                            addToMonth = 80;
                            break;

                    }
                    thirdAndFourthDigit = (Convert.ToInt32(monthOfBirth) + addToMonth).ToString();

                }
                else
                {
                    thirdAndFourthDigit = monthOfBirth;
                }

                string yearAsString = dateofbirth.Year.ToString();
                string firstTwoDigits = yearAsString[2].ToString() + yearAsString[3].ToString(); //first 2 digits that should be in a correct pesel number

                string year = peselDigits[0].ToString() + peselDigits[1].ToString(); //year which results from given pesel number
                string month = peselDigits[2].ToString() + peselDigits[3].ToString(); // month which results from given pesel number
                string day = peselDigits[4].ToString() + peselDigits[5].ToString(); // day of birth which results from given pesel number

                bool verifyYear = (firstTwoDigits == year);
                bool verifyMonth = (thirdAndFourthDigit == month);
                bool verifyDay = (dayOfBirth == day);
                bool verifyGenderIfMen = (peselDigits[9] % 2 == 1 && sex == 1);
                bool verifyGenderIfWomen = (peselDigits[9] % 2 == 0 && sex == 2);

                if (verifyYear && verifyMonth && verifyDay && (verifyGenderIfMen || verifyGenderIfWomen))
                {
                    int checksum = 0;
                    for (int i = 0; i <= weights.Length - 1; i++) //calculating checksum
                    {
                        checksum += peselDigits[i] * weights[i];
                    }
                    checksum %= 10;

                    if (checksum != 0)
                    {
                        checksum = 10 - checksum;
                    }

                    if (checksum.ToString() == peselDigits[10].ToString()) //checking if number control is equal calculated by program

                    {
                        result = true;
                    }
                }

            }
            return result;
        }
    }
}
