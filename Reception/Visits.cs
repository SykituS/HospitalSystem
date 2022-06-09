using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.Entity;
using Microsoft.Exchange.WebServices.Data;

namespace Reception
{
    public class Visits
    {
        private string patient;
        private DateTime dateOfVisit;
        private TimeSpan timeOfVisit;
        private string doctor;
        //private string specialization;
        private int office;


        public Visits(string patient, DateTime dateOfVisit, TimeSpan timeOfVisit, string doctor, int office)
        {
            this.patient = patient;
            this.dateOfVisit = dateOfVisit;
            this.timeOfVisit = timeOfVisit;
            this.doctor = doctor;
            //this.specialization = specialization;
            this.office = office;
        }

        public void AddVisitToDb()
        {
            string cmd = "insert into Term_Of_Visit  (Ap_appoitment_day, Ap_appoitment_time, Ap_doctor, Ap_status, Ap_office) values (NEXT VALUE FOR sequen_visit_term, @dateofvisit, @timeofvisit, @doctor, 3, @office)";
            //string cmd2 = "insert into Appointment_details (AD_id, AD_fk_patients, AD_visit_progress, AD_referral, AD_needed_next_visit, AD_appointment_description, AD_fk_appointments)values(NEXT VALUE FOR sequen_details_ap, 1, 'correct', 'yes', 'no', 'dsc466', 73)";
            SqlCommand query = new SqlCommand(cmd);

            query.Parameters.AddWithValue("@dateofvisit", dateOfVisit);
            query.Parameters.AddWithValue("@timeofvisit", timeOfVisit);
            query.Parameters.AddWithValue("@doctor", doctor);
            //query.Parameters.AddWithValue("@specialization", specialization);
            query.Parameters.AddWithValue("@office", office);

            DBSystem.DBSystem.InsertToDB(query);

           /* string cmd2 = "insert into Appointment_details (AD_fk_patients, AD_visit_progress, AD_referral, AD_needed_next_visit, AD_appointment_description, AD_fk_appointments)values(NEXT VALUE FOR sequen_details_ap, @patientId, 'correct', 'yes', 'no', 'dsc466', 73)";
            SqlCommand query2 = new SqlCommand(cmd2);
            query2.Parameters.AddWithValue("@patientId", id);*/
        }

        public void UpdateVisitToDb(int id)
        {
            string cmd = "UPDATE";
            SqlCommand query = new SqlCommand(cmd);

            //query.Parameters.AddWithValue();

            DBSystem.DBSystem.UpdateDB(query);

        }

        public static bool ValidateDateOfVisit(DateTime dateOfVisit)
        {
            if (dateOfVisit < DateTime.Today || dateOfVisit.Date.Equals(null))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateTimeOfVisit(TimeSpan timeOfVisit, DateTime dateOfVisit)
        {
            if (dateOfVisit.Date == DateTime.Now.Date)
            {
                TimeSpan actual_time = DateTime.Now.TimeOfDay;

                if (timeOfVisit <= actual_time)
                {
                    return false;
                }
            }
            return true;
        }

        /*public static bool ValidateVisitHour(DateTime this_date, TimeSpan this_time, int this_duration, string id_employee, string id_patient, string id_office)
        {
            string date = "'" + this_date.ToString("yyyy-MM-dd") + "'";
            string start_time = "'" + this_time.ToString() + "'";
            string end_time = "'" + (TimeSpan.FromMinutes(this_duration) + this_time).ToString() + "'";
            string id_e = "'" + id_employee + "'";
            string id_p = "'" + id_patient + "'";
            string id_o = "'" + id_office + "'";
            Database.openConnection();

            //Gets last previous appointment
            string query = $"SELECT v.id, v.duration, v.status, v.description, v.id_employee, CONCAT(e.first_name, ' ', e.second_name) AS 'doctor', v.id_patient, (SELECT CONCAT(p.first_name, ' ',p.second_name) FROM patients p WHERE p.id = v.id_patient) AS 'patient', v.id_office, o.number_of_office, v.date, v.time, v.payments FROM employees e INNER JOIN visits v ON e.id = v.id_employee INNER JOIN offices o ON v.id_office = o.id WHERE v.date LIKE {date} and (v.time BETWEEN {start_time} and {end_time} OR ADDTIME(v.time, SEC_TO_TIME(v.duration*60)) BETWEEN {start_time} and {end_time}) AND (v.id_employee LIKE {id_e} OR v.id_patient LIKE {id_p} OR v.id_office LIKE {id_o});";
            MySqlDataReader data = Database.dataReader(query);
            List<Appointment> searched_appointments = new List<Appointment>();
            while (data.Read())
            {
                Appointment searched_appointment = new Appointment(data.GetInt32(0), data.GetInt32(1), (StatusEnum)Enum.Parse(typeof(StatusEnum), data.GetString(2)), data.GetString(3), data.GetInt32(4), data.GetString(5), data.GetInt32(6), data.GetString(7), data.GetInt32(8), data.GetInt32(9), data.GetDateTime(10), data.GetTimeSpan(11), data.GetDouble(12));

                searched_appointments.Add(searched_appointment);
            }
            Database.closeConnection();

            if (searched_appointments.Count == 0)
            {
                return true;
            }

            return false;
        }
        */

    }
}
