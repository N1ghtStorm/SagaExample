using BunService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BunService.Repositories
{
    public interface IBunRepository
    {
        Task<Bun> CreateBun(Bun bun);
        Task DeleteBun(int id);
    }
}
