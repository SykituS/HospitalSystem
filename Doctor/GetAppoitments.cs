using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Administration;
using System.Data;
using System.Data.SqlClient;
using DBSystem;

namespace Doctor
{
    public class GetAppoitments
    {

        public static DataTable DataTable_from_SQL()
        {
            
            DataTable dt = new DataTable();
            string login = Current_Login();
            //string login = "AMaldonado5939";

            //a querry that returns information about visits of a logged-in doctor from the database (day, time, patient's data, office number))
            string querry = "SELECT Ap_appoitment_day, Ap_appoitment_time, Ap_appoitment_time_end, Name, Patients.Surname,Of_office_number " + "\n" +
                "FROM Appoitment, Patients, Doctors, Office, Users, Employee" + "\n" + "WHERE Id_Patients = Ap_patient AND ID_Doctor = Ap_doctor AND Of_id_office = Ap_office " +
                "AND EM_Id_Employee = US_Employee AND EM_Id_Employee = ID_Employee AND US_Login = @login";

            //hooking a query
            SqlCommand command = new SqlCommand(querry);

            //replacing the constant expression in the query with a variable corresponding to the login of the logged-in funnel, thanks to it the query retrieves only his calendar
            command.Parameters.AddWithValue("@login", login);

            //downloading data from the database and adding them to DataTable
            DBSystem.DBSystem.SelectFromDB(dt, command);

            return dt;
        }


        
        public static List<DateTime> Get_Dates()
        {   
            //creating data table with all apointments of logged doctor
            DataTable dt = DataTable_from_SQL();

            //creating a list of days on which there are meetings with patients
            List<DateTime> dates = new List<DateTime>();

            //adding days to list
            foreach(DataRow row in dt.Rows)
            {
                dates.Add((DateTime)row[0]);
            }

            return dates;
        }


        public static DataTable Get_Info_Appointment(DateTime day)
        {
            //creating data table with all apointments of logged doctor
            DataTable dt = DataTable_from_SQL();

            //preparing a table that will later be used to store the meetings of the selected day
            DataTable dt_for_day = dt.Clone();
            dt_for_day.Clear();

            //the separation of days that correspond to the date selected by the user
            foreach (DataRow row in dt.Rows)
            {
                //if the given row contains a day equal to the selected day, it copies it to the target table
                DateTime day2 = (DateTime)row["Ap_appoitment_day"];
                if (day2 == day)
                {
                    dt_for_day.Rows.Add(row.ItemArray);
                }
            }

            //editing the table from unnecessary data
            dt_for_day.Columns.Remove("Ap_appoitment_day");
            dt_for_day.Columns.Remove("Ap_appoitment_time_end");
            dt_for_day.Columns["Ap_appoitment_time"].ColumnName = "Godzina wizyty";
            dt_for_day.Columns["Name"].ColumnName = "Imie";
            dt_for_day.Columns["Surname"].ColumnName = "Nazwisko";
            dt_for_day.Columns["Of_office_number"].ColumnName = "Gabinet";


            return dt_for_day;
        }

        //get login of current logged account
        public static string Current_Login()
        {
            string x = MySession.Current.Login;
            return x;
        }
            
    }
}
