using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Administration
{
    public class UserManagement
    {
        static string sortDirection = " ASC";
        //Retrieving data from a database with possible filters
        public static DataTable GetUsersFromDB(string fName = null, string sName = null, string position = null)
        {
            bool add = false;//If true then add "AND" to query

            DataTable dt = new DataTable();

            //Default querry
            string query = "Select US_Login, EM_Name, EM_Sec_Name, PO_Name, St_Status_Name " +
                "FROM dbo.Employee INNER JOIN dbo.Users on US_Employee = EM_Id_Employee INNER JOIN dbo.Position on EM_Position = PO_Id_Position " +
                "INNER JOIN dbo.status on St_Id_Status = US_Status ";

            using (SqlCommand command = new SqlCommand())
            {
                //Check if any filter has been activated
                if (!string.IsNullOrEmpty(fName) || !string.IsNullOrEmpty(sName) || (!string.IsNullOrEmpty(position) && position != "All"))
                {
                    query += "WHERE "; //Adding "where" to the end of querry
                    if (!string.IsNullOrEmpty(fName))
                    {
                        query += "EM_Name LIKE @fName + '%'";
                        command.Parameters.AddWithValue("@fName", fName);

                        add = true;
                    }
                    if (!string.IsNullOrEmpty(sName))
                    {
                        if (add)
                            query += " AND ";

                        query += "EM_Sec_Name LIKE @sName + '%'";
                        command.Parameters.AddWithValue("@sName", sName);

                        add = true;
                    }
                    if (!string.IsNullOrEmpty(position) && position != "All")
                    {
                        if (add)
                            query += " AND ";

                        query += "PO_Name LIKE @position + '%'";
                        command.Parameters.AddWithValue("@position", position);
                    }
                }
                command.CommandText = query;
                DBSystem.DBSystem.SelectFromDB(dt, command);
            }

            return dt;
        }

        //Getting postions from DataBase
        public static DataTable GetPostionsFromDB()
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM dbo.Position";
            SqlCommand command = new SqlCommand(query);
            DBSystem.DBSystem.SelectFromDB(dt, command);

            return dt;
        }

        //Updating user status in DataBase
        public static DataTable UpdateUserStatus(string login, string status)
        {
            string query = "UPDATE dbo.Users SET US_Status = @StatusID WHERE US_Login = @Login";
            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@Login", login);

            if (status == "Active" )
                command.Parameters.AddWithValue("@StatusID", 2); //Change to inactive
            else
                command.Parameters.AddWithValue("@StatusID", 1); //Change to active

            DBSystem.DBSystem.UpdateDB(command);

            DataTable dt = GetUsersFromDB();
            return dt;
        }
        //Sorting data in GridView
        public static DataView SortDataView(GridViewSortEventArgs e, string fName, string sName, string position)
        {
            DataView dv = new DataView(GetUsersFromDB(fName, sName, position));
            dv.Sort = e.SortExpression + sortDirection;

            if (sortDirection == " ASC")
                sortDirection = " DESC";
            else
                sortDirection = " ASC";

            return dv;
        }
    }
}
