using Administration;
using System;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.SpecializationManagementPages
{
    public partial class SpecializationManagementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (!IsPostBack)
            {
                GridViewSpecialization.DataSource = SpecializationManagement.GetSpecializationList();
                GridViewSpecialization.DataBind();
            }

            GridViewSpecialization.Columns[0].Visible = false;
        }

        protected void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
        }

        protected void GridViewSpecialization_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewSpecialization.Rows[index];
            MySession.Current.TempID = int.Parse(row.Cells[0].Text);
            if (e.CommandName == "Edit")
            {
                MySession.Current.TempAction = "Edit";
                MySession.Current.TempSpecTextOriginal = row.Cells[1].Text;
                Response.Redirect("SpecializationDetailsPage.aspx");
            }

            if (e.CommandName == "Delete")
            {
                MySession.Current.TempAction = "Delete";
                MySession.Current.TempSpecText = row.Cells[1].Text;
                MySession.Current.TempSpecTextOriginal = row.Cells[1].Text;

                MySession.Current.TempRedirectText = "Are you sure you want to remove this specialization ? This change cannot be undone!";
                Response.Redirect("SpecializationConfirmPage.aspx");
            }
        }

        protected void BtnAddNewSpecialization_Click(object sender, EventArgs e)
        {
            MySession.Current.TempAction = "Add";
            MySession.Current.TempSpecTextOriginal = "";
            Response.Redirect("SpecializationDetailsPage.aspx");
        }
    }
}