using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public abstract class FacadeBase
    {
        protected IAirLineDAO _airlineDAO;
        protected ICountryDAO _countryDAO;
        protected ICustomerDAO _customerDAO;
        protected IFlightDAO _flightDAO;
        protected ITicketDAO _ticketDAO;

        protected FacadeBase()
        {
            _airlineDAO = new AirLineDAOMSSQL();
            _countryDAO = new CountryDAOMSSQL();
            _customerDAO = new CustomerDAOMSSQL();
            _flightDAO = new FlightDAOMSSQL();
            _ticketDAO = new TicketDAOMSSQL();
        }
    }
}
