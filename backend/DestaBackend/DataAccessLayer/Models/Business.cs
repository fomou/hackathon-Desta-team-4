using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class Business
    {
        [Key]
        [ForeignKey("User")]
        [Required]
        public long UserId { get; set; }
        [ForeignKey("PartnerBusiness")]
        public long? PartnerBusinessId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PartnerBusinessStartDate { get; set; }

        public string MarketingName { get; set; }
        public string Teasing { get; set; }
        public string AboutUs { get; set; }
        public string Website { get; set; }

        public virtual User User { get; set; }
        [ForeignKey("PartnerBusinessId")]
        public virtual Business PartnerBusiness { get; set; }
        public virtual IList<PostComment> PostComments { get; set; } = new List<PostComment>();
    }
}
