using System;
using Flights_project;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnonymousUserFacadeTest
{
    [TestClass]
    public class LoginServiceTest
    {
        TestCenter t = new TestCenter();
        LoginService L = new LoginService();

        [TestMethod]
        [ExpectedException(typeof(WrongPasswordOrUserException), "Wrong Password Or User Name")]
        public void TryAdminLoginTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            L.TryAdminLogin("Admin", "1111", out LoginToken<Administrator> Token);
        }

        [TestMethod]
        public void TryAirLineLoginTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);

            Assert.AreEqual(L.TryAirLineLogin("airfrance", "1", out LoginToken<AirlineCompany> Air), false);
        }

        [TestMethod]
        public void TryCustomerLoginTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            Customer c = new Customer("Einat", "Mor", "Einat123", "191919", "Katzenelson", "0545552809", "000004400");
            t.adminFacade.CreateNewCustomer(t.adminToken, c);

            Assert.AreEqual(L.TryCustomerLogin("Einat","0", out LoginToken<Customer> cust), false);
        }
    }
}
