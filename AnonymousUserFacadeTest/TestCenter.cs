using Flights_project;
using Flights_project.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousUserFacadeTest
{
    public class TestCenter
    {
        public LoginToken<Administrator> adminToken = new LoginToken<Administrator> { User = new Administrator { UserName = flightCenterConfig.ADMIN_NAME, Password = flightCenterConfig.ADMIN_PASSWORD } };
        public LoggedInAdministratorFacade adminFacade = new LoggedInAdministratorFacade();
        public LoginToken<AirlineCompany> airLineToken = new LoginToken<AirlineCompany>();
        public LoggedInAirlineFacade airlineFacade = new LoggedInAirlineFacade();
        public LoginToken<Customer> customerToken = new LoginToken<Customer>();
        public LoggedInCustomerFacade customerFacade = new LoggedInCustomerFacade();

        public AnonymousUserFacade AnonymousUserFacade = new AnonymousUserFacade();

        public void ClearTables()
        {
            AdminDAOMSSQL adminDAOMSSQL = new AdminDAOMSSQL();
            adminDAOMSSQL.DeleteAllTablesInfo();
        }

        public void FillDBForTest()
        {
            //Customer c = new Customer("Einat", "Mor", "Einat123", "12345", "Katzenelson", "0545552809", "123456789");
            //adminFacade.CreateNewCustomer(adminToken, c);
            Country country = new Country("Israel");
            adminFacade.CreateNewCountry(adminToken, country);
           // airLineToken.User = new AirlineCompany("Delta", "Delta", "22222", country.ID);

            //AirlineCompany a = new AirlineCompany("El_AL", "elalelal", "12345", adminFacade.GetCountryByName(adminToken, "Israel").ID);
            //adminFacade.CreateNewAirline(adminToken, a);

        }
    }
}
