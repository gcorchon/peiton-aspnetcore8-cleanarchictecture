using Peiton.Contracts.Clientes;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Clientes;

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

        await clienteRepository.AddAsync(cliente);

        await unityOfWork.SaveChangesAsync();
    }

}
