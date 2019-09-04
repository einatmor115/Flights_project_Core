using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class Ticket : IPoco
    {
        public long ID { get; set; }
        public long FlightID { get; set; }
        public long CustomerID { get; set; }

        public Ticket()
        {
        }

        public Ticket( long flightID, long customerID)
        {
            FlightID = flightID;
            CustomerID = customerID;
        }

        public override bool Equals(object obj)
        {
            var ticket = obj as Ticket;
            if (ReferenceEquals(obj, null))
                return false;

            return this.ID == ticket.ID;

            //if (obj == null)
            //{
            //    return false;
            //}
            //if (obj is Ticket == false)
            //{
            //    return false;
            //}
            //return this == obj as Ticket;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public static bool operator ==(Ticket a, Ticket b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }

            return a.Equals(b);
        }

        public static bool operator !=(Ticket a, Ticket b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $" ID: {ID}, FlightID:{FlightID}, CustomerID:{CustomerID}";


        }
    }
}
