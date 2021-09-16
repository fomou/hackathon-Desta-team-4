using DestaBackend.DataAccessLayer.Models;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer
{
    public class DestaContext : DbContext
    {
        protected static readonly ILog Logger = LogManager.GetLogger(typeof(DestaContext));

        public DestaContext(DbContextOptions<DestaContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerFavoriteBusiness> CustomerFavoriteBusiness { get; set; }
        public virtual DbSet<CustomerHabit> CustomerHabit { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TagType> TagType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserFeed> UserFeed { get; set; }
        public virtual DbSet<UserTag> UserTag { get; set; }
        public virtual DbSet<Announce> Announce { get; set; }
        
        public virtual DbSet<AnnounceTag> AnnounceTag { get; set; }
        
        public virtual DbSet<ChatMessage> ChatMessage { get; set; }
        
        public virtual DbSet<ChatData> ChatData { get; set; }
        
        public virtual DbSet<Like> Like { get; set; }
        
        public virtual DbSet<Post> Post{ get; set; }
        public virtual DbSet<PostTag> PostTag { get; set; }
        public virtual DbSet<PostComment> PostComment { get; set; }
        public virtual DbSet<UserOAuth> UserOAuth { get; set; }
        public virtual DbSet<OAuthProvider> OAuthProvider { get; set; }
        




    }
}
