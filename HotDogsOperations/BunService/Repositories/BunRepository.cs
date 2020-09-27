using BunService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BunService.Repositories
{
    public class BunRepository : IBunRepository
    {
        private readonly BunDbContext _bunDbContext;

        public BunRepository(BunDbContext bunDbContext)
        {
            _bunDbContext = bunDbContext;
        }
        public async Task<Bun> CreateBun(Bun bun)
        {
            await _bunDbContext.Buns.AddAsync(bun);
            await _bunDbContext.SaveChangesAsync();
            return bun;
        }

        public async Task DeleteBun(int id)
        {
            var bun = await _bunDbContext.Buns.FindAsync(id);
            _bunDbContext.Remove(bun);
            await _bunDbContext.SaveChangesAsync();
        }
    }
}
