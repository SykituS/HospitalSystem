using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration
{
    public class SpecializationManagement
    {

        public static DataTable GetSpecializationList()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Specialisation";
            SqlCommand command = new SqlCommand(query);
            DBSystem.DBSystem.SelectFromDB(dt, command);
            return dt;
        }

        public static string GetSpecializationName()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Name FROM Specialisation WHERE ID_Specialisation = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", MySession.Current.TempID);
            DBSystem.DBSystem.SelectFromDB(dt, command);

            return (string)dt.Rows[0][0];
        }

        public static void UpdateSpecialization()
        {
            string query = "UPDATE Specialisation SET Name = @name WHERE Name = @oldName";
            SqlCommand command = new SqlCommand(query);
            if (MySession.Current.TempAction == "Delete")
                MySession.Current.TempSpecText = PasswordHashing.hashPassword(MySession.Current.TempSpecText.Trim());

            command.Parameters.AddWithValue("@name", MySession.Current.TempSpecText);
            command.Parameters.AddWithValue("@oldName", MySession.Current.TempSpecTextOriginal);
            DBSystem.DBSystem.UpdateDB(command);

            SpecSesionClear();
        }

        public static void AddNewSpecialization()
        {
            string query = "INSERT INTO Specialisation Values(NEXT VALUE FOR Seq_Specialisation, @name)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@name", MySession.Current.TempSpecText);
            DBSystem.DBSystem.InsertToDB(command);

            SpecSesionClear();
        }

        public static void SpecSesionClear()
        {
            MySession.Current.TempAction = null;
            MySession.Current.TempID = null;
            MySession.Current.TempRedirectText = null;
            MySession.Current.TempSpecText = null;
            MySession.Current.TempSpecTextOriginal = null;
        }
    }
}
