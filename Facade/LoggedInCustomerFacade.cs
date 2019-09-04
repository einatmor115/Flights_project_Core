using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            if (token.User is Customer)
            {
                _ticketDAO.Remove(ticket);
            }
        }

        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token)
        {
            IList<Flight> customerFlights = null;

            if (token.User is Customer)
            {
                customerFlights = _flightDAO.GetFlightsByCustomer(token.User);
            }
            return customerFlights;
        }

        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            Ticket t = new Ticket(flight.ID, token.User.ID);
            if (flight.RemainingTickets > 0)
            {
                if (token.User is Customer)
                {                 
                    t.ID = _ticketDAO.Add(t);
                    flight.RemainingTickets = flight.RemainingTickets - 1;
                    _flightDAO.Update(flight);
                }
            }
            else
            {
                throw new RunOutTicketsExeption();
            }
            return t;
        }

    }
}
