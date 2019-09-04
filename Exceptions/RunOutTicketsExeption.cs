using System;
using System.Runtime.Serialization;

namespace Flights_project
{
    [Serializable]
    public class RunOutTicketsExeption : ApplicationException
    {
        public RunOutTicketsExeption()
        {
        }

        public RunOutTicketsExeption(string message) : base(message)
        {
        }

        public RunOutTicketsExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RunOutTicketsExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}