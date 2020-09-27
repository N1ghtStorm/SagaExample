using SausageService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SausageService.Repositories
{
    public class SausageRepository : ISausageRepository
    {
        private readonly SausageDbContext _sausageDbContext;

        public SausageRepository(SausageDbContext sausageDbContext)
        {
            _sausageDbContext = sausageDbContext;
        }

        public async Task<Sausage> CreateSausage(Sausage sausage)
        {
            await _sausageDbContext.Sausages.AddAsync(sausage);
            await _sausageDbContext.SaveChangesAsync();
            return sausage;
        }

        public async Task DeleteSausage(int id)
        {
            var bun = await _sausageDbContext.Sausages.FindAsync(id);
            _sausageDbContext.Remove(bun);
            await _sausageDbContext.SaveChangesAsync();
        }
    }
}
