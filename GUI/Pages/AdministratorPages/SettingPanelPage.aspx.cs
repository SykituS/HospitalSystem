using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Administration;

namespace GUI.Pages.AdministratorPages.SettingsPages
{
    public partial class SettingPanelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                TBTimeToUnlock.Text = (SettingsPanel.ShowTime() / 60).ToString();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministratorPanelPage");
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            int time = int.Parse(TBTimeToUnlock.Text);
            SettingsPanel.TimeSet(time);
        }
    }
}