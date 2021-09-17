using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestaNationConnect.Security
{
    public class AuthOptions
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(AuthOptions));

        public const string ISSUER = "DESTA AUTH SERVER";
        public const string AUDIENCE = "desta";
        public const int LIFETIME = 1;

        private static readonly string KEY = Environment.GetEnvironmentVariable("DESTA_BEARER_KEY");

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            Logger.InfoFormat($"DESTA_BEARER_KEY:: {KEY}");
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static string GetAudience()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Logger.InfoFormat($"ASPNETCORE_ENVIRONMENT:: {env}");
            string audience;
            switch (env)
            {
                case "Development":
                    audience = "desta.Development";
                    break;
                case "Staging":
                    audience = "desta.Staging";
                    break;
                case "Production":
                    audience = "desta.Production";
                    break;
                default:
                    audience = "https://desta.com:443";
                    break;
            }
            Logger.InfoFormat($"audience:: {audience}");
            return audience;
        }

        public static string GetIssuer()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string issuer;
            switch (env)
            {
                case "Development":
                    issuer = "https://localhost:3027";
                    break;
                case "Staging":
                    issuer = "http://xx.xx.xxx.xxx:8020";
                    break;
                case "Production":
                    issuer = "http://localhost:3027";
                    break;
                default:
                    issuer = "https://desta.com:443";
                    break;
            }
            Logger.InfoFormat($"issuer:: {issuer}");
            return issuer;
        }
    }
}
