using System.Data;
using System.Data.SqlClient;
//Class that contains functions for logging into the system
namespace Administration
{
    public class LogSys
    {

        //Checking whether the user is logged in
        public static bool CheckIfLogged()
        {
            if (!MySession.Current.IsLogged)
                return false;

            return true;
        }

        //Logging the user out of the system
        public static void LogoutFromSystem()
        {
            MySession.Current.IsLogged = false;
        }

        //Logging the user into the system
        public static void LoginToSystem(string login, string password)
        {
            //Variables that will store the information received from the database
            DataTable dt = new DataTable();

            /*Function 'SelectFromDB' from the DBSystem.dll file
            It sends the DataTable variable to the database, determines what the newly created table, containing user's login, password, email and position, should be called
            and sends a query to the database, which checks whether the given data exists in the database. */

            string query = "SELECT dbo.Users.US_login, dbo.users.US_Password, dbo.employee.EM_Email, dbo.Position.PO_Name " +
                "FROM dbo.Employee INNER JOIN dbo.Users ON dbo.Users.US_Employee=dbo.Employee.EM_Id_Employee INNER JOIN dbo.Position ON dbo.Employee.EM_Position = dbo.Position.PO_Id_Position " +
                "WHERE US_Login = @Login AND US_Password = @Password";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Login", login);
            command.Parameters.AddWithValue("@Password", PasswordHashing.hashPassword(password));
            DBSystem.DBSystem.SelectFromDB(dt, command);

            //Checking if DataTable dt contains any data, the lack of it means that the user being checked does not exist in the database
            if (dt.Rows.Count == 0)
                return;

            //Filling in user data
            foreach (DataRow dr in dt.Rows)
            {
                MySession.Current.Login = login;
                MySession.Current.Email = dr["EM_Email"].ToString();
                MySession.Current.Position = dr["PO_Name"].ToString();
            }

            //Changing the value of the variable that stores information about whether the user is logged in
            MySession.Current.IsLogged = true;
            MySession.Current.Attempt = 3;
        }

        public static string GetAttempTextTry()
        {
            return "Wrong login or password! You have " + MySession.Current.Attempt + " more attempts";
        }

        public static string GetAttempTextBlock(string timeText)
        {
            return "Too many incorrect attempts. Login has been blocked. Please try again in " + timeText;
        }

        public static string WrongAttempt()
        {
            MySession.Current.Attempt--;

            return GetAttempTextTry();
        }

        public static int GetAttempNumber()
        {
            return MySession.Current.Attempt;
        }
    }
}
