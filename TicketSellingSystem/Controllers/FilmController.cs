using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TicketSellingSystemInfrastructure.Exceptions;
using TicketSellingSystemInfrastructure.Models.EFModels;
using TicketSellingSystemInfrastructure.Models.ViewModels;
using TicketSellingSystemInfrastructure.Models.ViewModels.StatusModels;
using TicketSellingSystemInfrastructure.Services;

namespace TicketSellingSystem.Controllers
{
    public class FilmController : ApiController
    {
        private readonly IFilmService _service;

        public FilmController(IFilmService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<FilmViewModel> GetFilms(int page)
        {
            var films = _service.GetFilms(page);
            return films.Project().To<FilmViewModel>();
        }

        [HttpGet]
        public ResultModel GetFilm(int id)
        {
            try
            {
                var film = _service.GetFilm(id);
                return new GoodResultModel(Mapper.Map<Film, FilmViewModel>(film));
            }
            catch (FilmNotFoundException e)
            {
                return new BadResultModel(e.Message);
            }
            catch (Exception)
            {
                return new BadResultModel();
            }
        }
    }
}
