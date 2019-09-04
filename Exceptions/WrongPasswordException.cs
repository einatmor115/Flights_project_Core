using System;
using System.Runtime.Serialization;

namespace Flights_project
{
    [Serializable]
    public class WrongPasswordOrUserException : ApplicationException
    {
        public WrongPasswordOrUserException()
        {
        }

        public WrongPasswordOrUserException(string message) : base(message)
        {
        }

        public WrongPasswordOrUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongPasswordOrUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}