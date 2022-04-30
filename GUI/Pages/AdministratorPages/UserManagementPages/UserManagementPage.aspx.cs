using System;
using Administration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class UserManagementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (!IsPostBack)
            {
                GridViewUsers.DataSource = UserManagement.GetUsersFromDB();
                GridViewUsers.DataBind();

            }
        }

        protected void GridViewUsers_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewUsers.Rows[index];

            Button btn = (Button)e.CommandSource;

            if (e.CommandName == "ChangeStatus")
            {
                GridViewUsers.DataSource = UserManagement.UpdateUserStatus(row.Cells[0].Text, btn.Text);
                GridViewUsers.DataBind();
            }

            if (e.CommandName == "EditUser")
            {
                Console.Write(e.CommandName);
            }
        }
    }
}