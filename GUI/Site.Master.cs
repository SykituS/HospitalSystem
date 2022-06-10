using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LabelPositionMasterInfo.Visible = false;

                if (LogSys.CheckIfLogged())
                {
                    LabelPositionMasterInfo.Visible = true;
                    LabelPositionMasterInfo.Text = "You are logged as: \n " + MySession.Current.Position;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Pages/MainPages/Default");
            }
        }
    }
}