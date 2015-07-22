using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class SeatType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Multiplier { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
