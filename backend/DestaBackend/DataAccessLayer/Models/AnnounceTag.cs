using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class AnnounceTag
    {
        public long TagID { get; set; }
        public long AnnounceID { get; set; }
        public long AuthorID { get; set; }
        public DateTime CreatedAt { get; set; }

        public Announce Announce { get; set; }
        public Tag Tag { get; set; }
    }
}
