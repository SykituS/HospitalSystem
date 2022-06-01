using System;
using System.Data;
using System.Data.SqlClient;
using Administration;
using System.Collections.Generic;


namespace Doctor
{
    public class AppoitmentDetails
    {
        public DataTable Get_Details(int appointment_id)
        {
            DataTable dt = new DataTable();

            string querry = "SELECT Name, Surname, Pesel, Sx_Sex, Date_of_birth, Correspondence_adress, Email, " +
                "Phone_number, AD_visit_progress, AD_referral, AD_needed_next_visit, AD_appointment_description" +
                "\n FROM Patients, Appointment_details,Term_Of_Visit,Sex" +
                "\n WHERE AD_fk_patients = id_Patients" +
                "\n AND Ap_id_appoitment = AD_fk_appointments" +
                "\n AND Ap_id_appoitment = @ap_id" +
                "\n AND Sex = Sx_Id_Status";

            SqlCommand command = new SqlCommand(querry);

            command.Parameters.AddWithValue("@ap_id", appointment_id);

            DBSystem.DBSystem.SelectFromDB(dt, command);

            return dt;
        }

        public void Adding_Results(int appointment_id, string description)
        {
            string querry = "UPDATE Appointment_details" +
                            "\n SET AD_appointment_description = @description" +
                            "\n WHERE AD_fk_appointments = @appointment_id";

            SqlCommand command = new SqlCommand(querry);

            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@appointment_id", appointment_id);

            DBSystem.DBSystem.UpdateDB(command);
        }
           
        public void Add_New_Appoitment(DateTime dateTime)
        {
            GetAppoitments getAppoitments = new GetAppoitments();
            int doctor_id = getAppoitments.Get_Doctor_ID();
            int office_id = 1;


            string querry = "insert into Term_Of_Visit(Ap_appoitment_day, Ap_appoitment_time, Ap_doctor, Ap_status, Ap_office)" +
                            "\n values(@day, @hour, @doctor_id, 2, @doctor_id)";

            SqlCommand command = new SqlCommand(querry);

            command.Parameters.AddWithValue("@doctor_id", doctor_id);
            command.Parameters.AddWithValue("@day", dateTime.Day.ToString());
            command.Parameters.AddWithValue("@hour", dateTime.Hour.ToString());
            command.Parameters.AddWithValue("@office_id", office_id);


            DBSystem.DBSystem.InsertToDB(command);
        }

    }
}
