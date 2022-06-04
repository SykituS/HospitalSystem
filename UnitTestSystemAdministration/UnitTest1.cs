using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSystemAdministration
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodIDPAS0401()
        {
            /*Correct data: user enters two passwords that are the same and they match the acceptance criteria*/

            //arrange
            string newPassword = "123zaq1@WSX";
            string confirmNewPassword = "123zaq1@WSX";

            //act
            var result = Administration.ResetPassSys.PasswordValidation(newPassword, confirmNewPassword);

            //assert
            Assert.AreEqual("OK", result);

        }

        [TestMethod]
        public void TestMethodIDPAS0402()
        {
            /*Correct data: user enter two passwords that are the same and they match the acceptance criteria*/

            //arrange
            string newPassword = "123zaq1@WSX4567";
            string confirmNewPassword = "123zaq1@WSX4567";

            //act
            var result = Administration.ResetPassSys.PasswordValidation(newPassword, confirmNewPassword);

            //assert
            Assert.AreEqual("OK", result);
        }

        [TestMethod]
        public void TestMethodIDPAS0403()
        {
            /*Incorrect data: user enters two passwords that are not the same*/

            //arrange
            string newPassword = "123";
            string confirmNewPassword = "1234";

            //act
            var result = Administration.ResetPassSys.PasswordValidation(newPassword, confirmNewPassword);

            //assert
            Assert.AreEqual("Passwords must be this same", result);
        }

        [TestMethod]
        public void TestMethodIDPAS0404()
        {
            /*Incorrect data: user enters two passwords that are the same but they are not matching the acceptance criteria - 
             * the password is too short (less than 8 characters)*/

            //arrange
            string newPassword = "qwertyu";
            string confirmNewPassword = "qwertyu";

            //act
            var result = Administration.ResetPassSys.PasswordValidation(newPassword, confirmNewPassword);

            //assert
            Assert.AreEqual("Incorrect password length", result);
        }

        [TestMethod]
        public void TestMethodIDPAS0405()
        {
            /*Incorrect data: user enters two passwords that are the same but they are not matching the acceptance criteria - 
             * the password is too long (more than 15 characters)*/

            //arrange
            string newPassword = "qwertyuiopasdfgh";
            string confirmNewPassword = "qwertyuiopasdfgh";

            //act
            var result = Administration.ResetPassSys.PasswordValidation(newPassword, confirmNewPassword);

            //assert
            Assert.AreEqual("Incorrect password length", result);
        }

        [TestMethod]
        public void TestMethodIDPAS0406()
        {
            /*Incorrect data: user enters two passwords that are the same but they are not matching the acceptance criteria - the lack of a lowercase character*/

            //arrange
            string newPassword = "PASSW0RD!";
            string confirmNewPassword = "PASSW0RD!";

            //act
            var result = Administration.ResetPassSys.PasswordValidation(newPassword, confirmNewPassword);

            //assert
            Assert.AreEqual("Password must include at least one lowercase, uppercase, number and special character (-, _, !, #, $, *)", result, "test");
        }

        [TestMethod]
        public void TestMethodIDPAS0407()
        {
            /*Incorrect data: user enters two passwords that are the same but they are not matching the acceptance criteria - the lack of an uppercase character*/

            //arrange
            string newPassword = "hasl0-haslo";
            string confirmNewPassword = "hasl0-haslo";

            //act
            var result = Administration.ResetPassSys.PasswordValidation(newPassword, confirmNewPassword);

            //assert
            Assert.AreEqual("Password must include at least one lowercase, uppercase, number and special character (-, _, !, #, $, *)", result);
        }

        [TestMethod]
        public void TestMethodIDPAS0408()
        {
            /*Incorrect data: user enters two passwords that are the same but they are not matching the acceptance criteria - the lack of a number*/

            //arrange
            string newPassword = "Password_";
            string confirmNewPassword = "Password_";

            //act
            var result = Administration.ResetPassSys.PasswordValidation(newPassword, confirmNewPassword);

            //assert
            Assert.AreEqual("Password must include at least one lowercase, uppercase, number and special character (-, _, !, #, $, *)", result);
        }

        [TestMethod]
        public void TestMethodIDPAS0409()
        {
            /*Incorrect data: user enters two passwords that are the same but they are not matching the acceptance criteria - the lack of a special character*/

            //arrange
            string newPassword = "1234Zaq1";
            string confirmNewPassword = "1234Zaq1";

            //act
            var result = Administration.ResetPassSys.PasswordValidation(newPassword, confirmNewPassword);

            //assert
            Assert.AreEqual("Password must include at least one lowercase, uppercase, number and special character (-, _, !, #, $, *)", result);
        }
    }
}
