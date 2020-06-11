﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp31.Models
{
    public class VodafoneDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// DbContextOptions<DbContext> will resolve all the dependencies on DbContext class e.g. Connection, DbSet, Command, etc
        /// </summary>
        public VodafoneDbContext(DbContextOptions<VodafoneDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // define one-to-many ralationship and hasOne relationship across Category and Product
            modelBuilder.Entity<Product>()
                         .HasOne(p => p.Category) // hasone, one product is a part of one category
                         .WithMany(c => c.Products) // one category contains multiple products
                         .HasForeignKey(p => p.CategoryRowId); // product contains reference for CatgoryRowId
        }
    }
}
