using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.MainPages
{
    public partial class DebbugPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelSelectTimeToUnlock.Text = "time to unlock: " + DebbugingClassDB.GetTime();

            GVUsers.DataSource = DebbugingClassDB.SelectInformation();
            GVUsers.DataBind();
        }

        protected void BtnSendUpdate_Click(object sender, EventArgs e)
        {
            LabelInfo.Text = DebbugingClassDB.UpdatedEmail(TBlogin.Text, TBEmail.Text);
        }

        protected void GVUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBlogin.Text = GVUsers.SelectedRow.Cells[0].Text;
            TBEmail.Text = GVUsers.SelectedRow.Cells[1].Text;
            CheckBoxIsDuringReset.Checked = bool.Parse(GVUsers.SelectedRow.Cells[2].Text);
        }
    }
}