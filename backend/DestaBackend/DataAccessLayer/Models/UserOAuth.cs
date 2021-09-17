using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer.Models
{
    public class UserOAuth
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long OAuthProviderId { get; set; }

        public virtual OAuthProvider OAuthProvider { get; set; }
    }
}
