using System;
using System.Linq;

namespace TicketSellingSystemInfrastructure.Extensions
{
    internal static class Paging
    {
        internal static IQueryable<T> Paged<T>(this IOrderedQueryable<T> colletion, int page, int countPerPage)
        {
            if (page < 0 || countPerPage < 0)
                throw new ArgumentException();
            return colletion
                .Skip((page - 1)*countPerPage)
                .Take(countPerPage);
        }
    }
}
