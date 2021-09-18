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
    public class DashboardController : ControllerBase
    {
        //Logger
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DashboardController));

        private readonly DestaNationConnectContext _context;

        public DashboardController(DestaNationConnectContext context)
        {
            _context = context;
        }

      


        // Post: api/Announce/GetUserDashboardInfos
        [HttpPost("GetUserDashboardInfos")]


        //Search from userTag and tagPurposeId of the user that match with the announceTag and show these announces
        public async Task<IActionResult> GetUserDashboardInfos([FromBody] ApiInput apiInput)
        {
            var apiResponse = new ApiResponse
            {
                Code = ApiResponseCode.ReceivedAndException
            };
            int statusCode = 500;

            try
            {
                //TODO Algorithme
                var userId = JsonConvert.DeserializeObject<long>(apiInput.Data.ToString());
                

                statusCode = 200;
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"Error occured : ${e.Message}");
            }

            return StatusCode(statusCode, apiResponse);
        }





        // Post: api/Announce/searchAnnounces
        [HttpPost("SearchAnnounces")]

        //Show the announces that correspond to what the user wrote in the search bar (included in title or description of the announce)
        public async Task<IActionResult> SearchAnnounces([FromBody] ApiInput apiInput)

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
