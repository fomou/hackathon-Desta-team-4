using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public long TagTypeId { get; set; }
        public long? AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual TagType TagType { get; set; }
        public virtual User Author { get; set; }
    }
}
