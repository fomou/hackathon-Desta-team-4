using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class ChatData
    {
        public long Id { get; set; }
        public long ChatMessageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ChatMessage ChatMessage { get; set; }
    }
}
