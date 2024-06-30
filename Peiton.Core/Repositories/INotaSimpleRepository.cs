using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
    public interface INotaSimpleRepository : IRepository<NotaSimple>
    {
        Task<int> ContarNotasSimplesAsync(NotasSimplesFilter filter);
        Task<List<NotaSimple>> ObtenerNotasSimplesAsync(int page, int total, NotasSimplesFilter filter);
    }
}