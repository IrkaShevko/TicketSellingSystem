using System;
using System.Runtime.Serialization;
using TicketSellingSystemInfrastructure.Constants;

namespace TicketSellingSystemInfrastructure.Exceptions
{
    [Serializable]
    public class BadModelException : Exception
    {
        public BadModelException():base(ErrorMessages.BadModel)
        {
        }

        public BadModelException(string message) : base(message)
        {
        }

        public BadModelException(string message, Exception inner) : base(message, inner)
        {
        }

        protected BadModelException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}