using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Hall
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Schema Schema { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
