using Peiton.Contracts.Facturas;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IFacturaRepository : IRepository<Factura>
{
    Task<int> ContarFacturasAsync(FacturasFilter filter);
    Task<Factura[]> ObtenerFacturasAsync(int page, int total, FacturasFilter filter);
    Task<Factura[]> ObtenerFacturasAsync(int[] ids);
}
