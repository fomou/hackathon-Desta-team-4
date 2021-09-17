using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DTO
{
    public class AccountOAuthDTO
    {
        public const string OAuthAccountToValidate = "OAuthAccountToValidate";
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long ProviderId { get; set; }
        public long AccountTypeId { get; set; }
        public string UserProviderId { get; set; }
        public string AppleId { get; set; }
        public string Email { get; set; }
        public bool EmailIsVerified { get; set; }
        public string Token { get; set; }
    }
}
