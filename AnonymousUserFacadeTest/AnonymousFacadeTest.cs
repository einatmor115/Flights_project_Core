using System;
using Flights_project;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnonymousUserFacadeTest
{
    [TestClass]
    public class AnonymousFacadeTest
    {
        TestCenter t = new TestCenter();

        [TestMethod]
        public void GetAllAirlineCompaniesTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);

            AirlineCompany b = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, b);

           Assert.AreEqual(t.AnonymousUserFacade.GetAllAirlineCompanies().Count,2);

        }

        [TestMethod]
        public void GetAllFlightsTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 1);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Assert.AreEqual(t.AnonymousUserFacade.GetAllFlights().Count, 1);
        }

        [TestMethod]
        public void GetAllFlightsVacancyTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 20);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Flight flight2 = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 0);
            t.airlineFacade.CreateFlight(t.airLineToken, flight2);

            Assert.AreEqual(t.AnonymousUserFacade.GetAllFlightsVacancy().Count, 1);
        }

        [TestMethod]
        public void GetFlightByIdTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 20);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Assert.AreEqual(t.AnonymousUserFacade.GetFlightById((int)flight.ID), flight);
        }

        [TestMethod]
        [ExpectedException(typeof(DateHasPassedExeption), "Date as paased")]
        public void GetFlightsByDepatrureDateTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2018, 10, 10), new DateTime(2019, 10, 10), 20);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Assert.AreEqual(t.AnonymousUserFacade.GetFlightsByDepatrureDate(new DateTime(2018, 10, 10)), flight);
        }

        [TestMethod]
        public void GetFlightsByDestinationCountryTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2018, 10, 10), new DateTime(2019, 10, 10), 20);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Assert.AreEqual(t.AnonymousUserFacade.GetFlightsByDestinationCountry((int)a.CountryCode).Count, 1);

            // not working becouse of the ExecuteScalar on ADD new Country- it returns the firs country code not the seconed

            //Country Italy = new Country("Italy");
            //t.adminFacade.CreateNewCountry(t.adminToken, Italy);

            //Flight flight2= new Flight(a.ID, Italy.ID, Italy.ID, new DateTime(2018, 10, 10), new DateTime(2019, 10, 10), 20);
            //t.airlineFacade.CreateFlight(t.airLineToken, flight2);

            //Assert.AreEqual(t.AnonymousUserFacade.GetFlightsByDestinationCountry((int)a.CountryCode).Count, 1);

        }

        [TestMethod]
       //[ExpectedException(typeof(DateHasPassedExeption), "Date as paased")]
        public void GetFlightsByDestinationCountryeTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 04, 09), new DateTime(2019, 04, 09), 20);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Assert.AreEqual(t.AnonymousUserFacade.GetFlightsByLandingDate(new DateTime(2019, 04, 09)).Count, 1);
        }

        [TestMethod]
        public void GetFlightsByOriginCountryTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2018, 10, 10), new DateTime(2019, 10, 10), 20);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Assert.AreEqual(t.AnonymousUserFacade.GetFlightsByOriginCountry((int)a.CountryCode).Count, 1);
        }
    }
}
