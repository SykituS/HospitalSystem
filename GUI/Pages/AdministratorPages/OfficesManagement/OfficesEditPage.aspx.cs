using Administration;
using BusinessAdministration;
using System;

namespace GUI.Pages.AdministratorPages.OfficesManagement
{
    public partial class OfficesEditPage : System.Web.UI.Page
    {
        string officeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            officeId = Request.QueryString["Id"];

            if (!IsPostBack)
            {
                DdlSpecialization.DataSource = BusinessAdministration.OfficesManagement.LoadSpecialisation();
                DdlSpecialization.DataValueField = "ID_Specialisation";
                DdlSpecialization.DataTextField = "Name";
                DdlSpecialization.DataBind();
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            byte specialisation = Convert.ToByte(DdlSpecialization.SelectedValue);
            string plenary = DdlPlenary.SelectedValue;
            string status = DdlStatus.SelectedValue;
            string renumerated = DdlRenumerated.SelectedValue;

            Office office = new Office(specialisation, plenary, status, renumerated);

            office.UpdateOfficeToDb(Convert.ToInt32(officeId));

            LblEdited.Text = "Office edited";

            DdlSpecialization.SelectedIndex = 0;
            DdlPlenary.SelectedIndex = 0;
            DdlStatus.SelectedIndex = 0;
            DdlRenumerated.SelectedIndex = 0;
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficesManagementPage");
        }
    }
}