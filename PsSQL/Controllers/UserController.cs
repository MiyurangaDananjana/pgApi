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
        public IActionResult NewUser(NewUserModel newUserModel)
        {
            try
            {
                string newSessionId = GenerateSessionId();
                DateTime dateTimeNow = DateTime.UtcNow;

                // Map UserModel to UserLogin (assuming properties match)
                var user = new UserLogin
                {
                    UserName = newUserModel.UserName,
                    UserPassword = newUserModel.Password,
                    CenterId = newUserModel.CenterId,
                    LastLogin = dateTimeNow,
                    SessionId = newSessionId,
                    SessionCreateDateTime = dateTimeNow,
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

        public string GenerateSessionId()
        {
            // Generate a unique session ID using Guid
            Guid sessionId = Guid.NewGuid();
            return sessionId.ToString();
        }

        [HttpPost("user-login")]
        public IActionResult UserLogin([FromBody] UserModel userModel)
        {
            var isUserValid = _dbContext.Users.FirstOrDefault(x => x.UserName == userModel.UserName && x.UserPassword == userModel.UserPassword && x.UserStatus == 0);

            if (isUserValid != null)
            {
                isUserValid.LastLogin = DateTime.UtcNow;
                // Save changes to the database
                _dbContext.SaveChanges();

                return Ok(isUserValid.SessionId);
            }
            return Ok("IsUserNotValid");

        }

        [HttpGet("Get-User-Data")]
        public IActionResult GetUserData(string sessionId)
        {
           
            if (sessionId != null)
            {
                var userData = _dbContext.Users.FirstOrDefault(x => x.SessionId == null);
                return Ok(userData);
            }

            return BadRequest();
        }
    }
}
