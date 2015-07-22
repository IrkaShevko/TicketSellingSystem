using System;
using System.Runtime.Serialization;
using TicketSellingSystemInfrastructure.Constants;

namespace TicketSellingSystemInfrastructure.Exceptions
{
    [Serializable]
    public class AlreadyVotedException : Exception
    {
        public AlreadyVotedException(): base(ErrorMessages.AlreadyVoted)
        {
        }

        public AlreadyVotedException(string message) : base(message)
        {
        }

        public AlreadyVotedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AlreadyVotedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}