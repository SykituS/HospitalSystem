using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;


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


    }
}
