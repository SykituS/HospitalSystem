using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdministration
{
    public class OfficesManagement
    {
        public static DataTable LoadOffices()
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT Of_id_office, Of_office_number, Of_status, Of_plenary, Name FROM dbo.Office INNER JOIN dbo.Specialisation ON Of_specialisation = ID_Specialisation";
            SqlCommand query = new SqlCommand(cmd);

            DBSystem.DBSystem.SelectFromDB(dt, query);

            return dt;
        }
    }
}
