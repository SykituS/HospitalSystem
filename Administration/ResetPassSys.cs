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
        public static void SendMail(string login, string email, string result)
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

            if (dt.Rows.Count == 0)
            {
                result = "Wrong login or email";
                return;
            }

            //if true stop process
            if (CheckStatus(dt))
            {
                result = "User has alredy applyed for password change";
                return;
            }

            EmailSending(login, email);
            result = "Email has been send!";
        }

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

        private static bool CheckStatus(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (!(bool)dr["US_isDuringReset"])
                    return false;

                if (DateTime.Now > (DateTime)dr["US_PassResetActiveTime"])
                    return false;
            }
            return true;
        }

        private static DateTime UrlActiveTime()
        {
            DateTime time = DateTime.Now.AddMinutes(15);
            return time;
        }
    }
}
