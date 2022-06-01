using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GUI.Pages.AdministratorPages.OfficesManagement;

namespace BusinessAdminTest
{
    [TestClass]
    public class OfficeAddTest
    {
        [TestMethod]
        public void RoomNumberValidationTest()
        {
            var officeAdd = new OfficesAddPage();
            object[] parameters = new object[1] { "120" };
            PrivateObject obj = new PrivateObject(officeAdd);

            var returnValue = obj.Invoke("IsRoomNumberValid", parameters);

            Assert.IsTrue((bool)returnValue);
        }
    }
}
