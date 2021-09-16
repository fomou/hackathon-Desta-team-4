using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class AnnounceTag
    {
        public long Id { get; set; }
        public long TagId { get; set; }
        public long AnnounceId { get; set; }
        public long AuthorId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Announce Announce { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual User Author { get; set; }
    }
}
