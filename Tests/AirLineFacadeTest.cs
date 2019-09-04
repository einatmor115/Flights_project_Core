using System;
using System.Collections.Generic;
using System.Linq;
using AnonymousUserFacadeTest;
using Autofac.Extras.Moq;
using Flights_project;
using Flights_project.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FacadeTest
{
    [TestClass]
    public class AirLineFacadeTest
    {
        TestCenter t = new TestCenter();

        [TestMethod]

        public void CreateFlightTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            long airlineID = t.adminFacade.CreateNewAirline(t.adminToken, a);
            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 1);
            t.airLineToken.User = a;
            t.airlineFacade.CreateFlight(t.airLineToken, flight);
            Assert.AreEqual(t.adminFacade.GetAllFlights().Count, 1);
        }

        [TestMethod]

        public void CancelFlightTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            long airlineID = t.adminFacade.CreateNewAirline(t.adminToken, a);
            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 1);
            t.airLineToken.User = a;
            t.airlineFacade.CreateFlight(t.airLineToken, flight);
            Assert.AreEqual(t.adminFacade.GetAllFlights().Count, 1);

            t.airlineFacade.CreateFlight(t.airLineToken, flight);
            Assert.AreNotEqual(t.adminFacade.GetAllFlights().Count, 1);
        }

        [TestMethod]

        public void ChangeMyPasswordTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            long airlineID = t.adminFacade.CreateNewAirline(t.adminToken, a);          
            t.airLineToken.User = a;
            t.airlineFacade.ChangeMyPassword(t.airLineToken, a, "134567", "PasswordChangeed");
            Assert.AreEqual(t.adminFacade.GetAirLineByUserName(t.adminToken, "airfrance").Password, "PasswordChangeed");

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

            Flight flight2 = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 1);
            t.airlineFacade.CreateFlight(t.airLineToken, flight2);

            Assert.AreEqual(t.adminFacade.GetAllFlights().Count, 2);

        }

        [TestMethod]

        public void GetAllTicketsTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Customer c = new Customer("Einat", "Mor", "Einat123", "191919", "Katzenelson", "0545552809", "000004400");
            t.customerToken.User = c;
            t.adminFacade.CreateNewCustomer(t.adminToken, c);

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 1);
            t.airLineToken.User = a;
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Ticket ticket = new Ticket(flight.ID, c.ID);
            TicketDAOMSSQL ticketDAOMSSQL = new TicketDAOMSSQL();
            ticketDAOMSSQL.Add(ticket);

            Assert.AreEqual(t.airlineFacade.GetAllTickets(t.airLineToken).Count, 1);
        }

        [TestMethod]

        public void MofidyAirlineDetailsTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;
            a.UserName = "UserNameChange";
            Assert.AreEqual(t.adminFacade.GetAirLineByUserName(t.adminToken, "airfrance"), a);
            t.airlineFacade.MofidyAirlineDetails(t.airLineToken, a);
            Assert.AreNotEqual(t.adminFacade.GetAirLineByUserName(t.adminToken, "airfrance"), a);
        }

        [TestMethod]

        public void UpdateFlightTest()
        {
            t.ClearTables();
            t.FillDBForTest();
            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 1);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);
            flight.RemainingTickets = 0;
            t.airlineFacade.UpdateFlight(t.airLineToken,flight);
            Assert.AreEqual(t.airlineFacade.GetFlightById((int)flight.ID), flight);

        }
    }
}
