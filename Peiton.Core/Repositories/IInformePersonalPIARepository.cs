using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IInformePersonalPIARepository : IRepository<InformePersonalPIA>
{
    Task<int> ContarInformesPersonalesPIAAsync(int tuteladoId);
    Task<InformePersonalPIA[]> ObtenerInformesPersonalesPIAAsync(int page, int total, int tuteladoId);
}
