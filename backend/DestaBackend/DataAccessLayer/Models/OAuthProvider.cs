using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class OAuthProvider
    {
        public static long AppleId = (long)new Random().NextDouble();
        public static long GoogleId = (long)new Random().NextDouble();
        public static long FacebookId = (long)new Random().NextDouble();

        public long Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; } //Google, Facebook, Apple, Microsoft
    }
}
