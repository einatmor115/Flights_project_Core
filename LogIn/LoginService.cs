using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class LoginService : IloginService
    {
        private IAirLineDAO _arilineDAO;
        private ICustomerDAO _customerADO;

        public LoginService()
        {
            _arilineDAO = new  AirLineDAOMSSQL();
            _customerADO = new CustomerDAOMSSQL();
        }

        public bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token)
        {
            if (userName.ToUpper() == flightCenterConfig.ADMIN_NAME && password == flightCenterConfig.ADMIN_PASSWORD)
            {
                token = new LoginToken<Administrator>();
                token.User = new Administrator();
                return true;
            }
            else
            {
                //token = null;
               // return false;
                throw new WrongPasswordOrUserException();
            }
     
        }

        public bool TryAirLineLogin(string userName, string password, out LoginToken<AirlineCompany> token)
        {
            AirlineCompany company = _arilineDAO.GetAirLineByUserName(userName);

            if (password.Equals(company.Password) && company != null)
            {
                token = new LoginToken<AirlineCompany>() { User = company };
                return true;
            }
            else
            {
                try
                {
                    if (company == null)
                    {
                        token = null;
                        return false;
                    }

                    throw new WrongPasswordOrUserException();
                }
                catch (WrongPasswordOrUserException e)
                {
                    token = new LoginToken<AirlineCompany>() { User = null };
                    //token = new LoginToken<AirlineCompany>() { user = copmpany  };
                    return false;
                }
            }
        }

        public bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token)
        {
            Customer company = _customerADO.GetCustomerByUserName(userName);

            if (password.Equals(company.Password) && company != null)
            {
                token = new LoginToken<Customer>() { User = company };
                return true;
            }
            else
            {
                try
                {
                    if (company == null)
                    {
                        token = null;
                        return false;
                    }

                    throw new WrongPasswordOrUserException();
                }
                catch (WrongPasswordOrUserException e)
                {
                    token = new LoginToken<Customer>() { User = null };
                    //token = new LoginToken<AirlineCompany>() { user = copmpany  };
                    return false;
                }
            }

            //    while (userName == _customerADO.GetCustomerByUserName(userName).UserName)
            //    {
            //        if (password == _customerADO.GetCustomerByUserName(userName).Password)
            //        {
            //            token.user = new Customer();
            //            return true;
            //        }
            //        else
            //        {
            //            throw new WrongPasswordException();
            //        }
            //    }
            //    return false;
            //}
        }
    }
}
