﻿using DestaBackend.DataAccessLayer.Models;
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
            //TODO: See: https://github.com/aspnet/EntityFrameworkCore/issues/3815
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerFavoriteBusiness> CustomerFavoriteBusiness { get; set; }
        public virtual DbSet<CustomerHabit> CustomerHabit { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TagType> TagType { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
