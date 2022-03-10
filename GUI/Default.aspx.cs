using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administation;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sprawdzenie czy użytkownik jest już zalogowany w systemie
            if (LogSys.CheckIfLogged())
                Response.Redirect("About.aspx");
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //Rozpoczęcie procesu logowania 
            LogSys.LoginToSystem(TBLogin.Text, TBPassword.Text);

            //Sprawdzenie czy użytkownik pomyślnie się zalogował
            if (LogSys.CheckIfLogged())
                Response.Redirect("About.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //Anulowanie procesu logowania
            TBLogin.Text = "";
            TBPassword.Text = "";
        }
    }
}