using System;
using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Film
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public TimeSpan Duration { get; set; }

        public string PublishingYear { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string LogoPath { get; set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }

        public virtual ICollection<Recall> Recalls { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}