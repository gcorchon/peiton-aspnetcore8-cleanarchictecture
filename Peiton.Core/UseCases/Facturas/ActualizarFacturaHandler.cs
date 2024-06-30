using AutoMapper;
using Peiton.Contracts.Facturas;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Facturas;

[Injectable]
public class ActualizarFacturaHandler(IMapper mapper, IFacturaRepository facturaRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id, GuardarFacturaRequest request)
    {
        var factura = await facturaRepository.GetByIdAsync(id);

        if (factura == null)
        {
            throw new NotFoundException($"No existe la factura con Id {id}");
        }

        mapper.Map(request, factura);
        await unityOfWork.SaveChangesAsync();
    }

}