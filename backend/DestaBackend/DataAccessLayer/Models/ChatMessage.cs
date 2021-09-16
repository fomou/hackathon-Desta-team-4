using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class ChatMessage
    {
        public long ID { get; set; }
        public long UserFromID { get; set; }
        public long UserToID { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public User User { get; set; }
    }
}
