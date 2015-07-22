using System.Data.Entity;
using System.Linq;
using TicketSellingSystemInfrastructure.Constants;
using TicketSellingSystemInfrastructure.Exceptions;
using TicketSellingSystemInfrastructure.Extensions;
using TicketSellingSystemInfrastructure.Models.EFModels;
using TicketSellingSystemInfrastructure.Repository;

namespace TicketSellingSystemInfrastructure.Services
{
    public interface IFilmService
    {
        Film GetFilm(int id);
        IQueryable<Film> GetFilms(int page);
        double VoteForFilm(int id, int userId, int mark);
    }

    public class FilmService : IFilmService
    {
        private readonly IRepository<Film> _repository;

        public FilmService(IRepository<Film> repository)
        {
            _repository = repository;
        }

        public Film GetFilm(int id)
        {
            return _repository
                .GetAll()
                .Include(f => f.Sessions)
                .Include(f => f.Recalls)
                .FirstOrDefault(f => f.Id == id);
        }

        public IQueryable<Film> GetFilms(int page)
        {
            var films = _repository
                .GetAll()
                .OrderBy(f => f.Name)
                .Paged(page, AppConstants.FilmsPerPage);
            return films;
        }

        public double VoteForFilm(int id, int userId, int mark)
        {
            var film = _repository.GetById(id);
            var votes = film.Votes;
            if (votes.FirstOrDefault(v => v.UserId == userId) != null)
                throw new AlreadyVotedException();
            votes.Add(new Vote{FilmId = id, Mark = mark, UserId = userId});
            var result = votes.Aggregate<Vote, double>(0, (current, vote) => current + vote.Mark);
            film.Rating = result/votes.Count;
            _repository.Save();
            return film.Rating;
        }
    }
}