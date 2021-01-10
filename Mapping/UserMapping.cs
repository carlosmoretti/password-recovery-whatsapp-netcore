using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("USER");
            builder.Property(e => e.Id).HasColumnName("USER_CD_ID");
            builder.Property(e => e.Name).HasColumnName("USER_TX_NAME");
            builder.Property(e => e.Password).HasColumnName("USER_TX_PASSWORD");
            builder.Property(e => e.Username).HasColumnName("USER_TX_USERNAME");
            builder.Property(e => e.Email).HasColumnName("USER_TX_EMAIL");
            builder.Property(e => e.Cellphone).HasColumnName("USER_NM_CELLPHONE");
            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasMany(e => e.UserPasswordRegistry).WithOne(e => e.User).HasForeignKey(e => e.User_Id);
        }
    }
}
