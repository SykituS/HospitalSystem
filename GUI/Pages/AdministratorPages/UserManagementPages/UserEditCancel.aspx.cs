using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class UserEditSave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
            Lbquestion.Text = "Do you want to leave Edit Page without saving changes?";

        }

        protected void Btnaccept_Click(object sender, EventArgs e)
        {
            EditUser.ClearEdit();
            Response.Redirect("UserDetailsPage.aspx?Id=" + MySession.Current.TempLogin);
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEditPage.aspx?Id=" + MySession.Current.TempLogin);
        }
    }
}