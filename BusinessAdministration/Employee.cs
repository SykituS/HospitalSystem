using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdministration
{
    public class Employee
    {
        private int id;
        private string name;
        private string surname;
        private string email;
        private string pesel;
        private string dateOfBirth;
        private string address;
        private string position;
        private string phoneNumber;
        private string sex;

        public Employee(int id, string name, string surname, string email, string pesel, string dateOfBirth, string address, string position, string phoneNumber, string sex)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.pesel = pesel;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
            this.position = position;
            this.phoneNumber = phoneNumber;
            this.sex = sex;
        }

        public static int LastId()
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT TOP 1 EM_Id_Employee FROM dbo.Employee ORDER BY EM_Id_Employee DESC";
            SqlCommand query = new SqlCommand(cmd);

            DBSystem.DBSystem.SelectFromDB(dt, query);

            int id = (int)dt.Rows[0][0] + 1;

            return id;
        }

        public void InsertEmployeeToDb()
        {
            string cmd = "INSERT INTO dbo.Employee VALUES (@Id, @Name, @Surname, @Email, @Pesel, @DoB, @Address, @Role, @Phone, @Sex, 1)";
            SqlCommand query = new SqlCommand(cmd);

            query.Parameters.AddWithValue("@Id", id);
            query.Parameters.AddWithValue("@Name", name);
            query.Parameters.AddWithValue("@Surname", surname);
            query.Parameters.AddWithValue("@Email", email);
            query.Parameters.AddWithValue("@Pesel", pesel);
            query.Parameters.AddWithValue("@DoB", dateOfBirth);
            query.Parameters.AddWithValue("@Address", address);
            query.Parameters.AddWithValue("@Role", position);
            query.Parameters.AddWithValue("@Phone", phoneNumber);
            query.Parameters.AddWithValue("@Sex", sex);

            DBSystem.DBSystem.InsertToDB(query);
        }

        public void UpdateEmployeeToDb()
        {
            string cmd = "UPDATE dbo.Employee SET EM_Name = @Name, EM_Surname = @Surname, EM_Email = @Email, EM_Pesel = @Pesel, EM_Date_of_birth = @Dob, EM_Correspondence_address = @Address, EM_Position = @Role, EM_Phone_number = @Phone, EM_Id_Sex = @Sex WHERE EM_Id_Employee = @Id";
            SqlCommand query = new SqlCommand(cmd);

            query.Parameters.AddWithValue("@Id", id);
            query.Parameters.AddWithValue("@Name", name);
            query.Parameters.AddWithValue("@Surname", surname);
            query.Parameters.AddWithValue("@Email", email);
            query.Parameters.AddWithValue("@Pesel", pesel);
            query.Parameters.AddWithValue("@DoB", dateOfBirth);
            query.Parameters.AddWithValue("@Address", address);
            query.Parameters.AddWithValue("@Role", position);
            query.Parameters.AddWithValue("@Phone", phoneNumber);
            query.Parameters.AddWithValue("@Sex", sex);

            DBSystem.DBSystem.UpdateDB(query);
        }
    }
}
