using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class Like
    {
        public long UserID { get; set; }
        public long PostID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Comments { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
