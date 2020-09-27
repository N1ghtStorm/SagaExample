using BunService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BunService.Repositories
{
    public class BunDbContext : DbContext
    {
        public DbSet<Bun> Buns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=bundb;Username=postgres;Password=123456");
        }
    }
}
