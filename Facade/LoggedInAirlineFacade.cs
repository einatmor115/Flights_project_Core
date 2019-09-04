using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null && token.User != null)
            {
                _flightDAO.Remove(flight);
                List<Ticket> FlitghtTickets = _ticketDAO.GetAllTicketsByFlight(flight);
                for (int i = 0; i < FlitghtTickets.Count; i++)
                {
                    _ticketDAO.Remove(FlitghtTickets[i]);
                }
            }
        }

        public void ChangeMyPassword(LoginToken<AirlineCompany> token, AirlineCompany airline, string oldPassword, string newPassword)
        {
            if (token != null && token.User != null)
            {
                if (airline.Password == oldPassword)
                {
                    airline.Password = newPassword;
                    _airlineDAO.Update(airline);
                }
            }
   
        }

        public long CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            long flightId = 0;

            if (token != null && token.User != null)
            {
                flight.ID = _flightDAO.Add(flight);
                flightId = flight.ID;
            }
            return flightId;
        }

        public IList<Flight> GetAllFlights(LoginToken<AirlineCompany> token)
        {
           IList<Flight> CompanyFlights = new List<Flight>(); 

            if (token != null && token.User != null)
            {
                IList<Flight> flights = _flightDAO.GetAll();
                for (int i = 0; i < flights.Count; i++)
                {
                    if(flights[i].AirLineCompanyID == token.User.ID)
                    {
                        CompanyFlights.Add(flights[i]);
                    }
                }
            }
            return CompanyFlights;
        }

        public IList<Ticket> GetAllTickets(LoginToken<AirlineCompany> token)
        {
            IList<Ticket> CompanyTickets = null;
            if (token != null && token.User != null)
            {
                CompanyTickets = _airlineDAO.GetAllAirLineCompanyTickets((int)token.User.ID);
            }           
            return CompanyTickets;
        }

        public void MofidyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline)
        {
            if (token != null && token.User != null)
            {
                    _airlineDAO.Update(airline);
            }
        }

        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null && token.User != null)
            {
                _flightDAO.Update(flight);
            }
        }
       
    }
}
