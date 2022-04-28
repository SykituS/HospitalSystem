using System;
using System.Data;
using static Doctor.GetAppoitments;
using System.Data.SqlClient;
using Administration;
using System.Collections.Generic;


namespace Doctor
{
    public class AppoitmentDetails
    {
        public static DataTable Get_Details(int appointment_id)
        {
            DataTable dt = new DataTable();
            string login = Current_Login();

            string querry = "SELECT Name, Surname, Pesel, Sex, Date_of_birth, Correspondence_adress, Email, " +
                "Phone_number, AD_visit_progress, AD_referral, AD_needed_next_visit, AD_appointment_description" +
                "\n FROM Patients, Appointment_details,Term_Of_Visit"+
                "\n WHERE AD_fk_patients = id_Patients"+
                "\n AND Ap_id_appoitment = AD_fk_appointments"+
                "\n AND Ap_id_appoitment = @ap_id";

            SqlCommand command = new SqlCommand(querry);

            command.Parameters.AddWithValue("@ap_id", appointment_id);

            DBSystem.DBSystem.SelectFromDB(dt, command);

            return dt;
        }

        public static void Adding_Results(int appointment_id, string description)
        {
            string querry = "UPDATE Appointment_details" +
                            "\n SET AD_appointment_description = @description" +
                            "\n WHERE AD_fk_appointments = @appointment_id";

            SqlCommand command = new SqlCommand(querry);

            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@appointment_id", appointment_id);

            DBSystem.DBSystem.UpdateDB(command);
        }



    }
}
