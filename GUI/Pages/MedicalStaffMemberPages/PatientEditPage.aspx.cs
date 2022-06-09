using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;
using Reception;

namespace GUI.Pages.MedicalStaffMemberPages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string patientId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
            
            patientId = Request.QueryString["Id"];
            DataTable dt = Reception.Reception.LoadPatientDetails(patientId);
            
            DateTime date = (DateTime)dt.Rows[0]["Date_of_birth"];

            if (!IsPostBack)
            {
                Tbx_birthedit.Text = date.ToString("yyyy-MM-dd");
                Tbx_nameedit.Text = (string)dt.Rows[0]["Name"];
                Tbx_surnameedit.Text = (string)dt.Rows[0]["Surname"];
                Tbx_peseledit.Text = (string)dt.Rows[0]["Pesel"];
                Tbx_adressedit.Text = (string)dt.Rows[0]["Correspondence_adress"];
                Tbx_emailedit.Text = (string)dt.Rows[0]["Email"];
                Tbx_phoneedit.Text = dt.Rows[0]["Phone_number"].ToString();
                Ddl_sex.SelectedIndex = (int)dt.Rows[0]["Sex"];
            }

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListofPatients.aspx");

        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            patientId = Request.QueryString["Id"];
            int id = Convert.ToInt32(patientId);
            byte sex = byte.Parse(Ddl_sex.SelectedValue);
            DateTime dateofbirth = Convert.ToDateTime(Tbx_birthedit.Text);

            try
            {
                if (Tbx_nameedit.Text.Equals("") || !Patient.ValidateName(Tbx_nameedit.Text))
                {
                    Lbl_errorwarning.Text = "Incorrect name";
                    return;
                }
                if (Tbx_surnameedit.Text.Equals("") || !Patient.ValidateSurname(Tbx_surnameedit.Text))
                {
                    Lbl_errorwarning.Text = "Incorrect surname";
                    return;
                }
                if (Tbx_emailedit.Text.Equals("") || !Patient.ValidateEmail(Tbx_emailedit.Text))
                {
                    Lbl_errorwarning.Text = "Incorrect email adress";
                    return;
                }
                if (Tbx_peseledit.Text.Length < 11)
                {
                    Lbl_errorwarning.Text = "Empty or too short pesel number";
                    return;
                }
                if (Tbx_birthedit.Text.Equals("") || dateofbirth > DateTime.Now)
                {
                    Lbl_errorwarning.Text = "Empty or incorrect date of birth field";
                    return;
                }
                if (Tbx_phoneedit.Text.Length < 9 || !Patient.ValidatePhoneNumber(Tbx_phoneedit.Text))
                {
                    Lbl_errorwarning.Text = "Incorrect phone number";
                    return;
                }
                if (!Patient.ValidatePesel(Tbx_peseledit.Text, dateofbirth, sex))
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

            Lbl_edited.Text = "Patient edited";

            Patient patient = new Patient(Tbx_nameedit.Text, Tbx_surnameedit.Text, Tbx_peseledit.Text, sex, Tbx_emailedit.Text, Tbx_adressedit.Text, Tbx_phoneedit.Text, dateofbirth);

            patient.UpdatePatientToDb(id);
        }
    }
}