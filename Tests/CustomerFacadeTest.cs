using System;
using Flights_project;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnonymousUserFacadeTest
{
    [TestClass]
    public class CustomerFacadeTest
    {
        TestCenter t = new TestCenter();

        [TestMethod]
        public void PurchaseTicketTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken,"Israel").ID);    
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019,10,10), new DateTime(2019, 10, 10),1);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Customer c = new Customer("Einat", "Mor", "Einat123", "191919", "Katzenelson", "0545552809", "000004400");
            t.adminFacade.CreateNewCustomer(t.adminToken, c);
            t.customerToken.User = c;

            t.customerFacade.PurchaseTicket(t.customerToken, flight);
            TicketDAOMSSQL ticketDAOMSSQL = new TicketDAOMSSQL();
            Assert.AreEqual(ticketDAOMSSQL.GetAll().Count, 1);
          
        }

        [TestMethod]
        [ExpectedException(typeof(RunOutTicketsExeption), "Fligth is Sold Out. no Tickets remained")]
        public void PurchaseTicket_OutOfTickets_Test()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 0);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);

            Customer c = new Customer("Einat", "Mor", "Einat123", "191919", "Katzenelson", "0545552809", "000004400");
            t.adminFacade.CreateNewCustomer(t.adminToken, c);
            t.customerToken.User = c;

            t.customerFacade.PurchaseTicket(t.customerToken, flight);
            TicketDAOMSSQL ticketDAOMSSQL = new TicketDAOMSSQL();

        }

        [TestMethod]
        public void GetAllMyFlightsTest()
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

            Customer c = new Customer("Einat", "Mor", "Einat123", "191919", "Katzenelson", "0545552809", "000004400");
            t.adminFacade.CreateNewCustomer(t.adminToken, c);
            t.customerToken.User = c;

            t.customerFacade.PurchaseTicket(t.customerToken, flight);
            t.customerFacade.PurchaseTicket(t.customerToken, flight2);

            Assert.AreEqual(t.customerFacade.GetAllMyFlights(t.customerToken).Count, 2);

        }

        [TestMethod]
        public void CancelTicketTest()
        {
            t.ClearTables();
            t.FillDBForTest();

            AirlineCompany a = new AirlineCompany("airfrance", "airfrance", "134567", t.adminFacade.GetCountryByName(t.adminToken, "Israel").ID);
            t.adminFacade.CreateNewAirline(t.adminToken, a);
            t.airLineToken.User = a;

            Flight flight = new Flight(a.ID, a.CountryCode, a.CountryCode, new DateTime(2019, 10, 10), new DateTime(2019, 10, 10), 1);
            t.airlineFacade.CreateFlight(t.airLineToken, flight);
       
            Customer c = new Customer("Einat", "Mor", "Einat123", "191919", "Katzenelson", "0545552809", "000004400");
            t.adminFacade.CreateNewCustomer(t.adminToken, c);
            t.customerToken.User = c;

            Ticket ticket = t.customerFacade.PurchaseTicket(t.customerToken, flight);
            Assert.AreEqual(t.customerFacade.GetAllMyFlights(t.customerToken).Count, 1);
            t.customerFacade.CancelTicket(t.customerToken, ticket);
            Assert.AreEqual(t.customerFacade.GetAllMyFlights(t.customerToken).Count, 0);

        }
    }
}
