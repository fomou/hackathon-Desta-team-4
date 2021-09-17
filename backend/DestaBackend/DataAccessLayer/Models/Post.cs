using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class Post
    {
        public long Id { get; set; }
        public long PostTagId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedAt { get; set; }
                        
        public virtual PostTag PostTag { get; set; }
        public virtual Business Business { get; set; }

        public virtual IList<PostComment> PostComments { get; set; } = new List<PostComment>();
    }
}
