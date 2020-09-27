using Microsoft.EntityFrameworkCore;
using SausageService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SausageService.Repositories
{
    public class SausageDbContext : DbContext
    {
        public DbSet<Sausage> Sausages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sausagedb;Username=postgres;Password=123456");
        }
    }
}
