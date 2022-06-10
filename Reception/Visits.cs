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

        

    }
}
