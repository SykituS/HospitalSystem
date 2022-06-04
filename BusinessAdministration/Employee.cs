using System.Data.SqlClient;

namespace BusinessAdministration
{
    public class Employee
    {
        private string name;
        private string surname;
        private string email;
        private string pesel;
        private string dateOfBirth;
        private string address;
        private byte position;
        private string phoneNumber;
        private byte sex;
        private string secName;
        private int status;

        public Employee(string name, string surname, string email, string pesel, string dateOfBirth, string address, byte position, string phoneNumber, byte sex, string secName)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.pesel = pesel;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
            this.position = position;
            this.phoneNumber = phoneNumber;
            this.sex = sex;
            this.secName = secName;
        }

        public Employee(int status)
        {
            this.status = status;
        }

        public void InsertEmployeeToDb()
        {
            string query = "INSERT INTO Employee VALUES (NEXT VALUE FOR Seq_Employee, @Name, @Surname, @Email, @Pesel, @DoB, @Address, @Role, @Phone, @Sex, 1, @SecName)";
            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Surname", surname);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Pesel", pesel);
            cmd.Parameters.AddWithValue("@DoB", dateOfBirth);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Role", position);
            cmd.Parameters.AddWithValue("@Phone", phoneNumber);
            cmd.Parameters.AddWithValue("@Sex", sex);
            cmd.Parameters.AddWithValue("@SecName", secName);

            DBSystem.DBSystem.InsertToDB(cmd);
        }

        public void UpdateEmployeeToDb(int id)
        {
            string query = "UPDATE dbo.Employee SET EM_Name = @Name, EM_Surname = @Surname, EM_Email = @Email, EM_Pesel = @Pesel, EM_Date_of_birth = @Dob, EM_Correspondence_address = @Address, EM_Position = @Role, EM_Phone_number = @Phone, EM_Id_Sex = @Sex, EM_Sec_Name = @SecName WHERE EM_Id_Employee = @Id";
            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Surname", surname);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Pesel", pesel);
            cmd.Parameters.AddWithValue("@DoB", dateOfBirth);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Role", position);
            cmd.Parameters.AddWithValue("@Phone", phoneNumber);
            cmd.Parameters.AddWithValue("@Sex", sex);
            cmd.Parameters.AddWithValue("@SecName", secName);

            DBSystem.DBSystem.UpdateDB(cmd);
        }

        public void UpdateStatusEmplyeeToDb(int id)
        {
            string query = "UPDATE dbo.Employee SET EM_Id_Status = @Status WHERE EM_Id_Employee = @Id";
            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Status", status);

            DBSystem.DBSystem.UpdateDB(cmd);
        }
    }
}
