using Document.Approve.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Document.Approve.Infrastructure.Configuration
{
  public  class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public DbSet<User> User { get; set; }
    }
}
