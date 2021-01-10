using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping
{
    public class PasswordChangeRegistryMapping : IEntityTypeConfiguration<PasswordChangeRegistry>
    {
        public void Configure(EntityTypeBuilder<PasswordChangeRegistry> builder)
        {
            builder.ToTable("USER_PASSWORD_REGISTRY");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("UPR_CD_ID");
            builder.Property(d => d.Expiration).HasColumnName("UPR_DT_DATA");
            builder.Property(d => d.Password).HasColumnName("UPR_TX_PASSWORD");
            builder.Property(d => d.Token).HasColumnName("UPR_TX_TOKEN");
            builder.Property(d => d.User_Id).HasColumnName("USER_CD_ID");
            builder.Property(d => d.IsChanged).HasColumnName("UPR_BL_CHANGED");
            builder.HasOne(d => d.User).WithMany(e => e.UserPasswordRegistry).HasForeignKey(x => x.User_Id);
        }
    }
}
