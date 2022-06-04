using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSystemAdministration
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethodIDPAS0101()
        {
            /*Correct data format: user entered the login and an e-mail address with exactly one '@' character.*/

            //arrange
            string email = "lmartin@eksoc.com";

            //act
            var result = Administration.EmailSendingClass.IsValidEmail(email);

            //assert
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void TestMethodIDPAS0102()
        {
            /*Incorrect data format: user entered the login and an e-mail address that didn't have exactly one '@' character.*/

            //arrange
            string email = "";

            //act
            var result = Administration.EmailSendingClass.IsValidEmail(email);

            //assert
            Assert.AreEqual(false, result, "Incorrect data format: user entered the login and an e-mail address that didn't have exactly one '@' character.");

        }

        [TestMethod]
        public void TestMethodIDPAS0103()
        {
            /*Incorrect data format: user entered the login and an e-mail address that didn't have exactly one '@' character.*/

            //arrange
            string email = "lmartin@@eksoc.com";

            //act
            var result = Administration.EmailSendingClass.IsValidEmail(email);

            //assert
            Assert.AreEqual(false, result, "Incorrect data format: user entered the login and an e-mail address that didn't have exactly one '@' character.");

        }

        [TestMethod]
        public void TestMethodIDPAS0104()
        {
            /*Incorrect data format: user entered the login and an e-mail address that didn't have exactly one '@' character.*/

            //arrange
            string email = "lmartin@eksoc@com";

            //act
            var result = Administration.EmailSendingClass.IsValidEmail(email);

            //assert
            Assert.AreEqual(false, result, "Incorrect data format: user entered the login and an e-mail address that didn't have exactly one '@' character.");

        }
    }
}
