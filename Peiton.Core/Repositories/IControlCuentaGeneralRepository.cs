using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IControlCuentaGeneralRepository : IRepository<ControlCuentaGeneral>
{
    Task<ControlCuentaGeneral[]> ObtenerControlCuentasGeneralesAsync(int tuteladoId);
}
