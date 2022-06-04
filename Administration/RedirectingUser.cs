using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration
{
    public class RedirectingUser
    {
        public static string RedirectUser(string activeURL, bool isChecked)
        {
            if (!LogSys.CheckIfLogged())
                return "~/Pages/MainPages/Default";


            if (URLLibrary(activeURL))
                return activeURL;

            string site = RedirectToCorrespondingSite();
            return RedirectToCorrespondingSite();
        }

        private static string RedirectToCorrespondingSite()
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
                default:
                    return "";
            }
        }

        private static bool URLLibrary(string activeURL)
        {
            string[] path = activeURL.Split('/');
            switch (MySession.Current.Position)
            {
                case "administrator":
                    if (path[2].Contains("AdministratorPages"))
                        return true;
                    return false;
                case "doctor":
                    if (path[2].Contains("DoctorsPages"))
                        return true;
                    return false;
                case "medical clinic staff member":
                    if (path[2].Contains("MedicalStaffMemberPages"))
                        return true;
                    return false;
                case "patient management staff":
                    if (path[2].Contains("PatientManagementStaffPages"))
                        return true;
                    return false;
                case "manager":
                    if (path[2].Contains("ManagerPages"))
                        return true;
                    return false;

                default:
                    return false;
            }

        }
    }
}
