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
            DataTable dt = GetInforamtion(login, email);
            if (dt.Rows.Count == 0)
                return;

            //if true stop process
            if (CheckStatus(login, email))
                return;

            //changing information about link life time and status "is during reset"
            StatusUpdate(login, DateTime.Now.AddMinutes(15), true);

            EmailSending(login, email);
        }

        //Sending email to user
        private static void EmailSending(string login, string email)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Hi, <br /> Click on link to reset your password <br />");
            sb.Append("<a href=https://localhost:44356/Pages/MainPages/ResetPassPage?login=" + login);
            sb.Append("&email=" + email + "> Click here to change your password</a><br />");

            MailMessage message = new MailMessage("medicalcliniceksoc@gmail.com", email.Trim(), "Password reset", sb.ToString());

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("medicalcliniceksoc@gmail.com", "MedicalEksoc");
            smtp.EnableSsl = true;
            message.IsBodyHtml = true;

            smtp.Send(message);
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

        //Email validation
        public static bool IsValidEmail(string email)
        {
            bool Result = false;

            try
            {
                var emailValid = new System.Net.Mail.MailAddress(email);

                Result = (email.LastIndexOf(".") > email.LastIndexOf("@"));
            }
            catch (Exception)
            {
                Result = false;
            }

            return Result;
        }

        //Updating password in database
        public static void ResetPassword(string NewPassword, string login)
        {
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

    }
}
