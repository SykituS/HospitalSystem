using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    class Appoitment
    {
        private DateTime Appoitment_start;
        private DateTime Appoitment_end;
        private string Patient;
        private string Office;

        private static List<Appoitment> List_of_appoitments = new List<Appoitment>();

        public Appoitment(DateTime appoitment_start, DateTime appoitment_end, string patient, string office)
        {
            this.Appoitment_start = appoitment_start;
            this.Appoitment_end = appoitment_end;
            this.Patient = patient;
            this.Office = office;
        }

        public static void fill_list_of_appoitments(DateTime appoitment_start, DateTime appoitment_end, string patient, string office)
        {
            if (List_of_appoitments.Count > 0)
            {
                clear_list();
            }
        
            List_of_appoitments.Add(new Appoitment(appoitment_start, appoitment_end, patient, office));
        }

        public static List<Appoitment> Get_List_Of_Appoitments()
        {
            return List_of_appoitments;
        }

        public static void clear_list()
        {
            List_of_appoitments.Clear();
        }

    }
}
