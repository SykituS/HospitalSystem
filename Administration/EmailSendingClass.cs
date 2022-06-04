using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Administration
{
    public class EmailSendingClass
    {
        //Sending email to user
        public static void EmailSending(string email, string topic, StringBuilder sb)
        {
            MailMessage message = new MailMessage("medicalcliniceksoc@gmail.com", email.Trim(), topic, sb.ToString());

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("medicalcliniceksoc@gmail.com", "MedicalEksoc");
            smtp.EnableSsl = true;
            message.IsBodyHtml = true;

            smtp.Send(message);
        }

        //Email validation
        public static bool IsValidEmail(string email)
        {
            bool Result = false;

            try
            {
                var emailValid = new MailAddress(email);

                Result = (email.LastIndexOf(".") > email.LastIndexOf("@"));
            }
            catch (Exception)
            {
                Result = false;
            }

            return Result;
        }
    }
}
