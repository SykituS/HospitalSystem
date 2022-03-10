using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBSystem;


//Klasa który trzyma funkcje dotyczące logowania się do systemu
namespace Administation
{
    public class LogSys
    {
        //Utworzenie nowego użytkownika i trzymanie go w pamięci
        static LoggedUser user = new LoggedUser();

        //Sprawdzenie czy użytkownik jest zalogowany
        public static bool CheckIfLogged()
        {
            if (!user.IsLogged)
                return false;

            return true;
        }

        //Wylogowanie użytkownika z systemu
        public static void LogoutFromSystem()
        {
            user.IsLogged = false;
        }

        //Zalogowanie użytkownika do systemu
        public static void LoginToSystem(string login, string password)
        {
            //Zmienne które będą trzymać informacje otrzymane z bazy danych
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            //Funkcaj z pliku DBSystem.dll
            //Wysłanie zmiennej DataSet, oraz jak ma się nazywać utworzona tabela która będzie trzymać informacje odnośnie:
            //loginu, hasła, emailu i stanowiska użytkownia
            //Funkcja także wysyła kwerendę SELECT która sprawdza czy podane dane przez użytkownika istnieją w bazie
            DBSystem.DBSystem.SelectFromDB(ds, "Users", "SELECT dbo.Users.US_login, dbo.users.US_Password, dbo.employee.EM_Email, dbo.Position.PO_Name " +
                "FROM dbo.Employee INNER JOIN dbo.Users ON dbo.Users.US_Employee=dbo.Employee.EM_Id_Employee INNER JOIN dbo.Position ON dbo.Employee.EM_Position = dbo.Position.PO_Id_Position " +
                "WHERE US_Login = '" + login + "' AND US_Password = '" + password + "'");

            //Przerzucenie danych z DataSet na DataTable
            dt = ds.Tables["Users"];

            //Sprawdzenie czy w DataTable są jakieś dane, jeśli nie to znaczy że w bazie nie istnieje takowy użytkownik
            if (dt.Rows.Count == 0)
                return;

            //Uzupełnienie informacji odnośnie użytkownika 
            foreach (DataRow dr in dt.Rows)
                user.setData(login, password, dr["EM_Email"].ToString(), dr["PO_Name"].ToString());

            //Zmienienie zmiennej która trzyma informację czy użytkownik jest zalogowany czy też nie
            user.IsLogged = true;
        }
    }
}
