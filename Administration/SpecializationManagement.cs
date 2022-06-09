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
            string query = "SELECT ID_Specialisation, Name FROM Specialisation WHERE Is_ActiveSpecialisation = 0";
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
            if (!Validation(MySession.Current.TempSpecText))
                return;

            string query = "UPDATE Specialisation SET Name = @name WHERE Name = @oldName";
            if (MySession.Current.TempAction == "Delete")
            {
                MySession.Current.TempSpecText = PasswordHashing.hashPassword(MySession.Current.TempSpecText.Trim());
                query = "UPDATE Specialisation SET Name = @name, Is_ActiveSpecialisation = 1 WHERE Name = @oldName";
            }
                

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@name", MySession.Current.TempSpecText);
            command.Parameters.AddWithValue("@oldName", MySession.Current.TempSpecTextOriginal);
            DBSystem.DBSystem.UpdateDB(command);

            SpecSesionClear();
        }

        public static void AddNewSpecialization()
        {
            if (!Validation(MySession.Current.TempSpecText))
                return;

            string query = "INSERT INTO Specialisation(ID_Specialisation, Name) Values(NEXT VALUE FOR Seq_Specialisation, @name)";
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

        public static bool Validation(string name)
        {
            if (name.Any(char.IsDigit) || name.Any(char.IsPunctuation) || name.Any(char.IsSymbol))
                return false;
            return true;
        }
    }
}
