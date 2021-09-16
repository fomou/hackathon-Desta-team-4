using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class UserOAuth
    {
        public long OAuthProviderID { get; set; }
        public long UserID { get; set; }

        public OAuthProvider OAuthProvider { get; set; }

    }
}
