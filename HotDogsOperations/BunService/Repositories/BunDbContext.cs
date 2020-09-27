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
    }
}
