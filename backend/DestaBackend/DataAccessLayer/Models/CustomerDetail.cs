using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class CustomerDetail
    {
        [Key]
        [ForeignKey("Customer")]
        [Required]
        public long CustomerId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
