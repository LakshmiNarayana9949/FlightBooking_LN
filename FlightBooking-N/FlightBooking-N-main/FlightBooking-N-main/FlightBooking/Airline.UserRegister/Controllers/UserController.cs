using Airline.UserRegister.Models;
using Airline.UserRegister.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Airline.UserRegister.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserInterface _userRepository;
        public UserController(IUserInterface userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegisterNewUser")]
        public IActionResult RegisterNewUser([FromBody] UserModel user)
        {
            try
            {
                    using (var scope = new TransactionScope())
                    {
                        _userRepository.AddNewUser(user);
                        scope.Complete();
                        return Accepted();
                    }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userRepository.GetAllUsers();
                return new OkObjectResult(users);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
