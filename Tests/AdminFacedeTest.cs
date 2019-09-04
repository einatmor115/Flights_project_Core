using System;
using Flights_project;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnonymousUserFacadeTest
{
    [TestClass]
    public class AdminFacedeTest
    {
        TestCenter t = new TestCenter();

        [TestMethod]
        public void CreateNewAirlineTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            Assert.AreEqual(t.adminFacade.GetAllAirlineCompanies().Count, 1);
            //Assert.AreEqual(airlineID, a.ID);
            //Assert.AreEqual(t.adminFacade.GetAirLineById(t.adminToken,t.adminFacade.GetAirLineById()).Count,1);       
        }

        [TestMethod]
        public void CreateNewCustomerTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            Customer c = new Customer("Einat", "Mor", "Einat123", "191919", "Katzenelson", "0545552809", "000004400");
            long customerID = t.adminFacade.CreateNewCustomer(t.adminToken, c);
            Assert.AreEqual(t.adminFacade.GetCustomerByName(t.adminToken,"Einat").Address, "Katzenelson");
        }

        [TestMethod]
        public void CreateNewCountryTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            Country c = new Country("France");
            long countryID = t.adminFacade.CreateNewCountry(t.adminToken, c);
            Assert.AreEqual(t.adminFacade.GetCountryByName(t.adminToken, "France").CountryName, "France");
         
        }

        [TestMethod]
        public void RemoveAirLineTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            long airlineID = t.adminFacade.CreateNewAirline(t.adminToken, a);
            // im not sure its the correct way to update the object id after i create it in the SQL
            // i need to update it somhow in the code do i do it here or in facade?  (like note in create Country)
            a.ID = airlineID;
            Assert.AreEqual(t.adminFacade.GetAllAirlineCompanies().Count, 1);
            t.adminFacade.RemoveAirline(t.adminToken, a);
            Assert.AreEqual(t.adminFacade.GetAllAirlineCompanies().Count, 0);
        }

        [TestMethod]
        public void RemoveCustomerTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            Customer c = new Customer("Einat", "Mor", "Einat123", "191919", "Katzenelson", "0545552809", "000004400");
            long customerID = t.adminFacade.CreateNewCustomer(t.adminToken, c);
            c.ID = customerID;
            Assert.AreEqual(t.adminFacade.GetCustomerByName(t.adminToken,"Einat").FirstName, "Einat");
            t.adminFacade.RemoveCustomer(t.adminToken, c);
            Assert.AreEqual(t.adminFacade.GetCustomerByName(t.adminToken,"Einat").UserName, null);
        }

        [TestMethod]
        public void UpdateAirlineDetailsTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            long airlineID = t.adminFacade.CreateNewAirline(t.adminToken, a);            
            Assert.AreEqual(t.adminFacade.GetAirLineByUserName(t.adminToken,"airfrance"),a);
            a.UserName = "111111";
            Assert.AreEqual(t.adminFacade.GetAirLineByUserName(t.adminToken, "airfrance"), a);
            t.adminFacade.UpdateAirlineDetails(t.adminToken, a);
            Assert.AreNotEqual(t.adminFacade.GetAirLineByUserName(t.adminToken, "airfrance"), a);
        }

        [TestMethod]
        public void UpdateCustomerDetailsTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            Customer c = new Customer("Einat", "Mor", "Einat123", "191919", "Katzenelson", "0545552809", "000004400");
            long customerID = t.adminFacade.CreateNewCustomer(t.adminToken, c);
            Assert.AreEqual(t.adminFacade.GetCustomerByName(t.adminToken, "Einat"),c);
            c.FirstName = "111111";
            Assert.AreEqual(t.adminFacade.GetCustomerByName(t.adminToken, "Einat"), c);
            t.adminFacade.UpdateCustomerDetails(t.adminToken, c);
           Assert.AreNotEqual(t.adminFacade.GetCustomerByName(t.adminToken, "Einat"), c);
        }

        [TestMethod]
        public void GetCountryByNameTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            Country c = new Country("Israel");
            long countryID = t.adminFacade.CreateNewCountry(t.adminToken, c);         
            Assert.AreEqual(t.adminFacade.GetCountryByName(t.adminToken, "Israel"), c);
        }
    }
}
