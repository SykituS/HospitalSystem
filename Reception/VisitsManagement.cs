using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web;

namespace Reception
{
    public class VisitsManagement
    {
        static string sortDirection = " ASC";
        public static DataTable LoadVisits()
        {
            DataTable dt = new DataTable();

            //string cmd = "SELECT tv.Ap_id_appoitment, s.St_Status_Name,tv.Ap_appoitment_day,tv.Ap_appoitment_time,p.Name,p.Surname ,p.Pesel,o.Of_office_number,d.First_name ,d.Surname  ,sp.Name FROM Term_Of_Visit tv LEFT JOIN  Appointment_details ap ON ap.AD_fk_appointments = tv.Ap_id_appoitment LEFT JOIN Patients p ON p.Id_Patients = ap.AD_fk_patients  LEFT JOIN Doctors d ON tv.Ap_doctor = d.ID_Doctor LEFT JOIN Office o ON tv.Ap_office = o.Of_id_office LEFT JOIN Status s ON tv.Ap_status = s.St_Id_Status LEFT JOIN Specialisation sp ON o.Of_specialisation = sp.ID_Specialisation";
            string cmd = "SELECT tv.Ap_id_appoitment, tv.Ap_appoitment_day,tv.Ap_appoitment_time,p.Name + ' ' + p.Surname AS Patient, p.Pesel,o.Of_office_number,d.First_name + ' ' + d.Surname As Doctor, sp.Name FROM Term_Of_Visit tv LEFT JOIN  Appointment_details ap ON ap.AD_fk_appointments = tv.Ap_id_appoitment LEFT JOIN Patients p ON p.Id_Patients = ap.AD_fk_patients LEFT JOIN Doctors d ON tv.Ap_doctor = d.ID_Doctor LEFT JOIN Office o ON tv.Ap_office = o.Of_id_office LEFT JOIN Specialisation sp ON o.Of_specialisation = sp.ID_Specialisation";

            SqlCommand query = new SqlCommand(cmd);
            DBSystem.DBSystem.SelectFromDB(dt, query);

            return dt;
        }

        public static DataTable LoadVisitDetails(string dateofvisit)
        {
            DataTable dt = new DataTable();

            string cmd = "SELECT tv.Ap_id_appoitment, tv.Ap_appoitment_day,tv.Ap_appoitment_time,p.Name + ' ' + p.Surname AS Patient, p.Pesel,o.Of_office_number,d.First_name + ' ' + d.Surname As Doctor, sp.Name FROM Term_Of_Visit tv LEFT JOIN  Appointment_details ap ON ap.AD_fk_appointments = tv.Ap_id_appoitment LEFT JOIN Patients p ON p.Id_Patients = ap.AD_fk_patients LEFT JOIN Doctors d ON tv.Ap_doctor = d.ID_Doctor LEFT JOIN Office o ON tv.Ap_office = o.Of_id_office LEFT JOIN Specialisation sp ON o.Of_specialisation = sp.ID_Specialisation WHERE tv.Ap_appoitment_day = @day";

            SqlCommand query = new SqlCommand(cmd);
            query.Parameters.AddWithValue("@day", dateofvisit);
            DBSystem.DBSystem.SelectFromDB(dt, query);

            return dt;
        }

        public static DataTable GetDetailsAppointment(DateTime day)
        {
            DataTable dt = LoadVisits();

            DataTable dt_for_day = dt.Clone();
            dt_for_day.Clear();

            foreach (DataRow row in dt.Rows)
            {
                DateTime day2 = (DateTime)row["Ap_appoitment_day"];
                if (day2 == day)
                {
                    dt_for_day.Rows.Add(row.ItemArray);
                }
            }

            dt_for_day.Columns.Remove("Ap_appoitment_day");
            dt_for_day.Columns["Ap_appoitment_time"].ColumnName = "Time of visit";
            dt_for_day.Columns["Patient"].ColumnName = "Patient";
            dt_for_day.Columns["Pesel"].ColumnName = "Pesel";
            dt_for_day.Columns["Doctor"].ColumnName = "Doctor";
            dt_for_day.Columns["Of_ffice_number"].ColumnName = "Office";

            return dt_for_day;
        }

        public static DataView FilterVisits(string Tbx_patient, string Tbx_pesel, string Tbx_date, string Tbx_specialization, string Tbx_doctor)
        {
            DataView dv = new DataView(LoadVisits());

            if (Tbx_patient != "" && Tbx_pesel != "" && Tbx_date != "" && Tbx_specialization != "" && Tbx_doctor != "")
                dv.RowFilter = string.Format("Name = '{0}' AND Surname = '{1}' AND Pesel = '{2}' AND Ap_appoitment_day = '{3}' AND Name = '{4}' AND First_name = '{5}'");
            return dv;
        }

        public static DataView SortVisits(GridViewSortEventArgs e, string Tbx_patient, string Tbx_pesel, string Tbx_date, string Tbx_specialization, string Tbx_doctor)
        {
            DataView dv = FilterVisits(Tbx_patient, Tbx_pesel, Tbx_date, Tbx_specialization, Tbx_doctor);
            dv.Sort = e.SortExpression + sortDirection;

            //changing direction of sorting
            if (sortDirection == " ASC")
                sortDirection = " DESC";
            else
                sortDirection = " ASC";

            return dv;
        }
    }
}
