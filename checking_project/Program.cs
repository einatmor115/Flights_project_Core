using Flights_project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checking_project
{
    class Program
    {
        static void Main(string[] args)
        {
            //*************************************  CUSTOMER CLASS  ***************************************

            // ******* Add ********
            //Flights_project.Customer cust = new Flights_project.Customer("Roy", "Mor", "roy", "5656", "Hata'as 10 Givatayim", "0545556329", "334466778891");
            //Flights_project.CustomerDAOMSSQL customerDAOMSSQL = new Flights_project.CustomerDAOMSSQL();
            //customerDAOMSSQL.Add(cust);

            // ******* Get ********
            //Flights_project.Customer c = customerDAOMSSQL.Get(4);
            // Console.WriteLine(c.FirstName, c.LastName, c.ID, c.Password,  c.Address, c.CreditCardNumber,c);

            // ******* GetALL ********
            //IList<Flights_project.Customer> Allcust =  customerDAOMSSQL.GetAll();
            //for (int i = 0; i < Allcust.Count; i++)
            //{
            //    Console.WriteLine(Allcust[i].ToString());
            //}

            //****** GET_CUSTOMER_BY_USER_NAME ******
            //Flights_project.Customer cust = customerDAOMSSQL.GetCustomerByUserName("roy");
            //cust.LastName = "levy";
            //Console.WriteLine(cust);

            //****** [REMOVE_CUSTOMER] ******
            //customerDAOMSSQL.Remove(cust);

            //****** [UPDATE_CUSTOMER] ******
            //customerDAOMSSQL.Update(cust);

            //******************************************************************************************************
            //******************************************************************************************************
            //******************************************************************************************************

            //*************************************  COUNTRY CLASS  ***************************************

            //Flights_project.CountryDAOMSSQL countryDAOMSSQL = new Flights_project.CountryDAOMSSQL();
            //Flights_project.Country Italy = new Flights_project.Country("Italy");
            //Flights_project.Country Spain = new Flights_project.Country("Spain");

            // ******* Add ********
            //countryDAOMSSQL.Add(Italy);
            //countryDAOMSSQL.Add(Spain);

            // ******* Get ********
            //Flights_project.Country c = countryDAOMSSQL.Get(8);
            //Console.WriteLine(c);

            //******* GetALL ********
            //IList <Flights_project.Country> list = countryDAOMSSQL.GetAll();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //******* remove ********
            //countryDAOMSSQL.Remove(c);

            //******* Update ********
            //c.CountryName = "German";
            //countryDAOMSSQL.Update(c);

            //******************************************************************************************************
            //******************************************************************************************************
            //******************************************************************************************************

            //*************************************  AIRLINE CLASS  ***************************************

            //Flights_project.AirLineDAOMSSQL airLineDAOMSSQL = new Flights_project.AirLineDAOMSSQL();
            //Flights_project.AirlineCompany Iberia = new Flights_project.AirlineCompany("Iberia", "Iberia", "2323", 16);

            // ******* Add ********
            //airLineDAOMSSQL.Add(Iberia);

            // ******* Get ********
            //Flights_project.AirlineCompany a = airLineDAOMSSQL.Get(6);
            //Console.WriteLine(a);

            //******* GetALL ********
            //IList<Flights_project.AirlineCompany> list = airLineDAOMSSQL.GetAll();       
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //******* GetAirLineByCountry ********
            //List< Flights_project.AirlineCompany> a = airLineDAOMSSQL.GetAirLineByCountry(16);
            //for (int i = 0; i < a.Count; i++)
            //{
            //    Console.WriteLine(a[i]);
            //}

            //******* [GET_AIR_LINE_BY_USER_NAME] ********
            //Flights_project.AirlineCompany a = airLineDAOMSSQL.GetAirLineByUserName("AIR_FRANCE");
            //Console.WriteLine(a);

            //******* remove ********
            //airLineDAOMSSQL.Remove(a);

            //******* Update ********
            //a.AirlineName = "IBERIA";
            //a.UserName = "IBERIA";
            //airLineDAOMSSQL.Update(a);
            //countryDAOMSSQL.Update(c);

            //******************************************************************************************************
            //******************************************************************************************************
            //******************************************************************************************************


            //*************************************  FLIGHT CLASS  ***************************************

            //Flights_project.FlightDAOMSSQL flightDAOMSSQL = new Flights_project.FlightDAOMSSQL();
            //DateTime D = new DateTime(2019, 7, 3, 23, 00, 00);
            //DateTime L = new DateTime(2019, 7, 4, 07, 00, 00);
            //Flights_project.Flight T5325 = new Flights_project.Flight(6, 16, 8, D, L, 543);

            // ******* Add ********
            //flightDAOMSSQL.Add(T5325);

            // ******* Get ********
            //Flights_project.Flight f = flightDAOMSSQL.GetFlightById(7);
            //Console.WriteLine(f);

            //******* GetALL ********
            //IList<Flights_project.Flight> list = flightDAOMSSQL.GetAll();       
            //for (int i = 0; i < list.Count; i++)
            //{
            //   Console.WriteLine(list[i]);
            //}

            //******* [GET_ALL_FLIGHT_VACANCY] ********
            //Dictionary<Flights_project.Flight, int> list = flightDAOMSSQL.GetAllFlightsVacancy();
            //foreach (KeyValuePair<Flights_project.Flight, int> fly in list)
            //{
            //    Console.WriteLine($"key:{fly.Key}, value:{fly.Value}");
            //}  

            //******* GetFlightById ********
            //Flights_project.Flight f = flightDAOMSSQL.GetFlightById(6);
            //Console.WriteLine(f);

            //******* GetFlightsByCustomer ********
            //List<Flights_project.Flight> cust_flights = flightDAOMSSQL.GetFlightsByCustomer(c);
            //for (int i = 0; i < cust_flights.Count; i++)
            //{
            //    Console.WriteLine(cust_flights[i]);
            //}

            //******* GetFlightsByDepatureDate ********
            //List<Flights_project.Flight> cust_flights = flightDAOMSSQL.GetFlightsByDepatureDate(D);
            //for (int i = 0; i < cust_flights.Count; i++)
            //{
            //    Console.WriteLine(cust_flights[i]);
            //}

            //******* GetFlightsByDestinationCountry ********
            //List<Flights_project.Flight> cust_flights = flightDAOMSSQL.GetFlightsByDestinationCountry(1);
            //for (int i = 0; i < cust_flights.Count; i++)
            //{
            //    Console.WriteLine(cust_flights[i]);
            //}

            //******* GetFlightsByLandingDate ********
            //List<Flights_project.Flight> cust_flights = flightDAOMSSQL.GetFlightsByLandingDate(D);
            //for (int i = 0; i < cust_flights.Count; i++)
            //{
            //    Console.WriteLine(cust_flights[i]);
            //}

            //******* GetFlightsByOriginCountry ********
            //List<Flights_project.Flight> cust_flights = flightDAOMSSQL.GetFlightsByOriginCountry(1);
            //for (int i = 0; i < cust_flights.Count; i++)
            //{
            //    Console.WriteLine(cust_flights[i]);
            //}

            //******* remove ********
            //flightDAOMSSQL.Remove(f);

            //******* Update ********
            //f.OriginCountryCode = 14;
            //flightDAOMSSQL.Update(f);

            //******************************************************************************************************
            //******************************************************************************************************
            //******************************************************************************************************

            //******************************************************************************************************
            //******************************************************************************************************
            //******************************************************************************************************

            //*************************************  Tickets CLASS  ***************************************

            //Flights_project.TicketDAOMSSQL ticketDAOMSSQL = new Flights_project.TicketDAOMSSQL();
            //Flights_project.Ticket ticket = new Flights_project.Ticket(7, 4);

            // ******* Add ********
            //ticketDAOMSSQL.Add(ticket);

            // ******* Get ********
            //Flights_project.Ticket t = ticketDAOMSSQL.Get(10);
            //Console.WriteLine(t);

            //******* GetALL ********
            //IList<Flights_project.Ticket> list = ticketDAOMSSQL.GetAll();       
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //******* remove ********
            //ticketDAOMSSQL.Remove(t);

            //******* Update ********
            //t.FlightID = 


            //******************************************************************************************************
            //******************************************************************************************************
            //******************************************************************************************************

            /// ************************* LOGIN ************************
            /// 

            //Flights_project.LoginService login = new Flights_project.LoginService(airLineDAOMSSQL, customerDAOMSSQL);
            //Flights_project.LoginToken<Flights_project.AirlineCompany> loginTken = new Flights_project.LoginToken<Flights_project.AirlineCompany>();

            //login.TryAirLineLogin("ELAL", "1111", out loginTken);

            /// ************************* anonymous facade ************************
            /// 

            //Flights_project.AnonymousUserFacade anonymousUserFacade = new Flights_project.AnonymousUserFacade();
            //IList<Flights_project.AirlineCompany> airlineCompanies = anonymousUserFacade.GetAllAirlineCompanies();
            //for (int i = 0; i < airlineCompanies.Count; i++)
            //{
            //    Console.WriteLine(airlineCompanies[i].AirlineName);
            //}

            //Flights_project.AnonymousUserFacade anonymoususerfacade = new Flights_project.AnonymousUserFacade();
            //IList<Flights_project.Flight> flights = anonymoususerfacade.GetAllFlights();
            //for (int i = 0; i < flights.Count; i++)
            //{
            //    Console.WriteLine(flights[i].AirLineCompanyID.ToString() + flights[i].RemainingTickets);
            //}

            //LoggedInAdministratorFacade loggedInAdministratorFacade = new LoggedInAdministratorFacade();
            //Country c = new Country("Israel");
            //LoginToken<Administrator> login = new LoginToken<Administrator>();
            //login.User = new Administrator(flightCenterConfig.ADMIN_NAME, flightCenterConfig.ADMIN_PASSWORD);
            //c.ID = loggedInAdministratorFacade.CreateNewCountry(login,c);
            //Console.WriteLine(c);

        }
    }
}
