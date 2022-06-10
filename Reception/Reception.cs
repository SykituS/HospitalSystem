using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Reception
{
    public class Reception
    {
        //defines default direction of sorting - ascending
        static string sortDirection = " ASC";
        public static DataTable LoadPats(bool check = false)
        {
            DataTable dt = new DataTable();

            //a query which returns data about patients from the database 
            //string cmd = "SELECT p.Id_Patients, p.Name, p.Surname, p.Pesel, p.Sex, p.Date_of_birth, p.Correspondence_adress, p.Email, p.Phone_number, tv.Ap_appoitment_day FROM Patients p LEFT JOIN Appointment_details ad ON ad.AD_fk_patients = p.Id_Patients LEFT JOIN Term_Of_Visit tv ON tv.Ap_id_appoitment = ad.AD_fk_appointments";
            //string cmd = "SELECT p.Id_Patients, p.Name, p.Surname, p.Pesel, p.Sex, p.Date_of_birth, p.Correspondence_adress, p.Email, p.Phone_number, tv.Ap_appoitment_day, st.St.St_Status_Name FROM Patients p LEFT JOIN Appointment_details ad ON ad.AD_fk_patients = p.Id_Patients LEFT JOIN Term_Of_Visit tv ON tv.Ap_id_appoitment = ad.AD_fk_appointments LEFT JOIN Status st ON st.St_Id_Status = p.Active";
            string cmd = "SELECT p.Id_Patients, p.Name, p.Surname, p.Pesel, p.Sex, p.Date_of_birth, p.Correspondence_adress, p.Email, p.Phone_number, tv.Ap_appoitment_day, st.St_Status_Name FROM Patients p LEFT JOIN Appointment_details ad ON ad.AD_fk_patients = p.Id_Patients LEFT JOIN Term_Of_Visit tv ON tv.Ap_id_appoitment = ad.AD_fk_appointments LEFT JOIN Status st ON p.Active = st.St_Id_Status";
            if (check)
            {
                //cmd = "SELECT p.Id_Patients, p.Name, p.Surname, p.Pesel, p.Sex, p.Date_of_birth, p.Correspondence_adress, p.Email, p.Phone_number, tv.Ap_appoitment_day FROM Patients p LEFT JOIN Appointment_details ad ON ad.AD_fk_patients = p.Id_Patients LEFT JOIN Term_Of_Visit tv ON tv.Ap_id_appoitment = ad.AD_fk_appointments ORDER BY  tv.Ap_appoitment_day DESC";
                cmd = "SELECT p.Id_Patients, p.Name, p.Surname, p.Pesel, p.Sex, p.Date_of_birth, p.Correspondence_adress, p.Email, p.Phone_number, tv.Ap_appoitment_day, st.St_Status_Name FROM Patients p LEFT JOIN Appointment_details ad ON ad.AD_fk_patients = p.Id_Patients LEFT JOIN Term_Of_Visit tv ON tv.Ap_id_appoitment = ad.AD_fk_appointments LEFT JOIN Status st ON p.Active = st.St_Id_Status ORDER BY tv.Ap_appoitment_day DESC";
            }
            //hooking a query

            SqlCommand query = new SqlCommand(cmd);

            //downloading data from database and adding it to DataTable
            DBSystem.DBSystem.SelectFromDB(dt, query);

            return dt;
        }

        public static DataTable Patients()
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT Id_Patients, Name + ' ' + Surname AS Patient FROM dbo.Patients ";
            SqlCommand query = new SqlCommand(cmd);

            DBSystem.DBSystem.SelectFromDB(dt, query);
            return dt;
        }

        public static DataTable Doctors()
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT ID_Doctor, First_Name + ' ' + Surname AS Doctor FROM dbo.Doctors";
            //string cmd = "SELECT d.First_name+'  '+d.Surname FROM Doctors d, Specialisation s Where d.ID_Specialisation = s.ID_Specialisation AND s.Name = @spec";
            SqlCommand query = new SqlCommand(cmd);
            //query.Parameters.AddWithValue("@spec", specialization);
            DBSystem.DBSystem.SelectFromDB(dt, query);
            return dt;
        }

        public static DataTable Specialization()
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT * FROM dbo.Specialisation";
            SqlCommand query = new SqlCommand(cmd);

            DBSystem.DBSystem.SelectFromDB(dt, query);
            return dt;
        }

        public static DataTable Office()
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT * FROM dbo.Office";
            SqlCommand query = new SqlCommand(cmd);

            DBSystem.DBSystem.SelectFromDB(dt, query);
            return dt;
        }

        public static DataTable LoadPatientDetails(string patientId)
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT p.Name, p.Surname, p.Pesel, p.Sex, p.Date_of_birth, p.Correspondence_adress, p.Email, p.Phone_number, st.St_Status_Name FROM Patients p INNER JOIN Sex s ON p.Sex = s.Sx_Id_Status INNER JOIN Status st ON p.Active = st.St_Id_Status WHERE p.Id_Patients = @Id";
            SqlCommand query = new SqlCommand(cmd);
            query.Parameters.AddWithValue("@Id", patientId);

            DBSystem.DBSystem.SelectFromDB(dt, query);

            return dt;
        }

        public static int GetPatientStatus(int id)
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT Active FROM dbo.Patients WHERE Id_Patients = @Id";
            SqlCommand query = new SqlCommand(cmd);
            query.Parameters.AddWithValue("@Id", id);

            DBSystem.DBSystem.SelectFromDB(dt, query);

            int status = int.Parse((string)dt.Rows[0][0]);

            return status;
        }

        
        //Filtering data by name, surname and pesel
        public static DataView FilterDataView(string Tbx_name, string Tbx_surname, string Tbx_pesel, bool check)
        {
            DataView dv = new DataView(LoadPats(check));


            //considering every possibility of filtering data
            if (Tbx_name != "" && Tbx_surname != "" && Tbx_pesel != "")
                dv.RowFilter = string.Format("Name = '{0}' AND Surname = '{1}' AND Pesel = '{2}'", Tbx_name, Tbx_surname, Tbx_pesel);
            else if (Tbx_pesel != "")
                dv.RowFilter = string.Format("Pesel = '{0}'", Tbx_pesel);
            else if (Tbx_name != "")
                dv.RowFilter = string.Format("Name = '{0}'", Tbx_name);
            else if (Tbx_surname != "")
                dv.RowFilter = string.Format("Surname = '{0}'", Tbx_surname);
            else if (Tbx_name != "" && Tbx_surname != "")
                dv.RowFilter = string.Format("Name = '{0}' AND Surname = '{1}'", Tbx_name, Tbx_surname);
            else if (Tbx_name != "" && Tbx_pesel != "")
                dv.RowFilter = string.Format("Name = '{0}' AND Pesel = '{1}'", Tbx_name, Tbx_pesel);
            else if (Tbx_surname != "" && Tbx_pesel != "")
                dv.RowFilter = string.Format("Surname = '{0}' AND Pesel = '{1}'", Tbx_surname, Tbx_pesel);

            return dv;
        }



        //Sorting data by name, surname and pesel number
        public static DataView SortDataView(GridViewSortEventArgs e, string Tbx_name, string Tbx_surname, string Tbx_pesel, bool check)
        {
            DataView dv = FilterDataView(Tbx_name, Tbx_surname, Tbx_pesel, check);
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
