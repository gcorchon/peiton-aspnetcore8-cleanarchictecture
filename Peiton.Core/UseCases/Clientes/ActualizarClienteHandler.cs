using Peiton.Contracts.Clientes;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Clientes;

[Injectable]
public class ActualizarClienteHandler(IClienteRepository clienteRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id, GuardarClienteRequest request)
    {
        var cliente = await clienteRepository.GetByIdAsync(id);
        if (cliente == null) throw new NotFoundException($"El cliente con Id {id} no existe");
        cliente.Nombre = request.Nombre;
        cliente.CIF = request.CIF;
        cliente.CodCliente = request.CodCliente;

        await unityOfWork.SaveChangesAsync();
    }

}
