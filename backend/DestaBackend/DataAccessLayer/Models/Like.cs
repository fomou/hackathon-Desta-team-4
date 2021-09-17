using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class Like
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PostId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comments { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
