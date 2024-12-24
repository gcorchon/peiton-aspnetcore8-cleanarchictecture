using Peiton.Contracts.Account;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IDatosEconomicosRepository : IRepository<DatosEconomicos>
{
    Task<IEnumerable<ProductoBancarioConSaldoListItem>> ObtenerProductosRendicionAsync(int tuteladoId, DateTime fechaDesde, DateTime fechaHasta);
    Task<IEnumerable<JustificacionIngresosYGastos>> ObtenerJustificaionIngresosYGastosAsync(int tuteladoId, DateTime fechaDesde, DateTime fechaHasta);
}
