using DestaNationConnect.DataAccessLayer;
using DestaNationConnect.DataAccessLayer.Models;
using DestaNationConnect.DTO;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        //Logger
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DashboardController));


        private readonly DestaNationConnectContext _context;

        public DirectoryController(DestaNationConnectContext context)
        {
            _context = context;
        }


        // Post: api/Business/SearchBusinesses
        [HttpPost("SearchBusinesses")]

        //Show the businesses that match with what the user wrote
        public async Task<IActionResult> SearchBusinesses([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {

                //TODO algorithme               


            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"Error occured : ${e.Message}");
            }

            return StatusCode(statusCode, apiResponse);
        }



   
    }
}
