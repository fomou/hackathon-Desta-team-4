using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        [Required]
        public long UserId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
    }
}
