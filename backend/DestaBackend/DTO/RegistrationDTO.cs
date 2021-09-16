using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DTO
{
    public class RegistrationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
