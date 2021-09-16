using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class Announce
    {
        public long Id { get; set; }
        public long UserId { set; get; }
        public string Context { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual User User { get; set; }
    }
}
