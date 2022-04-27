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
        public static DataTable Get_Details(DateTime day,TimeSpan hour)
        {
            DataTable dt = new DataTable();
            string login = Current_Login();

            string data = day.ToString("yyyy-MM-dd");

            string querry = "SELECT p.Name, p.Surname, p.Pesel, p.Sex, p.Date_of_birth, p.Correspondence_adress, " +
                "p.Email, p.Phone_number, ad.AD_visit_progress, ad.AD_referral, " +
                "ad.AD_needed_next_visit, ad.AD_appointment_description " +
                "FROM Employee e, Users u, Doctors d, Appoitment ap, Appointment_details ad, Patients p " +
                "WHERE e.EM_id_Employee = u.US_id_Users " +
                "AND u.US_Login = @login " +
                "AND e.EM_id_Employee = d.ID_Employee " +
                "AND d.ID_Doctor = ap.Ap_doctor " +
                "AND Ap.Ap_id_appoitment = ad.AD_fk_appointments " +
                "AND ad.AD_fk_patients = p.id_Patients " +
                "AND ap.Ap_appoitment_day = @date " +
                "AND ap.Ap_appoitment_time = @hour";

            SqlCommand command = new SqlCommand(querry);

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@date", data);
            command.Parameters.AddWithValue("@hour", hour);

            DBSystem.DBSystem.SelectFromDB(dt, command);

            return dt;
        }

        public static void Adding_Results(DataTable dt)
        {




        }



    }
}
