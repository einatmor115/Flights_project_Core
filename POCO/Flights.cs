using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class Flight : IPoco
    {
        public long ID { get; set; }
        public long AirLineCompanyID { get; set; }
        public long OriginCountryCode { get; set; }
        public long DestinationCountryCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
        public int RemainingTickets { get; set; }

        public Flight()
        {
        }

        public Flight( long airLineCompanyID, long originCountryCode, long destinationCountryCode, DateTime departureTime, DateTime landingTime, int remainingTickets)
        {
            
            AirLineCompanyID = airLineCompanyID;
            OriginCountryCode = originCountryCode;
            DestinationCountryCode = destinationCountryCode;
            DepartureTime = departureTime;
            LandingTime = landingTime;
            RemainingTickets = remainingTickets;
        }

        public override bool Equals(object obj)
        {
            var flight = obj as Flight;
            if (ReferenceEquals(obj, null))
                return false;

            return this.ID == flight.ID;

            //if (obj == null)
            //{
            //    return false;
            //}
            //if (obj is Flight == false)
            //{
            //    return false;
            //}
            //return this == obj as Flight;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public static bool operator ==(Flight a, Flight b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }

            return a.Equals(b);
        }

        public static bool operator !=(Flight a, Flight b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $" airLineCompanyID: {AirLineCompanyID}, originCountryCode:{OriginCountryCode}," +
                $" destinationCountryCode:{DestinationCountryCode},departureTime: {DepartureTime}," +
                $" landingTime: {LandingTime}, remainingTickets: {RemainingTickets}";

        }
    }
}
