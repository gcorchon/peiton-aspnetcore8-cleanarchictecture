using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Clientes;

[Injectable]
public class BorrarClienteHandler(IClienteRepository clienteRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id)
    {
        var cliente = await clienteRepository.GetByIdAsync(id);
        if (cliente == null) throw new NotFoundException($"El cliente con Id {id} no existe");
        cliente.Activo = false;

        await unityOfWork.SaveChangesAsync();
    }

}
