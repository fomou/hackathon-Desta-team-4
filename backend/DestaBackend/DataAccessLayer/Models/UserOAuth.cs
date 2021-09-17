using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class UserOAuth
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long OAuthProviderId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public bool EmailIsVerified { get; set; }

        public virtual User User { get; set; }
        public virtual OAuthProvider OAuthProvider { get; set; }
    }
}
