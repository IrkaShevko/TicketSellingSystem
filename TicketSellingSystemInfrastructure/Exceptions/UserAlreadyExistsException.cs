using System;
using TicketSellingSystemInfrastructure.Constants;

namespace TicketSellingSystemInfrastructure.Exceptions
{
    [Serializable]
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException():base(ErrorMessages.UserAlreadyExists)
        {
        }

        public UserAlreadyExistsException(string message) : base(message)
        {
        }

        public UserAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UserAlreadyExistsException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}