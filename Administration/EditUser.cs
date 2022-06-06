using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace Administration
{
    public class EditUser
    {
        public static string GetEditEmail(string login)
        {
            login = MySession.Current.TempLogin;

            DataTable dt = new DataTable();
            string query = "SELECT EM_Email FROM dbo.Employee WHERE (CONCAT(LEFT(EM_NAME, 1), EM_Surname,  LEFT(EM_Pesel,2),  RIGHT(EM_Pesel,2))) = @login";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@login", login);
            DBSystem.DBSystem.SelectFromDB(dt, command);
            return (string)dt.Rows[0][0];

        }

        public static string GetStatus(string login)
        {
            login = MySession.Current.TempLogin;

            DataTable dt = new DataTable();
            string query = " SELECT St_Status_Name FROM Status as s inner join Users as U ON s.St_Id_Status = U.US_Status WHERE US_Login =@login";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@login", login);
            DBSystem.DBSystem.SelectFromDB(dt, command);
            return (string)dt.Rows[0][0];

        }
        public static void EditUsers(string login)
        {
            string password = MySession.Current.TempPass;
            string email = GetEditEmail(login);
            try
            {
                if (!EmailSendingClass.IsValidEmail(email))
                    return;

                EmailSendingClass.EmailSending(email, "Login data", Message(password));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error:" + ex);
            }
        }
        private static StringBuilder Message(string password)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Hi, <br /> Here is your new password: <br />");
            sb.Append("Password: " + password + "<br />");
            sb.Append("Have a nice day, <br /> Medical clinic");

            return sb;
        }
        public static void SetUserStatus()
        {


            if (MySession.Current.TempStatus != "Active")
            {
                MySession.Current.TempStatus = "Active";

            }
            else
            {
                MySession.Current.TempStatus = "Inactive";

            }
        }
        public static void ClearEdit()
        {
            MySession.Current.TempPass = null;
            MySession.Current.TempStatus = null;
            MySession.Current.FirstLoad = 0;

        }



        public static DataTable UpdateUserEditStatus(string login, string status)
        {
            string query = "UPDATE dbo.Users SET US_Status = @StatusID WHERE US_Login = @Login";
            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@Login", login);

            if (status != "Active")
                command.Parameters.AddWithValue("@StatusID", 2); //Change to inactive
            else
                command.Parameters.AddWithValue("@StatusID", 1); //Change to active

            DBSystem.DBSystem.UpdateDB(command);

            DataTable dt = UserManagement.GetUsersFromDB();
            return dt;
        }
    }
}
