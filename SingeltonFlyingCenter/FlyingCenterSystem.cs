using Flights_project.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flights_project
{
    public class FlyingCenterSystem
    {
        private static FlyingCenterSystem _instance;
        private static object key = new object();

        private FlyingCenterSystem()
        {
            CleaningDataFacade f = new CleaningDataFacade();
            Task.Run(() => {
                while(true)
                {
                    //same job as the facade - so why do i need this here?
                    f.CleanData();
                    Thread.Sleep(flightCenterConfig.SleepingTime);
                }
            });
        }

        public static FacadeBase Login(string userName, string password, out LoginTokenBase login, out FacadeBase userFacade)
        {           
            LoginService loginService = new LoginService();
            LoginToken<Administrator> tokenAdmin;
            LoginToken<AirlineCompany> airLineToken;
            LoginToken<Customer> customerToken;

            if (loginService.TryAdminLogin(userName, password, out tokenAdmin))
            {
                login = tokenAdmin;
                userFacade = new AnonymousUserFacade();
            }
            else if (loginService.TryAirLineLogin(userName, password, out airLineToken))
            {
                login = airLineToken;
                userFacade = new LoggedInAirlineFacade();
            }
            else if (loginService.TryCustomerLogin(userName, password, out customerToken))
            {
                login = customerToken;
                userFacade = new LoggedInCustomerFacade();
            }
            else
            {
                throw new WrongPasswordOrUserException();
            }

            userFacade = new AnonymousUserFacade();
            login = null;
            return null;
        }

        public static FlyingCenterSystem GetInstance()
        {
            if (_instance == null)
            {
                lock (key)
                {
                    if (_instance == null)
                    {
                        _instance = new FlyingCenterSystem();
                    }
                }
            }
            return _instance;
        }

    }
}
