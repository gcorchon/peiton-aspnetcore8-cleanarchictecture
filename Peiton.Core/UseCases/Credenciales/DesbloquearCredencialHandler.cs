using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales;
[Injectable]
public class DesbloquearCredencialHandler(ICredencialRepository credencialRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var credencial = await credencialRepository.GetByIdAsync(id);

        if (credencial == null) throw new NotFoundException();

        credencial.DatosCorrectos = true;
        credencial.Reintentos = 0;
        credencial.ProximaEjecucion = DateTime.Now;

        await unitOfWork.SaveChangesAsync();
    }
}



