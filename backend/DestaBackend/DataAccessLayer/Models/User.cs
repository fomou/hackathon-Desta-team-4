using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessCode { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual IList<Adress> Adresses { get; set; } = new List<Adress>();
        public virtual IList<UserTag> UserTags { get; set; } = new List<UserTag>();
    }
}
