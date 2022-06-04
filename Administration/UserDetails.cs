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
    public class UserDetails
    {
        public static DataTable GetUsersFromDB()
        {
        
            DataTable dt = new DataTable();           
            string query = "SELECT EM_Name + ' ' + EM_Surname as Name, US_login, St_Status_Name, Po_Name FROM dbo.Employee as Em INNER JOIN dbo.Users as U on US_Employee = EM_Id_Employee INNER JOIN dbo.Position as P on EM_Position = PO_Id_Position INNER JOIN dbo.status as St on St_Id_Status = US_Status WHERE U.US_Login = @login";          
             
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@Login", MySession.Current.TempLogin);
                DBSystem.DBSystem.SelectFromDB(dt, command);
                return dt;
        }

    }
}
