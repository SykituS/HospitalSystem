using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Administration
{
    public class SettingsPanel
    {
        public static int ShowTime()
        {
            DataTable dt = new DataTable();

            string query = "SELECT SY_Time_to_unlock FROM dbo.SystemParameters WHERE SY_ID = 1";

            SqlCommand command = new SqlCommand(query);

            DBSystem.DBSystem.SelectFromDB(dt, command);


            if (dt.Rows.Count == 0)
                return MySession.Current.SetTime;

            MySession.Current.SetTime = (Int32)dt.Rows[0]["SY_Time_to_unlock"];

            return MySession.Current.SetTime;
        }

        public static void TimeSet(int time)
        {
            string query = "UPDATE dbo.SystemParameters SET SY_Time_to_unlock = @time WHERE SY_ID = 1";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@time", time * 60);

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
