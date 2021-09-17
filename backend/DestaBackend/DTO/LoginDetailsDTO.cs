using DestaNationConnect.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DTO
{
    public class LoginDetailsDTO
    {
        public LoginDTO LoginDto { get; set; }
        public Customer Customer { get; set; }
        public Business Business { get; set; }
    }
}
