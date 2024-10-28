using Peiton.Contracts.EntidadFinanciera;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IEntidadFinancieraRepository : IRepository<EntidadFinanciera>
{
	Task<EntidadFinancieraViewModel[]> ObtenerEntidadesConCuentasActivasAsync(int tuteladoId);
}
