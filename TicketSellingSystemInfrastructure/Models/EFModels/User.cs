using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Phone { get; set; }

        public bool Blocked { get; set; }

        public string Roles { get; set; }

        public virtual ICollection<Recall> Recalls { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
