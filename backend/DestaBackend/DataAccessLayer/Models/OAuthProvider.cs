using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class OAuthProvider
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
    }
}
