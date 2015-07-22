using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Row
    {
        public int Id { get; set; }

        public int SchemaId { get; set; }

        public int CountSeats { get; set; }

        public int Number { get; set; }

        public virtual Schema Schema { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
