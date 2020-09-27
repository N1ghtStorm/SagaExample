using SausageService.Models;
using System.Threading.Tasks;

namespace SausageService.Repositories
{
    public interface ISausageRepository
    {
        Task<Sausage> CreateSausage(Sausage sausage);
        Task DeleteSausage(int id);
    }
}
