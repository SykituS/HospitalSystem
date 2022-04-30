using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration
{
    public class UserManagement
    {
        public static DataTable GetUsersFromDB()
        {
            DataTable dt = new DataTable();

            string query = "Select US_Login, EM_Name, EM_Sec_Name, PO_Name, St_Status_Name " +
                "FROM dbo.Employee INNER JOIN dbo.Users on US_Employee = EM_Id_Employee INNER JOIN dbo.Position on EM_Position = PO_Id_Position " +
                "INNER JOIN dbo.status on St_Id_Status = US_Status";
            SqlCommand command = new SqlCommand(query);
            DBSystem.DBSystem.SelectFromDB(dt, command);

            return dt;
        }

        public static DataTable GetPostionsFromDB()
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM dbo.Position";
            SqlCommand command = new SqlCommand(query);
            DBSystem.DBSystem.SelectFromDB(dt, command);

            return dt;
        }

        public static DataTable UpdateUserStatus(string login, string status)
        {
            string query = "UPDATE dbo.Users SET US_Status = @StatusID WHERE US_Login = @Login";
            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@Login", login);

            if (status == "Active")
                command.Parameters.AddWithValue("@StatusID", 2); //Change to inactive
            else
                command.Parameters.AddWithValue("@StatusID", 1); //Change to active

            DBSystem.DBSystem.UpdateDB(command);

            DataTable dt = GetUsersFromDB();
            return dt;
        }
    }
}
