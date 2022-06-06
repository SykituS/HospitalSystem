using System;
using Administration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class EditUserPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string result = ResetPassSys.PasswordValidation(Tbnewpass.Text, Tbconpass.Text);

            if (result.Equals("OK"))
            {
                MySession.Current.TempPass = Tbnewpass.Text;
                Response.Redirect("UserEditPage.aspx?Id=" + MySession.Current.TempLogin);
            }
            else
            {
               
                //showing what went wrong with validation
                LabelCriteria.Text = result;
            }
           

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEditPage.aspx?Id=" + MySession.Current.TempLogin);
        }
    }
}