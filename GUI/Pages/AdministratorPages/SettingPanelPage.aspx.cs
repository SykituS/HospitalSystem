using Administration;
using System;

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

            if (time >= 0)
            {
                SettingsPanel.TimeSet(time);
                LabelWarning.Visible = true;
                LabelWarning.Text = "The time to unlock page has been changed";
            }
            else
            {
                LabelWarning.Visible = true;
                LabelWarning.Text = "Please select a correct value!";
            }
        }
    }
}