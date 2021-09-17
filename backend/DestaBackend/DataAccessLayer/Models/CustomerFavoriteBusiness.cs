using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class CustomerFavoriteBusiness
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long BusinessId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public string Comment { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Business Business { get; set; }
    }
}
