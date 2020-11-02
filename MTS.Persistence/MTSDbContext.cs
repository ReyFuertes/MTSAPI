using Microsoft.EntityFrameworkCore;
using MTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Persistence
{
    public class MTSDbContext : DbContext
    {
        public MTSDbContext(DbContextOptions<MTSDbContext> opt) 
            : base(opt)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Item>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
