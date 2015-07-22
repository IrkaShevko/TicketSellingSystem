using System;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Recall
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }

        public int FilmId { get; set; }

        public DateTime Date { get; set; }

        public bool Blocked { get; set; }

        public virtual Film Film { get; set; }

        public virtual User User { get; set; }
    }
}
