using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class BusinessDetail
    {
        [Key]
        [ForeignKey("Business")]
        [Required]
        public long BusinessId { get; set; }
        public DateTime CreationDate { get; set; }

        public string Facebook { get; set; }
        public string Google { get; set; }
        public string LinkedIn { get; set; }

        public virtual Business Business { get; set; }
    }
}
