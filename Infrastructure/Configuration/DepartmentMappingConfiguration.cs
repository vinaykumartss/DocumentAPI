using Document.Approve.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.Infrastructure.Configuration
{
    
    public class DepartmentConfigurationMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        { 
            entity.ToTable("Department");
            entity.HasKey(k => k.Id);
            entity.Property(e => e.Id).HasColumnName("UID");
            entity.Property(e => e.Name).HasColumnName("Dept_Name");
            entity.Property(e => e.DepId).HasColumnName("Dept_Id");
            entity.Property(e => e.Status).HasColumnName("Dept_Status");
        }

    }
}
