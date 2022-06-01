using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GUI;

namespace BusinessAdminTest
{
    [TestClass]
    public class EmployeeAddTest
    {
        [TestMethod]
        public void EmailNameValidationTest()
        {
            var employeeAdd = new EmployeeAddPage();
            object[] parameters = new object[2] { "adam.kowalski@gmail.com", "adAm" };
            PrivateObject obj = new PrivateObject(employeeAdd);

            var returnValue = obj.Invoke("IsEmailNameValid", parameters);

            Assert.IsTrue((bool)returnValue);
        }

        [TestMethod]
        public void EmailDomainValidationTest()
        {
            var employeeAdd = new EmployeeAddPage();
            object[] parameters = new object[1] { "adam.kowalski@eksocmed.com" };
            PrivateObject obj = new PrivateObject(employeeAdd);

            var returnValue = obj.Invoke("IsEmailDomainValid", parameters);

            Assert.IsTrue((bool)returnValue);
        }

        [TestMethod]
        public void PeselBirthValidationTest()
        {
            var employeeAdd = new EmployeeAddPage();
            object[] parameters = new object[2] { "01020812345", Convert.ToDateTime("08/02/2001") };
            PrivateObject obj = new PrivateObject(employeeAdd);

            var returnValue = obj.Invoke("IsPeselBirthValid", parameters);

            Assert.IsTrue((bool)returnValue);
        }

        [TestMethod]
        public void PeselSexValidationTest()
        {
            var employeeAdd = new EmployeeAddPage();
            object[] parameters = new object[2] { "01020912305", 2 };
            PrivateObject obj = new PrivateObject(employeeAdd);

            var returnValue = obj.Invoke("IsPeselSexValid", parameters);

            Assert.IsTrue((bool)returnValue);
        }

        [TestMethod]
        public void PhoneNumberValidationTest()
        {
            var employeeAdd = new EmployeeAddPage();
            object[] parameters = new object[1] { "567342823" };
            PrivateObject obj = new PrivateObject(employeeAdd);

            var returnValue = obj.Invoke("IsPhoneNumberValid", parameters);

            Assert.IsTrue((bool)returnValue);
        }
    }
}
