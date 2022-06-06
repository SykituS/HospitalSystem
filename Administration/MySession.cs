using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Administration
{
    public class MySession
    {
        private MySession()
        {
            Attempt = 3;
            IsLogged = false;
        }

        //gets the current session
        public static MySession Current
        {
            get
            {
                MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }
        
        public int Status { get; set; }
        public bool IsLogged { get; set; }
        public int Attempt { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int SetTime { get; set; }
        public int IdEmployee { get; set; }
        public int ForcedPasswordChange { get; set; }

        //Temp varibles
        public string TempPass { get; set; }
        public string TempLogin { get; set; }
        public string TempStatus { get; set; }
        public string EmployeeName { get; set; }
        public int FirstLoad { get; set; }

        public int? TempID { get; set; } //temp varible for id from specialization
        public string TempSpecTextOriginal { get; set; }
        public string TempSpecText { get; set; }

        public string TempRedirectText { get; set; }
        public string TempAction { get; set; }
    }
}
