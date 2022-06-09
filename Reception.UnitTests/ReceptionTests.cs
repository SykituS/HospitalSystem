using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reception.UnitTests
{
    [TestClass]
    public class ReceptionTest
    {
        [TestMethod]
        public void NameUnitTest()
        {
            string name = "John";
            Boolean expected = true;
            Boolean actual = Patient.ValidateName(name);

            Assert.AreEqual(expected, actual, "The result of the test is not compatible with expectations");
        }

        [TestMethod]
        public void SurnameUnitTest()
        {
            string surname = "Scott";
            Boolean expected = true;
            Boolean actual = Patient.ValidateName(surname);

            Assert.AreEqual(expected, actual, "The result of the test is not compatible with expectations");
        }

        [TestMethod]      
        public void EmailUnitTest()
        {
            string email = "test@test.com";
            Boolean expected = true;
            Boolean actual = Patient.ValidateEmail(email);

            Assert.AreEqual(expected, actual, "The result of the test is not compatible with expectations");
        }

        [TestMethod]
        public void PhoneUnitTest()
        {
            string phone = "111222333";
            Boolean expected = true;
            Boolean actual = Patient.ValidatePhoneNumber(phone);

            Assert.AreEqual(expected, actual, "The result of the test is not compatible with expectations");
        }

        [TestMethod]
        public void PeselUnitTest()
        {
            string pesel = "00010128675";
            DateTime birth = new DateTime(1900, 01, 01);
            byte sex = 1;
            Boolean expected = true;
            Boolean actual = Patient.ValidatePesel(pesel, birth, sex);

            Assert.AreEqual(expected, actual, "The result of the test is not compatible with expectations");
        }
        
    }
}
