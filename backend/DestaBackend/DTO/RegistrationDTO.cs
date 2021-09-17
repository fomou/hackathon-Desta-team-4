using DestaNationConnect.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DTO
{
    public class RegistrationDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string AccessCode { get; set; }
        public bool IsCustomer { get; set; }

        //Business
        //public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public string Website { get; set; }
        public string AboutUs { get; set; }

        //Customer
        public long Age { get; set; }
        public string Occupation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }

        //Tags - Interest | Descriptive
        public List<string> TagsOfInterests;
        public List<string> TagsOfDescriptions;

        //Address
        public Address Address { get; set; }
        public bool IsBIPOC { get; set; }
    }
}
