using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class UserFeed
    {
        public long Id { get; set; }
        public long UserID { get; set; }
        public string Content { get; set; }
        public string FeedURL { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public User User { get; set; }

    }
}
