using DestaBackend.DataAccessLayer.Models;
using log4net;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DestaBackend.DataAccessLayer
{
    public class DestaContext : DbContext
    {
        protected static readonly ILog Logger = LogManager.GetLogger(typeof(DestaContext));

        public DestaContext(DbContextOptions<DestaContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //all other code goes down here
            Logger.InfoFormat("Configuring DbContext");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //all other code goes down here
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity().HasRequired(s => s.Buisness).WithMany().WillCascadeOnDelete(false);
            //TODO: See: https://github.com/aspnet/EntityFrameworkCore/issues/3815
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Announce> Announce { get; set; }
        public virtual DbSet<AnnounceTag> AnnounceTag { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<BusinessDetail> BusinessDetail { get; set; }
        public virtual DbSet<ChatMessage> ChatMessage { get; set; }
        public virtual DbSet<ChatData> ChatData { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetail { get; set; }
        public virtual DbSet<CustomerFavoriteBusiness> CustomerFavoriteBusiness { get; set; }
        public virtual DbSet<CustomerHabit> CustomerHabit { get; set; }
        public virtual DbSet<Like> Like { get; set; }
        public virtual DbSet<OAuthProvider> OAuthProvider { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostComment> PostComment { get; set; }
        public virtual DbSet<PostTag> PostTag { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TagPurpose> TagPurpose { get; set; }
        public virtual DbSet<TagType> TagType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserFeed> UserFeed { get; set; }
        public virtual DbSet<UserOAuth> UserOAuth { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserTag> UserTag { get; set; }
    }
}
