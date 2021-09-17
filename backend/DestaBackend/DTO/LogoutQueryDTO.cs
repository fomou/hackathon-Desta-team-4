using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DTO
{
    public class LogoutQueryDTO
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string DeviceId { get; set; }
    }
}
