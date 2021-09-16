using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class OAuthProvider
    {
        public long ID { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Apple { get; set; }
        public string Key { get; set; }

    }
}
