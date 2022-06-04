using System;

namespace GUI.Pages.MainPages
{
    public partial class InvalidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MainPages/Default");
        }
    }
}