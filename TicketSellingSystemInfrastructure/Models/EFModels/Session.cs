using System;
using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Session
    {
        public int Id { get; set; }

        public int FilmId { get; set; }

        public DateTime Date { get; set; }

        public double Price { get; set; }

        public int HallId { get; set; }

        public int CountTickets { get; set; }

        public virtual Film Film { get; set; }

        public virtual Hall Hall { get; set; }

        public virtual ICollection<SessionSeat> SessionSeats { get; set; }
    }
}
