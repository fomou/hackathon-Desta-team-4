using DestaNationConnect.DataAccessLayer;
using DestaNationConnect.DataAccessLayer.Models;
using DestaNationConnect.DTO;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DirectoryController : ControllerBase
    {
        //Logger
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DirectoryController));

        private readonly DestaNationConnectContext _context;

        public DirectoryController(DestaNationConnectContext context)
        {
            _context = context;
        }

        // Post: api/Business/SearchBusinesses
        /// <summary>
        /// Show the businesses that match with what the user wrote
        /// </summary>
        /// <param name="apiInput"></param>
        /// <returns></returns>
        [HttpPost("SearchBusinesses")]
        public async Task<IActionResult> SearchBusinesses([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {
                var userId = JsonConvert.DeserializeObject<long>(apiInput.Data.ToString());

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
