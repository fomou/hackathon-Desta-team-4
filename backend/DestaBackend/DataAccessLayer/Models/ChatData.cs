using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class ChatData
    {
        public long ID { get; set; }
        public long ChatMessageID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
