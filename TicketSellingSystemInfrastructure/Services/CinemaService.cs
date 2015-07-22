using System.Linq;
using TicketSellingSystemInfrastructure.Constants;
using TicketSellingSystemInfrastructure.Extensions;
using TicketSellingSystemInfrastructure.Models.EFModels;
using TicketSellingSystemInfrastructure.Repository;

namespace TicketSellingSystemInfrastructure.Services
{
    public interface ICinemaService
    {
        IQueryable<Cinema> GetCinemas();
        IQueryable<Cinema> GetCinemas(int page);
    }

    public class CinemaService : ICinemaService
    {
        private readonly IRepository<Cinema> _repository;

        public CinemaService(IRepository<Cinema> repository)
        {
            _repository = repository;
        }

        public IQueryable<Cinema> GetCinemas()
        {
            return _repository.GetAll();
        }

        public IQueryable<Cinema> GetCinemas(int page)
        {
            return _repository
                .GetAll()
                .OrderBy(e => e.Name)
                .Paged(page, AppConstants.CinemasPerPage);
        }
    }
}