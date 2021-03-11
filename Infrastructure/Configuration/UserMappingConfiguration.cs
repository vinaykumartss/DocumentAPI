using Document.Approve.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.Infrastructure.Configuration
{
    
    public class UserConfigurationMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            // Table Name
            entity.ToTable("user");
            // Primary Key
            entity.HasKey(k => k.UserId);
            // Index
            entity.HasIndex(e => e.Username).HasName("user_username_key").IsUnique();
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.EmailAddress).HasColumnName("email_address").HasMaxLength(250);
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasMaxLength(150);
            entity.Property(e => e.LastName).HasColumnName("last_name").HasMaxLength(150);
            entity.Property(e => e.LastUpdated).HasColumnName("last_updated");
            entity.Property(e => e.Password).HasColumnName("password").HasMaxLength(500);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Username).IsRequired().HasColumnName("username").HasMaxLength(250);

        }

    }
}
