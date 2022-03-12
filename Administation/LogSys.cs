using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBSystem;


//Class that contains functions for logging into the system
namespace Administation
{
    public class LogSys
    {

        //Creating a new user and storing it in the memory
        static LoggedUser user = new LoggedUser();

        //Checking whether the user is logged in
        public static bool CheckIfLogged()
        {
            if (!user.IsLogged)
                return false;

            return true;
        }

        //Logging the user out of the system
        public static void LogoutFromSystem()
        {
            user.IsLogged = false;
        }

        //Logging the user into the system
        public static void LoginToSystem(string login, string password)
        {
            //Variables that will store the information received from the database
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            /*Function 'SelectFromDB' from the DBSystem.dll file
            It sends the DataSet variable to the database, determines what the newly created table, containing user's login, password, email and position, should be called
            and sends a query to the database, which checks whether the given data exists in the database. */
            DBSystem.DBSystem.SelectFromDB(ds, "Users", "SELECT dbo.Users.US_login, dbo.users.US_Password, dbo.employee.EM_Email, dbo.Position.PO_Name " +
                "FROM dbo.Employee INNER JOIN dbo.Users ON dbo.Users.US_Employee=dbo.Employee.EM_Id_Employee INNER JOIN dbo.Position ON dbo.Employee.EM_Position = dbo.Position.PO_Id_Position " +
                "WHERE US_Login = '" + login + "' AND US_Password = '" + password + "'");

            //Filling the DataTable dt with data from the table "Users"
            dt = ds.Tables["Users"];

            //Checking if DataTable dt contains any data, the lack of it means that the user being checked does not exist in the database
            if (dt.Rows.Count == 0)
                return;

            //Filling in user data
            foreach (DataRow dr in dt.Rows)
                user.setData(login, password, dr["EM_Email"].ToString(), dr["PO_Name"].ToString());

            //Changing the value of the variable that stores information about whether the user is logged in
            user.IsLogged = true;

            user.Attempt = 3;
        }

        public static string WrongAttempt()
        {
            user.Attempt--;
            
            if (user.Attempt <= 0)
                return "Too many incorrect attempts. Login has been blocked. Please try again in X minutes";

            return "Wrong login or password! You have "+user.Attempt+" more attempts";
        }
    }
}
