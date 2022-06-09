using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.SpecializationManagementPages
{
    public partial class SpecializationDetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
            if (!IsPostBack)
            {

                if (MySession.Current.TempID != null)
                    TBName.Text = SpecializationManagement.GetSpecializationName();

                if (!string.IsNullOrEmpty(MySession.Current.TempSpecText))
                    TBName.Text = MySession.Current.TempSpecText;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (!SpecializationManagement.Validation(TBName.Text))
            {
                LabelWaring.Text = "The specialty name cannot contain numbers or special characters";
                LabelWaring.Visible = true;
                return;
            }
            MySession.Current.TempSpecText = TBName.Text;

            if (MySession.Current.TempAction == "Add")
            {
                SpecializationManagement.AddNewSpecialization();
                SpecializationManagement.SpecSesionClear();
                Response.Redirect("SpecializationManagementPage");

                return;
            }

            if (MySession.Current.TempAction == "Edit")
            {
                SpecializationManagement.UpdateSpecialization();
                SpecializationManagement.SpecSesionClear();
                Response.Redirect("SpecializationManagementPage");

                return;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (TBName.Text.Length > 0 && (!MySession.Current.TempSpecTextOriginal.Equals(TBName.Text)))
            {
                MySession.Current.TempSpecText = TBName.Text;
                MySession.Current.TempRedirectText = "You left changes that are unsaved! Are you sure you want to leave this page?";
                Response.Redirect("SpecializationConfirmPage");
            } else
            {
                SpecializationManagement.SpecSesionClear();
                Response.Redirect("SpecializationManagementPage");
            }
        }
    }
}