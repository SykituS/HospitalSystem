using System;
using Administration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class UserDetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (!IsPostBack)
            { 
                MySession.Current.TempLogin = Request.QueryString["Id"];
                //Adding data to the gridView
                GridViewUsers.DataSource = UserDetails.GetUsersFromDB();
                GridViewUsers.DataBind();
              

            }
        }

        protected void Btneddit_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEditPage.aspx?Id=" + MySession.Current.TempLogin);

        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserManagementPage");
        }
    }
}