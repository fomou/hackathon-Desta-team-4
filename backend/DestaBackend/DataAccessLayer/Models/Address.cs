using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class Address
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Door { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual User User { get; set; }
    }
}
