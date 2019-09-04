using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    interface IloginService
    {
        bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token);
        bool TryAirLineLogin(string userName, string password, out LoginToken<AirlineCompany> token);
        bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token);
    }
}
