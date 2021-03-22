using Document.Approve.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.Infrastructure.Configuration
{
    
    public class RoleConfigurationMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.ToTable("System_Main_Roles_Master");
            entity.HasKey(k => k.Id);
            entity.Property(e => e.Id).HasColumnName("UID");
            entity.Property(e => e.Name).HasColumnName("Role_Name");
        }

    }
}
