using System;
using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.ViewModels
{
    public class FilmViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public string PublishingYear { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string LogoPath { get; set; }

        public double Rating { get; set; }

        public IEnumerable<SessionViewModel> Sessions { get; set; }

        public IEnumerable<RecallViewModel> Recalls { get; set; }
    }
}