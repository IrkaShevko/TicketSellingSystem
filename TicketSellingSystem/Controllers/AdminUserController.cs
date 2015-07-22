using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using TicketSellingSystemInfrastructure.Constants;
using TicketSellingSystemInfrastructure.Exceptions;
using TicketSellingSystemInfrastructure.Models.ViewModels;
using TicketSellingSystemInfrastructure.Models.ViewModels.UserModels;
using TicketSellingSystemInfrastructure.Services;

namespace TicketSellingSystem.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminUserController : ApiController
    {
        private readonly IUserService _service;

        public AdminUserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public PaginationGenericViewModel<AdminUserModel> GetUsers(int page)
        {
            var currUser = HttpContext.Current.User.Identity.Name;
            var users = _service
                .GetAllUsersExceptOne(currUser, page)
                .Project()
                .To<AdminUserModel>();
            return new PaginationGenericViewModel<AdminUserModel>
            {
                Count = _service.GetAllUsers().Count() - 1,
                CountPerPage = AppConstants.UsersPerPage,
                Items = users
            };
        }

        [HttpPost]
        public void DeleteUser([FromBody] LoginViewModel model)
        {
            try
            {
                _service.DeleteUser(model.Email);
            }
            catch (UserNotFoundException)
            {
            }
        }

        [HttpPost]
        public void BlockUser([FromBody] AdminUserModel model)
        {
            _service.BlockUser(model.Email, model.Blocked);
        }
    }
}