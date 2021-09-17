using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class Customer
    {
        [Key]
        [ForeignKey("User")]
        [Required]
        public long UserId { get; set; }
        public long Age { get; set; }
        public string Occupation { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
    }
}
