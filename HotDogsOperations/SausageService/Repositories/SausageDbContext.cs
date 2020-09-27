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
    }
}
