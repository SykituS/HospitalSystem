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

            DBSystem.DBSystem.SelectFromDB(ds, "Users", "SELECT * FROM dbo.Users WHERE login = '" + login + "' AND Password ='" + password + "'");

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
