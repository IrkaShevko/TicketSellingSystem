using System.Linq;
using TicketSellingSystemInfrastructure.Constants;
using TicketSellingSystemInfrastructure.Exceptions;
using TicketSellingSystemInfrastructure.Extensions;
using TicketSellingSystemInfrastructure.Models.EFModels;
using TicketSellingSystemInfrastructure.Repository;

namespace TicketSellingSystemInfrastructure.Services
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();
        IQueryable<User> GetAllUsersExceptOne(string name, int page);
        void InsertUser(User user);
        void DeleteUser(int id);
        void DeleteUser(string email);
        User Register(User user);
        User Login(User user);
        User GetUserByEmail(string email);
        void BlockUser(string email, bool block);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public IQueryable<User> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public IQueryable<User> GetAllUsersExceptOne(string email, int page)
        {
            return _repository
                .GetAll()
                .Except(
                    _repository
                        .GetAll()
                        .Where(u => u.Email == email)
                ).OrderBy(e => e.Email)
                .Paged(page, AppConstants.UsersPerPage);
        }

        public void InsertUser(User user)
        {
            _repository.Insert(user);
            _repository.Save();
        }

        public void DeleteUser(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public void DeleteUser(string email)
        {
            var user = GetUserByEmail(email);
            if (user == null)
                return;
            DeleteUser(user.Id);
            _repository.Save();
        }

        public User Register(User user)
        {
            if (user.Email == null || user.Name == null || user.Password == null)
                throw new BadModelException();
            if (GetUserByEmail(user.Email) != null)
            {
                throw new UserAlreadyExistsException();
            }
            user.Salt = CryptService.GetRandomSalt();
            user.Password = CryptService.GetMd5(user.Password + user.Salt);
            user.Roles = Roles.User;
            InsertUser(user);
            return user;
        }

        public User Login(User model)
        {
            var user = GetUserByEmail(model.Email);
            if (user == null)
                throw new UserNotFoundException();
            if (!CryptService
                .GetMd5(model.Password + user.Salt)
                .Equals(user.Password))
                throw new UserNotFoundException();
            return user;
        }

        public User GetUserByEmail(string email)
        {
            return _repository
                .GetAll()
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public void BlockUser(string email, bool block)
        {
            var user = GetUserByEmail(email);
            user.Blocked = block;
            _repository.Save();
        }
    }
}