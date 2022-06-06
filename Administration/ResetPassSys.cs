using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace Administration
{
    public class ResetPassSys
    {
        //Geting information about login, email, if user is during pass reset, link active time from DB
        private static DataTable GetInforamtion(string login, string email)
        {
            DataTable dt = new DataTable();

            //login, email, password change status, link active time
            string query = "SELECT US_login, EM_Email, US_isDuringReset, US_PassResetActiveTime from dbo.users " +
                "inner join dbo.Employee on Us_employee = EM_Id_Employee " +
                "WHERE US_Login = @Login AND EM_Email = @Email";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Login", login);
            command.Parameters.AddWithValue("@Email", email);
            DBSystem.DBSystem.SelectFromDB(dt, command);

            return dt;
        }

        //Checking user status before sending email
        public static void SendMail(string login, string email)
        {
            //Checking if email is valid
            if (!EmailSendingClass.IsValidEmail(email))
                return;

            DataTable dt = GetInforamtion(login, email);
            if (dt.Rows.Count == 0)
                return;

            //if true stop process
            if (CheckStatus(login, email))
                return;

            //changing information about link life time and status "is during reset"
            StatusUpdate(login, DateTime.Now.AddMinutes(15), true);
            EmailSendingClass.EmailSending(email, "Password reset", Message(login, email));
        }

        private static StringBuilder Message(string login, string email)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Hi, <br /> Click on link to reset your password <br />");
            sb.Append("<a href=https://localhost:44356/Pages/MainPages/ResetPassPage?login=" + login);
            sb.Append("&email=" + email + "> Click here to change your password</a><br />");

            return sb;
        }

        //Checking if user can send new link to reset password
        public static bool CheckStatus(string login, string email)
        {
            DataTable dt = GetInforamtion(login, email);
            
            //check if user is doing reset
            if ((bool)dt.Rows[0]["US_isDuringReset"])
            {
                //check if link should be active
                if (DateTime.Now < (DateTime)dt.Rows[0]["US_PassResetActiveTime"])
                    return true;
            }

            return false;
        }

        //user status update regarding sending a link to change password
        public static void StatusUpdate(string login, DateTime date, bool status)
        {
            string query = "UPDATE dbo.users " +
                "SET US_PassResetActiveTime = @Date, US_isDuringReset = @Bool " +
                "WHERE US_Login = @Login";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Login", login);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.Parameters.AddWithValue("@Bool", status);

            try
            {
                DBSystem.DBSystem.UpdateDB(cmd);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error:" + ex);
            }
        }

        //Updating password in database
        public static void ResetPassword(string NewPassword, string ConfirmPassword, string login) 
        {
            if (!PasswordValidation(NewPassword, ConfirmPassword).Equals("OK"))
                return;

            string query = "UPDATE Users SET US_Password =@NewPassword WHERE US_Login= @login ";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@NewPassword", PasswordHashing.hashPassword(NewPassword));
            
            try
            {
                DBSystem.DBSystem.UpdateDB(command);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error:" + ex);
            }
        }

        //BackEnd password Validation
        public static string PasswordValidation(string NewPassword, string ConfirmPassword)
        {
            if (NewPassword.Length == ConfirmPassword.Length)
            {
                if (NewPassword.Length >= 8 && ConfirmPassword.Length <= 15)
                {
                    if (NewPassword.Any(char.IsUpper) && NewPassword.Any(char.IsLower) && NewPassword.Any(char.IsDigit) && NewPassword.Any(char.IsPunctuation))
                    {
                        return "OK";
                    }
                    else
                        return "Password must include at least one lowercase, uppercase, number and special character (-, _, !, #, $, *)";
                }
                else
                    return "Incorrect password length";
            }
            else
                return "Passwords must be this same";

        }

        public static void ForcePasswordChange(string login, int forceType)
        {
            string query = "UPDATE dbo.Users SET US_ForcePasswordChange = @type WHERE US_Login = @login";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@type", forceType);

            try
            {
                DBSystem.DBSystem.UpdateDB(command);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error:" + ex);
            }
        }
    }
}
