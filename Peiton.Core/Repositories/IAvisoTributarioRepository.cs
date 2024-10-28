using Peiton.Contracts.AvisosTributarios;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IAvisoTributarioRepository : IRepository<AvisoTributario>
{
    Task<int> ContarAvisosTributariosAsync(AvisosTributariosFilter filter);
    Task<AvisoTributario[]> ObtenerAvisosTributariosAsync(int page, int total, AvisosTributariosFilter filter);
}
