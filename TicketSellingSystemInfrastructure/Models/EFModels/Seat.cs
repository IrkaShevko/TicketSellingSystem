using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Seat
    {
        public int Id { get; set; }

        public int SeatNumber { get; set; }

        public bool EmptySpace { get; set; }

        public int RowId { get; set; }

        public int TypeId { get; set; }

        public virtual Row Row { get; set; }

        public virtual SeatType Type { get; set; }

        public virtual ICollection<SessionSeat> SessionSeats { get; set; }
    }
}