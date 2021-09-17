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
        public DateTime CreationDate { get; set; }

        public virtual IList<Address> Addresses { get; set; } = new List<Address>();
        public virtual IList<UserTag> UserTags { get; set; } = new List<UserTag>();
        public virtual IList<Announce> Announces { get; set; } = new List<Announce>();
        public virtual IList<UserFeed> UserFeeds { get; set; } = new List<UserFeed>();
        public virtual IList<Like> Likes { get; set; } = new List<Like>();
    }
}
