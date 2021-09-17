using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class TagPurpose
    {
        public long Id { get; set; }
        public string Name { get; set; }   //Descriptive | Interest
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
