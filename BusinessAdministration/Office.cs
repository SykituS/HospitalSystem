using System.Data.SqlClient;

namespace BusinessAdministration
{
    public class Office
    {
        private string roomNumber;
        private byte specialisation;
        private string plenary;
        private string status;
        private string renumerated;

        public Office(string roomNumber, byte specialisation, string plenary, string status, string renumerated)
        {
            this.roomNumber = roomNumber;
            this.specialisation = specialisation;
            this.plenary = plenary;
            this.status = status;
            this.renumerated = renumerated;
        }

        public Office(byte specialisation, string plenary, string status, string renumerated)
        {
            this.specialisation = specialisation;
            this.plenary = plenary;
            this.status = status;
            this.renumerated = renumerated;
        }

        public void InsertOfficeToDb()
        {
            string query = "INSERT INTO dbo.Office(Of_office_number, Of_status, Of_changed, Of_plenary, Of_specialisation) VALUES(@RoomNumber, @Status, @Renumerated, @Plenary, @Specialisation)";
            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
            cmd.Parameters.AddWithValue("@Specialisation", specialisation);
            cmd.Parameters.AddWithValue("@Plenary", plenary);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Renumerated", renumerated);

            DBSystem.DBSystem.InsertToDB(cmd);
        }

        public void UpdateOfficeToDb(int id)
        {
            string query = "UPDATE dbo.Office SET Of_status = @Status, Of_changed = @Renumerated, Of_plenary = @Plenary, Of_Specialisation = @Specialisation WHERE Of_Id_office = @Id";
            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Specialisation", specialisation);
            cmd.Parameters.AddWithValue("@Plenary", plenary);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Renumerated", renumerated);

            DBSystem.DBSystem.InsertToDB(cmd);
        }

        public static void DeleteOfficeFromDb(int room)
        {
            string query = "DELETE FROM dbo.Office WHERE Of_office_number = @Room";
            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("Room", room);

            DBSystem.DBSystem.DeleteFromDB(cmd);
        }
    }
}
