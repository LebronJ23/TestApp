using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<AppleEater> People { get; set; }

        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppleEater>().HasIndex(ae => ae.Email).IsUnique();
        }
    }
}
