using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBSystem;

namespace Administation
{
    public class LogSys
    {
        public static bool LoginToSystem(string login, string password)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            DBSystem.DBSystem.SelectFromDB(ds, "Users", "query placeholder");

            if (ds.Tables["Users"].Rows.Count != 1)
            {
                System.Console.WriteLine("False");
                return false;
            }
            System.Console.WriteLine("True");

            return true;
        }
    }
}
