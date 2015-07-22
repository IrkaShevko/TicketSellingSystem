namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class SessionSeat
    {
        public int Id { get; set; }

        public int SeatId { get; set; }

        public bool Blocked { get; set; }

        public bool Bought { get; set; }

        public int SessionId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual Session Session { get; set; }
    }
}
