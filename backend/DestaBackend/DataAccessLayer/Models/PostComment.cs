using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class PostComment
    {
        public long PostID { get; set; }
        public long BusinessID { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public Business Business { get; set; }
        public Post Post { get; set; }

    }
}
