using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBSystem;

//Script about login to the application

namespace Administation
{
    public class LogSys
    {
        static LoggedUser user = new LoggedUser();


        public static bool CheckIfLogged()
        {
            if (!user.IsLogged)
                return false;

            return true;
        }

        public static void LoginToSystem(string login, string password)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            DBSystem.DBSystem.SelectFromDB(ds, "Users", "SELECT dbo.Users.US_login, dbo.users.US_Password, dbo.employee.EM_Email, dbo.Position.PO_Name FROM dbo.Employee INNER JOIN dbo.Users ON dbo.Users.US_Employee=dbo.Employee.EM_Id_Employee INNER JOIN dbo.Position ON dbo.Employee.EM_Position = dbo.Position.PO_Id_Position WHERE US_Login = '" + login + "' AND US_Password = '" + password + "'");

            dt = ds.Tables["Users"];
            if (dt.Rows.Count != 1)
            {
                System.Console.WriteLine("False");
            }
            System.Console.WriteLine("True");

            foreach (DataRow dr in dt.Rows)
                user.setData(login, password, "test@", "test");

            user.IsLogged = true;
        }
    }
}
