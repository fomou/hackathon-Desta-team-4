using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class PostTag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual IList<Post> Posts { get; set; } = new List<Post>();
    }
}
