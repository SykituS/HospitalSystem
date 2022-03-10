using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administation
{
    class LoggedUser
    {
        bool isLogged = false; //Variable that stores information about whether the user is logged into the system or not
        int attempt = 3;
        string login;
        string password;
        string email;
        string position;

        public bool IsLogged { get => isLogged; set => isLogged = value; }
        public int Attempt { get => attempt; set => attempt = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Position { get => position; set => position = value; }

        //Constructor
        public void setData(string login, string password, string email, string postion)
        {
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.Position = position;
        }
    }
}
