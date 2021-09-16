using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class Business
    {
        [Key]
        [ForeignKey("User")]
        [Required]
        public long UserId { get; set; }
        public long PartnerBusinessUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PartnerBusinessStartDate { get; set; }

        public string Facebook { get; set; }
        public string Google { get; set; }
        public string LinkedIn { get; set; }

        public Business PartnerBusiness { get; set; }
    }
}
