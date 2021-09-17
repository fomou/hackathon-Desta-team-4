using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class PostComment
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public long BusinessId { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual Business Business { get; set; }
    }
}
