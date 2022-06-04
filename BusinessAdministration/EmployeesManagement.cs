using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BusinessAdministration
{
    public class EmployeesManagement
    {
        static string sortDirection = " ASC";
        public static DataTable LoadEmps()
        {
            DataTable dt = new DataTable();
            string query = "SELECT EM_Id_Employee, EM_Name, EM_Surname, EM_Pesel, EM_Date_of_birth, PO_Name, St_Status_Name FROM (dbo.Employee INNER JOIN dbo.Position ON EM_Position = PO_Id_Position) INNER JOIN dbo.Status ON EM_Id_Status = St_Id_Status";
            SqlCommand cmd = new SqlCommand(query);

            DBSystem.DBSystem.SelectFromDB(dt, cmd);

            return dt;
        }

        public static DataTable LoadRoles()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM dbo.Position";
            SqlCommand cmd = new SqlCommand(query);

            DBSystem.DBSystem.SelectFromDB(dt, cmd);

            return dt;
        }

        public static DataTable LoadEmpDetails(string employeeId)
        {
            DataTable dt = new DataTable();
            string query = "SELECT EM_Name, EM_Surname, EM_Email, EM_Pesel, EM_Date_of_birth, EM_Correspondence_address, EM_Phone_number, Sx_Sex FROM dbo.Employee INNER JOIN dbo.Sex ON EM_Id_Sex = Sx_Id_Status WHERE EM_Id_Employee = @Id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Id", employeeId);

            DBSystem.DBSystem.SelectFromDB(dt, cmd);

            return dt;
        }

        public static DataView FilterDataView(DropDownList ddlRole, DropDownList ddlStatus)
        {
            DataView dv = new DataView(LoadEmps());
            string selectedTextRole = ddlRole.SelectedItem.Text;
            string selectedTextStatus = ddlStatus.SelectedItem.Text;

            if (selectedTextRole != "All" && selectedTextStatus != "All")
                dv.RowFilter = string.Format("PO_Name = '{0}' AND St_Status_Name = '{1}'", selectedTextRole, selectedTextStatus);
            else if (selectedTextStatus != "All")
                dv.RowFilter = string.Format("St_Status_Name = '{0}'", selectedTextStatus);
            else if (selectedTextRole != "All")
                dv.RowFilter = string.Format("PO_Name = '{0}'", selectedTextRole);

            return dv;
        }

        public static DataView SortDataView(GridViewSortEventArgs e, DropDownList ddlRole, DropDownList ddlStatus)
        {
            DataView dv = FilterDataView(ddlRole, ddlStatus);
            dv.Sort = e.SortExpression + sortDirection;

            if (sortDirection == " ASC")
                sortDirection = " DESC";
            else
                sortDirection = " ASC";

            return dv;
        }

        public static int GetEmployeeStatus(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT EM_Id_Status FROM dbo.Employee WHERE EM_Id_Employee = @Id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Id", id);

            DBSystem.DBSystem.SelectFromDB(dt, cmd);

            int status = (int)dt.Rows[0][0];

            return status;
        }
    }
}
