﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administation
{
    class LoggedUser
    {
        bool isLogged = false; //varible to keep track if user should be logged to the system
        string login;
        string password;
        string email;
        string position;


        public bool IsLogged { get => isLogged; set => isLogged = value; }
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
