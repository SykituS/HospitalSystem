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
            CancelUnexpectedRePost();

            LabelSelectTimeToUnlock.Text = "time to unlock: " + DebbugingClassDB.GetTime();

            GVUsers.DataSource = DebbugingClassDB.SelectInformation();
            GVUsers.DataBind();
        }

        protected void BtnSendUpdate_Click(object sender, EventArgs e)
        {
            LabelInfo.Text = DebbugingClassDB.UpdateEmail(TBlogin.Text, TBEmail.Text) + " \n" + DebbugingClassDB.UpdateInformation(TBlogin.Text, DateTime.Parse(TBDate.Text), CheckBoxIsDuringReset.Checked);

            GVUsers.DataSource = DebbugingClassDB.SelectInformation();
            GVUsers.DataBind();
        }

        protected void GVUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBlogin.Text = GVUsers.SelectedRow.Cells[0].Text;
            TBEmail.Text = GVUsers.SelectedRow.Cells[1].Text;
            CheckBoxIsDuringReset.Checked = bool.Parse(GVUsers.SelectedRow.Cells[2].Text);
            TBDate.Text = GVUsers.SelectedRow.Cells[3].Text;
        }

        private void CancelUnexpectedRePost()
        {
            /* Function that prevents side effect of page refreshing 
             * On the first start-up both clientCode and serverCode are empty
             * The Guid function creates a new "register" of the page
            */

            string clientCode = _repostcheckcode.Value;

            string serverCode = Session["_repostcheckcode"] as string;

            //Checking whether the page has not been refreshed or whether the clientCode string equals serverCode string
            if (!IsPostBack || clientCode.Equals(serverCode))
            {
                //Creating a string with the current page register
                string code = Guid.NewGuid().ToString();

                //Inserting the string above into the values below
                _repostcheckcode.Value = code;
                Session["_repostcheckcode"] = code;
            }
            else
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}