using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade
    {
        public IList<AirlineCompany> GetAllAirlineCompanies()
        {
            IList<AirlineCompany> airlineCompanies;
            Flights_project.AirLineDAOMSSQL dao = new AirLineDAOMSSQL();
            airlineCompanies = dao.GetAll();
            return airlineCompanies;
        }

        public IList<Flight> GetAllFlights()
        {
            IList<Flight> flights;
            Flights_project.FlightDAOMSSQL dao = new FlightDAOMSSQL();
            flights = dao.GetAll();
            return flights;
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            Dictionary<Flight, int> flightDic = new Dictionary<Flight, int>();

            Flights_project.FlightDAOMSSQL dao = new FlightDAOMSSQL();
            flightDic = dao.GetAllFlightsVacancy();
            return flightDic;
        }

        public Flight GetFlightById(int id)
        {
            Flights_project.Flight flight = new Flights_project.Flight(); 
            Flights_project.FlightDAOMSSQL dao = new FlightDAOMSSQL();
            flight = dao.GetFlightById(id);
            return flight;
        }

        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            if (departureDate > DateTime.Now)
            {
                IList<Flight> flights;
                Flights_project.FlightDAOMSSQL dao = new FlightDAOMSSQL();
                flights = dao.GetFlightsByDepatureDate(departureDate);
                return flights;
            }
            else
            {
                throw new DateHasPassedExeption();
            }
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            IList<Flight> flights;
            Flights_project.FlightDAOMSSQL dao = new FlightDAOMSSQL();
            flights = dao.GetFlightsByDestinationCountry(countryCode);
            return flights;
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            if (landingDate < DateTime.Now)
            {
                IList<Flight> flights;
                Flights_project.FlightDAOMSSQL dao = new FlightDAOMSSQL();
                flights = dao.GetFlightsByLandingDate(landingDate);
                return flights;
            }
            else
            {
                throw new DateHasPassedExeption();
            }
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            IList<Flight> flights;
            Flights_project.FlightDAOMSSQL dao = new FlightDAOMSSQL();
            flights = dao.GetFlightsByOriginCountry(countryCode);
            return flights;
        }
    }
}
