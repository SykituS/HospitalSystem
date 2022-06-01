using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public class Referrals
    {
        public string Referral { get; private set; }

        public Referrals(string referral)
        {
            Referral = referral;
        }
    }
}
