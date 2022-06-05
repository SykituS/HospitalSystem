using Administration;
using System;

namespace GUI.Pages.AdministratorPages.SpecializationManagementPages
{
    public partial class SpecializationConfirmPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelText.Text = MySession.Current.TempRedirectText;
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {

            if (MySession.Current.TempAction == "Delete")
            {
                SpecializationManagement.UpdateSpecialization();
            }

            SpecializationManagement.SpecSesionClear();
            Response.Redirect("SpecializationManagementPage");


        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MySession.Current.TempAction == "Edit" ||
                MySession.Current.TempAction == "Add")
            {

                Response.Redirect("SpecializationDetailsPage");
            }
            SpecializationManagement.SpecSesionClear();
            Response.Redirect("SpecializationManagementPage");
        }
    }
}