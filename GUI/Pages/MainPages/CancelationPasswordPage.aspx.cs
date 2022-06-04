using Administration;
using System;

namespace GUI.Pages.MainPages
{
    public partial class CancelationPasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            ResetPassSys.StatusUpdate(MySession.Current.Login, DateTime.Now, false);
            MySession.Current.Login = null;
            MySession.Current.Email = null;
            Response.Redirect("Default");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetPassPage?login=" + MySession.Current.Login + "&email=" + MySession.Current.Email);
        }
    }
}