namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Ticket
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int SessionSeatId { get; set; }

        public virtual SessionSeat SessionSeat { get; set; }

        public virtual User User { get; set; }
    }
}
