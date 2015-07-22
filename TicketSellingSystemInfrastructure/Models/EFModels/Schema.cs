using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.EFModels
{
    public class Schema
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        public int OverallCountSeats { get; set; }

        public virtual Hall Hall { get; set; }

        public virtual ICollection<Row> Rows { get; set; }
    }
}
