using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DTO
{
    public class ApiResponse
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public ApiResponseCode Code { get; set; }
        public object Data { get; set; }
    }

    public enum ApiResponseCode
    {
        ReceivedAndSuccess = 1,
        ReceivedAndFailure = 2,
        ReceivedAndException = 3,
        ReceivedAndPartialSuccess = 4
    }
}
