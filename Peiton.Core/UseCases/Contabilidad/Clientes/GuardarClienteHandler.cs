using Peiton.Contracts.Clientes;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Clientes;

[Injectable]
public class GuardarClienteHandler(IClienteRepository clienteRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(GuardarClienteRequest request)
    {
        var cliente = new Cliente()
        {
            Nombre = request.Nombre,
            CIF = request.CIF,
            CodCliente = request.CodCliente,
            Activo = true
        };

        clienteRepository.Add(cliente);

        await unityOfWork.SaveChangesAsync();
    }

}
