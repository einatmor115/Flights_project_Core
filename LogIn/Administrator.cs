using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class Administrator : IUser
    {
        public string UserName;
        public string Password;

        public Administrator()
        {

        }

        public Administrator(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
