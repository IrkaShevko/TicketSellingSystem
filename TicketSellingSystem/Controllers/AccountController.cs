using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using AutoMapper;
using TicketSellingSystemInfrastructure.Constants;
using TicketSellingSystemInfrastructure.Exceptions;
using TicketSellingSystemInfrastructure.Models.EFModels;
using TicketSellingSystemInfrastructure.Models.ViewModels.StatusModels;
using TicketSellingSystemInfrastructure.Models.ViewModels.UserModels;
using TicketSellingSystemInfrastructure.Services;

namespace TicketSellingSystem.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserService _service;
        private const int CookieVersion = 1;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public ResultModel Register([FromBody] RegisterViewModel model)
        {
            try
            {
                var user = _service.Register(Mapper.Map<RegisterViewModel, User>(model));
                CreateCookies(user);
                return new GoodResultModel(Mapper.Map<User, UserViewModel>(user));
            }
            catch (UserAlreadyExistsException e)
            {
                return new BadResultModel(e.Message);
            }
            catch (BadModelException e)
            {
                return new BadResultModel(e.Message);
            }
            catch (Exception)
            {
                return new BadResultModel();
            }
        }

        [HttpPost]
        public ResultModel Login([FromBody] LoginViewModel model)
        {
            try
            {
                var user = _service.Login(Mapper.Map<LoginViewModel, User>(model));
                if (user.Blocked)
                    return new BadResultModel(ErrorMessages.UserIsBlocked);
                CreateCookies(user);
                return new GoodResultModel(Mapper.Map<User, UserViewModel>(user));
            }
            catch (UserNotFoundException e)
            {
                return new BadResultModel(e.Message);
            }
            catch (Exception)
            {
                return new BadResultModel();
            }
        }

        [Authorize]
        [HttpPost]
        public void LogOff()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.User = null;
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            HttpContext.Current.Response.SetCookie(cookie);
        }

        [HttpGet]
        public UserViewModel GetCurrentUser()
        {
            if (HttpContext.Current.User == null)
                return null;
            var currUser = HttpContext.Current.User.Identity.Name;
            if (currUser == String.Empty)
                return null;
            try
            {
                var user = _service.GetUserByEmail(currUser);
                return Mapper.Map<User, UserViewModel>(user);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static void CreateCookies(User user)
        {
            var authTicket = new FormsAuthenticationTicket(
                CookieVersion,
                user.Email,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                user.Roles
                );
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(authTicket));
            HttpContext.Current.Response.AppendCookie(cookie);
        }
    }
}