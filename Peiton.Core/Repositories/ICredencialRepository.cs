using Peiton.Contracts.Bancos;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ICredencialRepository : IRepository<Credencial>
{
    Task<List<Credencial>> ObtenerCredencialesBloqueadasAsync(CredencialesBloqueadasFilter filter);
    Task<List<Credencial>> ObtenerCredencialesBloqueadasAsync(int page, int total, CredencialesBloqueadasFilter filter);
    Task<int> ContarCredencialesBloqueadasAsync(CredencialesBloqueadasFilter filter);
    Task DesbloquearCredenciales();

}
