using Entities;
using Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace Contexto
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> db) : base(db)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<PasswordChangeRegistry> PasswordChangeRegistry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserMapping());
            modelBuilder.ApplyConfiguration<PasswordChangeRegistry>(new PasswordChangeRegistryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
