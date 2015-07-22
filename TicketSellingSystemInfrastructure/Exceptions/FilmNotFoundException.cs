using System;
using TicketSellingSystemInfrastructure.Constants;

namespace TicketSellingSystemInfrastructure.Exceptions
{
    [Serializable]
    public class FilmNotFoundException : Exception
    {
        public FilmNotFoundException():base(ErrorMessages.FilmNotFound)
        {
        }

        public FilmNotFoundException(string message) : base(message)
        {
        }

        public FilmNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FilmNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}