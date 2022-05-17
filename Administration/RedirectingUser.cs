using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration
{
    class RedirectingUser
    {
        public static string RedirectUserIfLogged()
        {
            return null;
        }

        public static string RedirecUserIfNotLogged()
        {
            //Checking whether the user is already logged in
            if (LogSys.CheckIfLogged())
            {
                switch (MySession.Current.Position)
                {
                    case "administrator":
                        return "~/Pages/AdministratorPages/AdministratorPanelPage";
                    case "doctor":
                        return "~/Pages/Doctorspages/DoctorPanelPage";
                    case "medical clinic staff member":
                        return "~/Pages/medicalStaffMemberPages/MedicalStaffPanelPage";
                    case "patient management staff":
                        return "~/Pages/PatientManagementStaffPages/PatientManagementPanelPage";
                    case "manager":
                        return "~/Pages/ManagerPages/ManagerPanelPage";
                }
            }

            return null;
        }
    }
}
