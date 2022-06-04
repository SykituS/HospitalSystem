using System.Data;
using System.Data.SqlClient;

namespace BusinessAdministration
{
    public class OfficesManagement
    {
        public static DataTable LoadOffices()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Of_id_office, Of_office_number, Of_status, Of_plenary, Name FROM dbo.Office INNER JOIN dbo.Specialisation ON Of_specialisation = ID_Specialisation";
            SqlCommand cmd = new SqlCommand(query);

            DBSystem.DBSystem.SelectFromDB(dt, cmd);

            return dt;
        }

        public static DataTable LoadSpecialisation()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM dbo.Specialisation";
            SqlCommand cmd = new SqlCommand(query);

            DBSystem.DBSystem.SelectFromDB(dt, cmd);

            return dt;
        }
    }
}
