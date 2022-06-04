using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace Reception
{
    public class Reception
    {
        static string sortDirection = " ASC";
        public static DataTable LoadPats()
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT Id_Patients, Name, Surname, Pesel, Date_of_birth, Email, Phone_number, Correspondence_adress, Date_of_the_visit FROM dbo.Patients ";
            SqlCommand query = new SqlCommand(cmd);
            DBSystem.DBSystem.SelectFromDB(dt, query);

            return dt;
        }


        //Filtering data by name, surname and pesel
        public static DataView FilterDataView(string Tbx_name, string Tbx_surname, string Tbx_pesel)
        {
            DataView dv = new DataView(LoadPats());



            if (Tbx_name != "" && Tbx_surname != "" && Tbx_pesel != "")
                dv.RowFilter = string.Format("Name = '{0}' AND Surname = '{1}' AND Pesel = '{2}'", Tbx_name, Tbx_surname, Tbx_pesel);
            else if (Tbx_pesel != "")
                dv.RowFilter = string.Format("Pesel = '{0}'", Tbx_pesel);
            else if (Tbx_name != "")
                dv.RowFilter = string.Format("Name = '{0}'", Tbx_name);
            else if (Tbx_surname != "")
                dv.RowFilter = string.Format("Surname = '{0}'", Tbx_surname);
            else if (Tbx_name != "" && Tbx_surname != "")
                dv.RowFilter = string.Format("Name = '{0}' AND Surname = '{1}'", Tbx_name, Tbx_surname);
            else if (Tbx_name != "" && Tbx_pesel != "")
                dv.RowFilter = string.Format("Name = '{0}' AND Pesel = '{1}'", Tbx_name, Tbx_pesel);
            else if (Tbx_surname != "" && Tbx_pesel != "")
                dv.RowFilter = string.Format("Surname = '{0}' AND Pesel = '{1}'", Tbx_surname, Tbx_pesel);

            return dv;
        }

        //Sorting data by name and surname
        public static DataView SortDataView(GridViewSortEventArgs e, string Tbx_name, string Tbx_surname, string Tbx_pesel)
        {
            DataView dv = FilterDataView(Tbx_name, Tbx_surname, Tbx_pesel);
            dv.Sort = e.SortExpression + sortDirection;

            if (sortDirection == " ASC")
                sortDirection = " DESC";
            else
                sortDirection = " ASC";

            return dv;
        }
    }


}
