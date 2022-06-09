using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Administration
{
    public class AddUser
    {
        public static DataTable dropdownlist()
        {


            DataTable dt = new DataTable();
            string query = " select EM_Id_Employee,CONCAT(EM_NAME, ' ', EM_Surname) AS Employees_Without_User from dbo.users right join dbo.employee on EM_Id_Employee = US_Employee WHERE US_Id_Users IS NULL";
            SqlCommand command = new SqlCommand(query);
            DBSystem.DBSystem.SelectFromDB(dt, command);
            return dt;
        }
       

        public static string LoginGenerator(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT CONCAT(LEFT(EM_NAME, 1), EM_Surname,  LEFT(EM_Pesel,2),  RIGHT(EM_Pesel,2)) AS User_Login FROM dbo.Employee WHERE EM_Id_Employee=@id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            DBSystem.DBSystem.SelectFromDB(dt, command);

            if (dt.Rows.Count == 0)
                return "";

            return (string)dt.Rows[0][0];
            
        }
        public static string GetEmail(int id)
        {

            DataTable dt = new DataTable();
            string query = "SELECT EM_Email FROM dbo.Employee WHERE EM_Id_Employee = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            DBSystem.DBSystem.SelectFromDB(dt, command);
            return (string)dt.Rows[0][0];

        }
       

        public static void AddNewUser(int id)
        {
            string password = Membership.GeneratePassword(12, 1);
            string login = LoginGenerator(id);
            string email = GetEmail(id);
            string query = "INSERT INTO Users (US_Id_Users, US_Login, US_Password, US_Employee, US_Status) VALUES(NEXT VALUE FOR Seq_Users, @login, @password, @id_employee, '2')";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", PasswordHashing.hashPassword(password));
            command.Parameters.AddWithValue("@id_employee", id);


            try
            {
                if (!EmailSendingClass.IsValidEmail(email))
                    return;

                EmailSendingClass.EmailSending(email, "Login data", Message(login, password));
                DBSystem.DBSystem.InsertToDB(command);
                ResetPassSys.ForcePasswordChange(login, 1);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error:" + ex);
            }
        }

        private static StringBuilder Message(string login, string password)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Hi, <br /> Here is your login and password: <br />");
            sb.Append("Login: " + login+ "<br />");
            sb.Append("Password: " + password + "<br />");
            sb.Append("Have a nice day, <br /> Medical clinic");

            return sb;
        }
    }
    }
