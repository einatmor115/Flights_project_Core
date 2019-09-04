using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public interface ILoggedInAirlineFacade
    {
        IList<Ticket> GetAllTickets(LoginToken<AirlineCompany> token);
        IList<Flight> GetAllFlights(LoginToken<AirlineCompany> token);
        void CancelFlight(LoginToken<AirlineCompany> token, Flight flight);
        long CreateFlight(LoginToken<AirlineCompany> token, Flight flight);
        void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight);
        void ChangeMyPassword(LoginToken<AirlineCompany> token, AirlineCompany airlineCompany, string oldPassword, string newPassword);
        void MofidyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline);

    }
}
