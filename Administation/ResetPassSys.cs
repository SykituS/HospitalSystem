using Administation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace Administation
{
    public class ResetPassSys
    {
        public static void SendMail(string login, string email)
        {
            DataTable dt = new DataTable();

            string query = "";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Login", login);
            command.Parameters.AddWithValue("@Email", email);
            DBSystem.DBSystem.SelectFromDB(dt, command);

            if (dt.Rows.Count == 0)
                return;

            EmailSending(email);

        }

        private static void EmailSending(string email)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Hi, <br /> Click on link to reset your password <br />");
            sb.Append("<a href=http://localhost:44356/ResetPassPage.aspx?username=" + GetUserEmail(email));
            sb.Append("&email=" + email + "> Click here to change your password</a><br />");

            MailMessage message = new MailMessage("sender", email.Trim(), "Password reset", sb.ToString());

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("sender", "senderpass");
            smtp.EnableSsl = true;
            message.IsBodyHtml = true;

            smtp.Send(message);
        }

        private static string GetUserEmail(string email)
        {
            DataTable dt = new DataTable();

            string query = "";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@email", email);
            DBSystem.DBSystem.SelectFromDB(dt, command);

            string username = "matxx29@gmail.com";

            foreach (DataRow dr in dt.Rows)
                username = dr["EM_Email"].ToString();

            return username;
        }
    }
}
