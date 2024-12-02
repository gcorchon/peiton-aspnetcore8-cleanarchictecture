using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IInformePersonalRepository : IRepository<InformePersonal>
{
    Task<int> ContarInformesPersonalesAsync(int tuteladoId);
    Task<InformePersonal[]> ObtenerInformesPersonalesAsync(int page, int total, int tuteladoId);
}
