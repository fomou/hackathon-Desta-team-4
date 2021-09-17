using DestaBackend.DataAccessLayer;
using DestaBackend.DTO;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace DestaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {

        //Logger
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AccountController));

        private readonly DestaContext _context;

        public AccountController(DestaContext context)
        {
            _context = context;
        }

        // POST: api/Account/Login
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {
                var loginDto = JsonConvert.DeserializeObject<LoginDTO>(apiInput.Data.ToString());
                //TODO: faire le Login process icite

                statusCode = 200;
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"Error occured : ${e.Message}");
            }

            return StatusCode(statusCode, apiResponse);
        }

        // Post: api/Account/Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {
                var logoutDto = JsonConvert.DeserializeObject<LogoutQueryDTO>(apiInput.Data.ToString());
                //TODO: faire le Login process icite

                statusCode = 200;
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"Error occured : ${e.Message}");
            }

            return await Task.FromResult(StatusCode(statusCode, apiResponse));
        }

        // POST: api/Account/Register
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {
                var registrationDto = JsonConvert.DeserializeObject<RegistrationDTO>(apiInput.Data.ToString());
                //TODO: faire le Login process icite

                statusCode = 200;
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"Error occured : ${e.Message}");
            }

            return StatusCode(statusCode, apiResponse);
        }
    }
}
