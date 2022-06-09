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
           
        public void Add_New_Appoitment(DateTime dateTime, int current_visit_id)
        {
            GetAppoitments getAppoitments = new GetAppoitments();
            int doctor_id = getAppoitments.Get_Doctor_ID();
            int office_id = 1;


            string querry = "insert into Term_Of_Visit (Ap_appoitment_day, Ap_appoitment_time, Ap_doctor, Ap_status, Ap_office) " +
                            "\n values (@day, @hour, @doctor_id, 2, @office_id)";


            SqlCommand command = new SqlCommand(querry);
            string day = dateTime.ToString("yyyy-MM-dd");
            string hour = dateTime.ToString("HH:mm:ss");
            command.Parameters.AddWithValue("@day", day);
            command.Parameters.AddWithValue("@doctor_id", doctor_id);
            command.Parameters.AddWithValue("@hour", hour);
            command.Parameters.AddWithValue("@office_id", office_id);
            
            DBSystem.DBSystem.InsertToDB(command);


            DBSystem.DBSystem.sql.Open();
            string select_last_visit = "select max(Ap_id_appoitment) from Term_Of_Visit";
            SqlCommand command_last_visit_id = new SqlCommand(select_last_visit, DBSystem.DBSystem.sql);
            int id_of_last_visit = (Int32)command_last_visit_id.ExecuteScalar();

            string select_patient_id = "\n SELECT Id_Patients FROM Term_Of_Visit, Appointment_details ,Patients" +
                    "\n WHERE Ap_id_appoitment = AD_fk_appointments" +
                    "\n AND Id_Patients = AD_fk_patients" +
                    "\n AND Ap_id_appoitment = @id";
            SqlCommand command_pateint_id = new SqlCommand(select_patient_id, DBSystem.DBSystem.sql);
            command_pateint_id.Parameters.AddWithValue("@id", current_visit_id.ToString());
            int patient_id = (Int32)command_pateint_id.ExecuteScalar();

            string details = "insert into Appointment_details(AD_id, AD_fk_patients, AD_visit_progress, AD_referral, AD_needed_next_visit, AD_appointment_description, AD_fk_appointments)" +
                                "\n values" +
                                "\n (NEXT VALUE FOR sequen_details_ap, @id_patient , 'correct', 'no', 'no', '', @id_visit)";

            SqlCommand command_details = new SqlCommand(details);
            command_details.Parameters.AddWithValue("@id_visit", id_of_last_visit.ToString());
            command_details.Parameters.AddWithValue("@id_patient", patient_id.ToString());

            DBSystem.DBSystem.InsertToDB(command_details);
            DBSystem.DBSystem.sql.Close();

        }

        public DataTable All_appoitments_of_current_patient(int current_id)
        {
            DataTable dt = new DataTable();
            
                      //dodalem pobieranie ap_id_appoitment \/
            string querry = "SELECT Id_Patients,Ap_id_appoitment,Ap_appoitment_day, Ap_appoitment_time, AD_appointment_description FROM Term_Of_Visit, Appointment_details ,Patients" +
                            "\n WHERE Ap_id_appoitment = AD_fk_appointments" +
                            "\n AND Id_Patients = AD_fk_patients" +
                            "\n AND Id_Patients = (SELECT Id_Patients FROM Term_Of_Visit, Appointment_details ,Patients" +
                            "\n WHERE Ap_id_appoitment = AD_fk_appointments" +
                            "\n AND Id_Patients = AD_fk_patients" +
                            "\n AND Ap_id_appoitment = @id)";

            SqlCommand command = new SqlCommand(querry);
            
            command.Parameters.AddWithValue("@id", current_id.ToString());

            DBSystem.DBSystem.SelectFromDB(dt, command);

            return dt;
        }

        public void Add_prescription(int id_visit, string prescription)
        {
            string querry = "insert into Prescription(Pr_id, Pr_drugs, Pr_Appointment)" +
                            "\n values" +
                            "\n (NEXT VALUE FOR prescription_seq, '@prescription', @id_visit)";

            SqlCommand command = new SqlCommand(querry);

            command.Parameters.AddWithValue("@id_visit", id_visit);
            command.Parameters.AddWithValue("@prescription", prescription);

            DBSystem.DBSystem.UpdateDB(command);
        }

        public void Add_refferal(int id_visit, string refferal)
        {
            string querry = "UPDATE Appointment_details"+
                            "\n SET AD_referral_description = @refferal" +
                            "\n WHERE AD_fk_appointments = @id_visit";

            SqlCommand command = new SqlCommand(querry);

            command.Parameters.AddWithValue("@id_visit", id_visit);
            command.Parameters.AddWithValue("@refferal", refferal);

            DBSystem.DBSystem.UpdateDB(command);
        }
    }
}
