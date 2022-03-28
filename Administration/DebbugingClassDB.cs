using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DBSystem;
using System.Data;

namespace Administration
{
    public class DebbugingClassDB
    {
        public static string GetTime()
        {
            DataTable dt = new DataTable();

            string q = "SELECT SY_Time_to_unlock FROM dbo.SystemParameters WHERE SY_ID = 1";

            SqlCommand cmd = new SqlCommand(q);

            DBSystem.DBSystem.SelectFromDB(dt, cmd);

            string res = "";

            foreach (DataRow dr in dt.Rows)
            {
                res = dr["SY_Time_to_unlock"].ToString();
            }

            return res;
        }

        public static DataTable SelectInformation()
        {
            DataTable dt = new DataTable();

            string query = "SELECT US_login, EM_Email, US_isDuringReset, US_PassResetActiveTime " +
                "from dbo.users inner join dbo.Employee on Us_employee = EM_Id_Employee ";

            SqlCommand cmd = new SqlCommand(query);

            DBSystem.DBSystem.SelectFromDB(dt, cmd);

            return dt;
        }

        public static string UpdateEmail(string login, string email)
        {
            string query = "UPDATE dbo.Employee " +
                "SET EM_Email = @Email FROM dbo.Employee INNER JOIN dbo.Users on Us_employee = EM_Id_Employee " +
                "WHERE us_login = @Login";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Login", login);
            cmd.Parameters.AddWithValue("@Email", email);
            try
            {
                DBSystem.DBSystem.UpdateDB(cmd);
                return "Success!";
            }
            catch (Exception ex)
            {
                return "Error: " + ex;
            }
        }

        public static string UpdateInformation(string login, DateTime date, bool inProcess)
        {
            string query = "UPDATE dbo.users " +
                "SET US_PassResetActiveTime = @Date, US_isDuringReset = @Bool " +
                "WHERE US_Login = @Login";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Login", login);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.Parameters.AddWithValue("@Bool", inProcess);

            try
            {
                DBSystem.DBSystem.UpdateDB(cmd);
                return "Success!";
            }
            catch (Exception ex)
            {
                return "Error: " + ex;
            }
        }
    }
}
