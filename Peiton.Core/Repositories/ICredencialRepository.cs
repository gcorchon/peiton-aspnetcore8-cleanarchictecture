using Peiton.Contracts.Bancos;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ICredencialRepository : IRepository<Credencial>
{
    Task<Credencial[]> ObtenerCredencialesBloqueadasAsync(CredencialesBloqueadasFilter filter);
    Task<Credencial[]> ObtenerCredencialesBloqueadasAsync(int page, int total, CredencialesBloqueadasFilter filter);
    Task<int> ContarCredencialesBloqueadasAsync(CredencialesBloqueadasFilter filter);
    Task DesbloquearCredencialesAsync();

}
