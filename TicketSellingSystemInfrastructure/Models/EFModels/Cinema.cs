using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Cinema
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string LogoPath { get; set; }

        public virtual ICollection<Film> Films { get; set; }

        public virtual ICollection<Hall> Halls { get; set; }
    }
}