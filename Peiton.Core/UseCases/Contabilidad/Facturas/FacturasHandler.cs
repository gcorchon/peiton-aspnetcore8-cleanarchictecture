using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Facturas;

[Injectable]
public class FacturasHandler( IFacturaRepository facturaRepository)
{    
    public Task<List<Factura>> HandleAsync(int[] ids) =>
        facturaRepository.ObtenerFacturasAsync(ids);
}