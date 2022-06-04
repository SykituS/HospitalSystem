using Administration;
using BusinessAdministration;
using System;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class OfficesManagementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (!IsPostBack)
            {
                GvOffices.DataSource = OfficesManagement.LoadOffices();
                GvOffices.DataBind();
            }
        }

        protected void GvOffices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvOffices.Rows[index];
                Response.Redirect("OfficesConfirmDelete?Room=" + row.Cells[1].Text);
            }

            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvOffices.Rows[index];
                Response.Redirect("OfficesEditPage?Id=" + row.Cells[0].Text);
            }
        }

        protected void BtnBackToMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
        }

        protected void BtnAddNewOffice_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficesAddPage");
        }
    }
}