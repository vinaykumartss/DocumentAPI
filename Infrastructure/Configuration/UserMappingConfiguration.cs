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
          
            entity.ToTable("User_Details");
            entity.HasKey(k => k.UserId);
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.Property(e => e.LogInID).HasColumnName("LogIn_ID");

            entity.Property(e => e.UserName).HasColumnName("User_Name");
            entity.Property(e => e.Password).HasColumnName("Password");
            entity.Property(e => e.Password1).HasColumnName("Password1");
            entity.Property(e => e.Password2).HasColumnName("Password2");
            entity.Property(e => e.Password3).HasColumnName("Password3");
            entity.Property(e => e.Password4).HasColumnName("Password4");
            entity.Property(e => e.UserDept).HasColumnName("User_Dept");
            entity.Property(e => e.EmaiiId).HasColumnName("Email_ID").HasMaxLength(250);




          
            entity.Property(e => e.UserStatus).HasColumnName("User_Status");

            entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn");
            entity.Property(e => e.UpdatedBy).HasColumnName("UpdatedBy");
            entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn");
            entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy");
         
             
    }

    }
}
