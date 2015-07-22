using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TicketSellingSystemInfrastructure.Constants;
using TicketSellingSystemInfrastructure.Models.EFModels;
using TicketSellingSystemInfrastructure.Models.ViewModels;
using TicketSellingSystemInfrastructure.Services;

namespace TicketSellingSystem.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminCinemaController : ApiController
    {
        private readonly ICinemaService _service;

        public AdminCinemaController(ICinemaService service)
        {
            _service = service;
        }

        [HttpGet]
        public PaginationGenericViewModel<CinemaViewModel> GetCinemas(int page)
        {
            var cinemas = _service
                .GetCinemas(page)
                .Project()
                .To<CinemaViewModel>();
            return new PaginationGenericViewModel<CinemaViewModel>
            {
                Count = _service.GetCinemas().Count(),
                CountPerPage = AppConstants.CinemasPerPage,
                Items = cinemas
            };
        }

       /* [HttpPost]
        public int EditCinema([FromBody] CinemaViewModel model)
        {
            return _service.EditCinema(Mapper.Map<CinemaViewModel, Cinema>(model));
        }

        [HttpPost]
        public void DeleteCinema([FromBody] int id)
        {
            _service.DeleteCinema(id);
        }
        */
        [HttpGet]
        public CinemaViewModel GetCinemaByName(string name)
        {
            var cinema = _service
                .GetCinemas()
                .FirstOrDefault(e => e.Name == name);
            return Mapper.Map<Cinema, CinemaViewModel>(cinema);
        }

        [HttpGet]
        public CinemaViewModel GetCinemaByAddress(string address)
        {
            var cinema = _service
                .GetCinemas()
                .FirstOrDefault(e => e.Address == address);
            return Mapper.Map<Cinema, CinemaViewModel>(cinema);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> UploadPhoto([FromBody] int filmId)
        {
            string[] extensions = { ".jpg", ".jpeg", ".gif", ".bmp", ".png" };
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var root = HttpContext.Current.Server.MapPath("~/Content/Images");
                var provider = new MultipartFormDataStreamProvider(root);
                await Request.Content.ReadAsMultipartAsync(provider);
                var filePath = provider.FileData.First().LocalFileName;
                if (!extensions.Any(x =>
                            x.Equals(Path.GetExtension(filePath.ToLower()),
                                StringComparison.OrdinalIgnoreCase)))
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
               // _service.SavePhoto(filmId, filePath);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}