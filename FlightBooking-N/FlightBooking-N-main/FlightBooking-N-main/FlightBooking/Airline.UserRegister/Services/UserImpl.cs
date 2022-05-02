using Airline.UserRegister.DBContext;
using Airline.UserRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.UserRegister.Repository
{
    public class UserImpl : IUserInterface
    {
        public UserRegisterDbContext _UserRegisterDbContext;

        public UserImpl(UserRegisterDbContext userRegisterDbContext)
        {
            _UserRegisterDbContext = userRegisterDbContext;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _UserRegisterDbContext.UserRegistor.ToList();
        }

        public void AddNewUser(UserModel user)
        {
            _UserRegisterDbContext.UserRegistor.Add(user);
            _UserRegisterDbContext.SaveChanges();
        }
    }
}
