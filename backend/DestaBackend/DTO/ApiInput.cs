using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DTO
{
    public class ApiInput
    {
        public string Token { get; set; }
        public string Lang { get; set; }
        public object Data { get; set; }
        public object PayLoad { get; set; }
    }
}
