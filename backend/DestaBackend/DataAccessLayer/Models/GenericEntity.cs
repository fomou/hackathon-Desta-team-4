using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class GenericEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DateOfAction { get; set; }
        public DateTime? ClosingDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
