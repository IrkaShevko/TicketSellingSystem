using System.Collections.Generic;

namespace TicketSellingSystemInfrastructure.Models.ViewModels
{
    public class PaginationGenericViewModel<T>
    {
        public int Count { get; set; }

        public int CountPerPage { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
