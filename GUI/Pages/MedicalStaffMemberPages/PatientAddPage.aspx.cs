using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;
using Reception;

namespace GUI.Pages.MedicalStaffMemberPages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");


        }

        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListofPatients.aspx");
        }

        protected void Btn_addpatient_Click(object sender, EventArgs e)
        {
            byte sex = byte.Parse(Ddl_sex.SelectedValue);
            DateTime dateofbirth = Convert.ToDateTime(Tbx_birthadd.Text);

            //string result i if czy result ok czy nie ok blad zakoncz a jak git to dalej

            try
            {
                if (Tbx_nameadd.Text.Equals("") || !Patient.ValidateName(Tbx_nameadd.Text))
                {
                    Lbl_errorwarning.Text = "Incorrect name";
                    return;
                }
                if (Tbx_surnameadd.Text.Equals("") || !Patient.ValidateSurname(Tbx_surnameadd.Text))
                {
                    Lbl_errorwarning.Text = "Incorrect surname";
                    return;
                }
                if (Tbx_emailadd.Text.Equals("") || !Patient.ValidateEmail(Tbx_emailadd.Text))
                {
                    Lbl_errorwarning.Text = "Incorrect email adress";
                    return;
                }
                if (Tbx_peseladd.Text.Length < 11)
                {
                    Lbl_errorwarning.Text = "Empty or too short pesel number";
                    return;
                }
                if (Tbx_birthadd.Text.Equals("") || dateofbirth > DateTime.Now)
                {
                    Lbl_errorwarning.Text = "Empty or incorrect date of birth field";
                    return;
                }
                if (Tbx_phoneadd.Text.Length < 9 || !Patient.ValidatePhoneNumber(Tbx_phoneadd.Text))
                {
                    Lbl_errorwarning.Text = "Incorrect phone number";
                    return;
                }
                if(!Patient.ValidatePesel(Tbx_peseladd.Text, dateofbirth, sex))
                {
                    Lbl_errorwarning.Text = "Pesel does not match date of birth or gender";
                    return;
                }
                //return ok
                
            }
            catch (Exception)
            {
                Lbl_errorwarning.Text = "Error";
                return;
            }

            Lbl_added.Text = "Patient added";

            Patient patient = new Patient(Tbx_nameadd.Text, Tbx_surnameadd.Text, Tbx_peseladd.Text, sex, Tbx_emailadd.Text, Tbx_adressadd.Text, Tbx_phoneadd.Text, dateofbirth);

            patient.AddPatientToDb();

        }

        
    }
}