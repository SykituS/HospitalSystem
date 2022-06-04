using System;
using System.Security.Cryptography;
using System.Text;

namespace Administration
{
    public class PasswordHashing
    {
        public static string hashPassword(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            byte[] encryptedBytes = sha1.ComputeHash(passwordBytes);
            return Convert.ToBase64String(encryptedBytes);
        }

    }
}
