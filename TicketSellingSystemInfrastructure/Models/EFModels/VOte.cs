namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Vote
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FilmId { get; set; }

        public int Mark { get; set; }

        public virtual Film Film { get; set; }

        public virtual User User { get; set; }
    }
}
