using Peiton.Contracts.GestoresAdministrativos;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
    public interface IGestionAdministrativaRepository : IRepository<GestionAdministrativa>
    {
        Task<List<GestionAdministrativa>> ObtenerGestionesAdministrativasAsync(int page, int total, GestionesAdministrativasFilter filter);
        Task<int> ContarGestionesAdministrativasAsync(GestionesAdministrativasFilter filter);
    }
}