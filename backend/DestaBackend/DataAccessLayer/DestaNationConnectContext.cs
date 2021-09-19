using DestaNationConnect.DataAccessLayer.Models;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DestaNationConnect.DataAccessLayer
{
    public class DestaNationConnectContext : DbContext
    {
        protected static readonly ILog Logger = LogManager.GetLogger(typeof(DestaNationConnectContext));

        public DestaNationConnectContext(DbContextOptions<DestaNationConnectContext> options)
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

            //All other code goes down here
            //modelBuilder.ApplyConfiguration(new TagConfiguration());
            //modelBuilder.ApplyConfiguration(new TagPurposeConfiguration());
            //modelBuilder.ApplyConfiguration(new TagTypeConfiguration());
            modelBuilder.Entity<TagType>(entity => { entity.HasIndex(e => e.Name).IsUnique(); });
            modelBuilder.Entity<TagPurpose>(entity => { entity.HasIndex(e => e.Name).IsUnique(); });
            modelBuilder.Entity<UserOAuth>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //@TODO: See: https://github.com/aspnet/EntityFrameworkCore/issues/3815
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Data Initial Seed
            modelBuilder.Entity<TagPurpose>().HasData(
                new TagPurpose { Id = 1, Name = "Interest", Description = "Description de what is a tag of type Interest", CreationDate = DateTime.UtcNow },
                new TagPurpose { Id = 2, Name = "Descriptive", Description = "Description de what is a tag of type Descriptive", CreationDate = DateTime.UtcNow }
                );
            modelBuilder.Entity<TagType>().HasData(
                new TagType { Id = 1, Name = "Why", Description = "Description of what is a WHY tag", CreationDate = DateTime.UtcNow },
                new TagType { Id = 2, Name = "What", Description = "Description of what is a WHAT tag ", CreationDate = DateTime.UtcNow }
                );
            modelBuilder.Entity<Tag>().HasData(
                 new Tag { Id = 1, TagTypeId = 1, Name = "Volunteering", Description = "Interest WHY tag about .......", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 2, TagTypeId = 1, Name = "Work opportunities", Description = "Interest WHY tag about .......", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 3, TagTypeId = 1, Name = "Community Event", Description = "Interest WHY tag about .......", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 4, TagTypeId = 1, Name = "Promotion / Sale", Description = "Interest WHY tag about .......", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 5, TagTypeId = 2, Name = "Automotive", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 6, TagTypeId = 2, Name = "Business Services", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 7, TagTypeId = 2, Name = "Computers & Electronics", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 8, TagTypeId = 2, Name = "Construction & Contractors", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 9, TagTypeId = 2, Name = "Education", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 10, TagTypeId = 2, Name = "Entertainment", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 11, TagTypeId = 2, Name = "Food & Dining", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 12, TagTypeId = 2, Name = "Health & Lifestyle", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 13, TagTypeId = 2, Name = "Home & Garden", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow },
                 new Tag { Id = 14, TagTypeId = 2, Name = "Legal & Financial", Description = "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow }
                );
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
