using System;
using System.Runtime.Serialization;

namespace Flights_project
{
    [Serializable]
    public class DateHasPassedExeption : ApplicationException
    {
        public DateHasPassedExeption()
        {
        }

        public DateHasPassedExeption(string message) : base(message)
        {
        }

        public DateHasPassedExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DateHasPassedExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}