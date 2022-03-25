using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sprawdzenie czy strona nie została odświeżona
            if (!this.IsPostBack)
                CancelUnexpectedRePost();

            //Checking whether the user is already logged in
            if (LogSys.CheckIfLogged())
            {
                if (LogSys.CheckPosition())
                    Response.Redirect("~/Pages/AdministratorPages/AdministratorPage");

                Response.Redirect("~/Pages/EmployeePages/EmployeePage");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //Anuluj skutki uboczne odświeżenia strony
            CancelUnexpectedRePost();

            //Starting the login process 
            LogSys.LoginToSystem(TBLogin.Text, TBPassword.Text);

            //Checking whether the user has successfully logged in
            if (LogSys.CheckIfLogged())
            {
                if (LogSys.CheckPosition())
                    Response.Redirect("~/Pages/AdministratorPages/AdministratorPage");

                Response.Redirect("~/Pages/EmployeePages/EmployeePage");
            }

            int attempt = MySession.Current.Attempt;
            if (attempt > 1)
            {
                attempt--;
                MySession.Current.Attempt = attempt;
                LabelWarnings.Visible = true;
                LabelWarnings.Text = LogSys.GetAttempTextTry();
            }
            else
            {
                attempt--;
                MySession.Current.Attempt = attempt;
                LabelWarnings.Text = LogSys.GetAttempTextTry();
                BtnLogin.Enabled = false;
                TBPassword.Enabled = false;
                TBLogin.Enabled = false;
                Session["Timer"] = DateTime.Now.AddMinutes(1).ToString();
                LabelWarnings.Visible = false;
            }
        }

        protected void BtnResetPassword_Click(object sender, EventArgs e)
        {
            //Przenieisienie do strony z prośbą o aplikowanie o zmianę hasła
            Response.Redirect("FormToResetPassPage.aspx");
        }

        private void CancelUnexpectedRePost()
        {
            int attempt = 3;

            if (attempt < 3)
            {
                LabelWarnings.Visible = true;
                LabelWarnings.Text = LogSys.GetAttempTextTry();
            }
            /*  Funkcja która zapobiega efektom ubocznym odświeżenia strony
             *  Przy pierwszym uruchomieniu client code jak i server code przy tworzeniu są puste
             *  Fukcja Guid tworzy nowy "rejestr" strony
            */


            string clientCode = _repostcheckcode.Value;

            string serverCode = Session["_repostcheckcode"] as string;

            //Sprawdż czy strona nie została odświeżona lub czy string clientCode jest równy stringowi serverCode
            if (!IsPostBack || clientCode.Equals(serverCode))
            {
                //Utwórz stringa z aktualnym rejestrem strony
                string code = Guid.NewGuid().ToString(); 

                //Zapisz tego stringa w wartościach poniżej
                _repostcheckcode.Value = code;
                Session["_repostcheckcode"] = code;
            }
            else
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int attempt = (int)MySession.Current.Attempt;
            if (attempt == 0)
            {
                int seconds = (Int32)(DateTime.Parse(Session["Timer"].ToString()).Subtract(DateTime.Now).TotalSeconds + 0.5);
                if (seconds >= 0)
                {
                    string textTime = string.Format(" {0}m {1}s", seconds / 60, seconds % 60);
                    LabelWarnings.Text = LogSys.GetAttempTextBlock(textTime);
                    litMsg.Text = LogSys.GetAttempTextBlock(textTime);

                }
                else
                {
                    Session["redirect"] = "yes";
                    LabelWarnings.Text = "";
                    MySession.Current.Attempt = 3;

                    BtnLogin.Enabled = true;
                    TBPassword.Enabled = true;
                    TBLogin.Enabled = true;
                    Response.Redirect(Request.Url.AbsoluteUri);

                }
            }
        }
    }
}