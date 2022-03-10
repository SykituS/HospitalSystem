using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBSystem;

//Class with function needed to login

namespace Administation
{
    public class LogSys
    {
        //storing information about logged user
        static LoggedUser user = new LoggedUser();

        //Checking if user has logged successfully
        public static bool CheckIfLogged()
        {
            if (!user.IsLogged)
                return false;

            return true;
        }

        //Logout user from the system
        public static void LogoutFromSystem()
        {
            user.IsLogged = false;
        }

        //Login user to the system
        public static void LoginToSystem(string login, string password)
        {
            //Create a new varible that will hold information from DataBase
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            //Function from the DBSytem.dll file that check if login and password is correct, and we are getting back a DataSet with information about user
            DBSystem.DBSystem.SelectFromDB(ds, "Users", "SELECT dbo.Users.US_login, dbo.users.US_Password, dbo.employee.EM_Email, dbo.Position.PO_Name " +
                "FROM dbo.Employee INNER JOIN dbo.Users ON dbo.Users.US_Employee=dbo.Employee.EM_Id_Employee INNER JOIN dbo.Position ON dbo.Employee.EM_Position = dbo.Position.PO_Id_Position " +
                "WHERE US_Login = '" + login + "' AND US_Password = '" + password + "'");

            //Transfering information about user from DataSet to DataTable
            dt = ds.Tables["Users"];

            //Checking if Select Function returned something from DataBase
            if (dt.Rows.Count == 0)
                return;

            //Filling information about user 
            foreach (DataRow dr in dt.Rows)
                user.setData(login, password, dr["EM_Email"].ToString(), dr["PO_Name"].ToString());

            //Changing varible that hold information if user should be logged to the system
            user.IsLogged = true;
        }
    }
}
