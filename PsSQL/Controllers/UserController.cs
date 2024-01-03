using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsSQL.EFCore;
using PsSQL.Models.DTOs;
using PsSQL.Models.Entities;

namespace PsSQL.Controllers
{

    public class UserController : Controller
    {
        private readonly EfDataContext _dbContext;

        public UserController(EfDataContext efDataContext)
        {
            this._dbContext = efDataContext;
        }

        [HttpPost("new-user")]
        public IActionResult NewUser(UserModel userLogin)
        {
            try
            {
                // Map UserModel to UserLogin (assuming properties match)
                var user = new UserLogin
                {
                    UserName = userLogin.UserName,
                    UserPassword = userLogin.UserPassword,
                    CenterId = userLogin.CenterId
                };

                // Add the userLogin object to the DbSet
                _dbContext.Users.Add(user);

                // Save the changes to the database
                _dbContext.SaveChanges();

                return Ok("User created successfully"); // or return any appropriate response
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, and return an error response
                return StatusCode(500, "An error occurred while creating the user." + ex.Message);
            }
        }

        [HttpPost("user-login")]
        public IActionResult UserLogin([FromBody] UserModel userModel)
        {
            var isUserValid = _dbContext.Users.FirstOrDefault(x => x.UserName == userModel.UserName && x.UserPassword == userModel.UserPassword);

            if(isUserValid != null)
            {
                return Ok(isUserValid.Id);
            }
            return Ok("IsUserNotValid");
            
        }
    }
}
