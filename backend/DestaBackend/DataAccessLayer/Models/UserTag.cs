using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class UserTag
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long TagId { get; set; }
        public DateTime CreationDate { get; set; }

        public User User { get; set; }
        public Tag Tag { get; set; }
    }
}
