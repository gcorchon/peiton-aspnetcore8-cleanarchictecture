using AutoMapper;
using Peiton.Contracts.Facturas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Facturas;

[Injectable]
public class CrearFacturaHandler(IMapper mapper, IFacturaRepository facturaRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(GuardarFacturaRequest request)
    {
        var factura = new Factura();
        mapper.Map(request, factura);
        await facturaRepository.AddAsync(factura);
        await unityOfWork.SaveChangesAsync();
    }

}