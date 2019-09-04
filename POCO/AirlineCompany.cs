using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class AirlineCompany : IUser, IPoco
    {
        public long ID { get; set; }
        public string AirlineName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long CountryCode { get; set; }

        public AirlineCompany()
        {
        }

        public AirlineCompany(string airlineName, string userName, string password, long countryCode)
        {
           
            AirlineName = airlineName;
            UserName = userName;
            Password = password;
            CountryCode = countryCode;
        }

        public override string ToString()
        {
            return $"Id: {ID}, AirlineName: {AirlineName}, UserName: {UserName}, Password: {Password}, CountryCode: {CountryCode}";
        }

        public override bool Equals(object obj)
        {
            var AirlineCompany = obj as AirlineCompany;
            if (ReferenceEquals(obj, null))
                return false;

            return this.ID == AirlineCompany.ID;

            //if (obj == null)
            //{
            //    return false;
            //}
            //if (obj is AirlineCompany == false)
            //{
            //    return false;
            //}
            //return this == obj as AirlineCompany;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public static bool operator ==(AirlineCompany a, AirlineCompany b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }

            return a.Equals(b);
        }

        public static bool operator !=(AirlineCompany a, AirlineCompany b)
        {
            return !(a == b);
        }
    }
}
