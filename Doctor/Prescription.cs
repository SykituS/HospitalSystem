using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public class Prescription
    {
        public string Medicine { get; private set; }
        public string Dosage { get; private set; }

        public Prescription(string medicine, string dosage)
        {
            this.Medicine = medicine;
            this.Dosage = dosage;
        }


    }
}
