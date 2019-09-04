using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade
    {
        public long CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            long airlineID = 0;

            if (token != null && token.User != null )
            {
                airlineID = _airlineDAO.Add(airline);
                airline.ID = airlineID;
            }
            return airlineID;
        }
        
        public long CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            long custID = 0;

            if (token != null && token.User != null )
            {
                custID = _customerDAO.Add(customer);
                customer.ID = custID;
            }
            return custID;
        }

        public long CreateNewCountry(LoginToken<Administrator> token, Country country)
        {
            long countryID = 0;

            if (token != null && token.User is Administrator)
            {
                //_countryDAO.Add(country);
                countryID = _countryDAO.Add(country);
                country.ID = countryID;
            }
            return countryID;
        }

        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token.User is Administrator && token != null)
            {
                _airlineDAO.Remove(airline);
            }
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {

            if (token != null && token.User != null)
            {
                _customerDAO.Remove(customer);
            }
        }

        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token != null && token.User != null)
            {
                _airlineDAO.Update(airline);
            }
        }

        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null && token.User != null)
            {
                _customerDAO.Update(customer);
            }
        }

        public Country GetCountryByName(LoginToken<Administrator> token, string name)
        {
            if (token != null && token.User != null)
            {
                CountryDAOMSSQL countryDAOMSSQL = new CountryDAOMSSQL();
                return countryDAOMSSQL.GetCountryByName(name);
            }
            return null;
        }

        public Customer GetCustomerByName(LoginToken<Administrator> token, string name)
        {
            if (token != null && token.User != null)
            {
                CustomerDAOMSSQL customerDAOMSSQL = new CustomerDAOMSSQL();
                return customerDAOMSSQL.GetCustomerByName(name);
            }
            return null;
        }

        public AirlineCompany GetAirLineByUserName(LoginToken<Administrator> token, string name)
        {
            if (token != null && token.User != null)
            {
                AirLineDAOMSSQL airLineDAOMSSQL = new AirLineDAOMSSQL();
                return airLineDAOMSSQL.GetAirLineByUserName(name);
            }
            return null;
        }

    }
}
