using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales;

[Injectable]
public class BorrarCredencialHandler(ICredencialRepository credencialRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var credencial = await credencialRepository.GetByIdAsync(id) ?? throw new NotFoundException("Credencial no encontrada");
        if (!await tuteladoRepository.CanModifyAsync(credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        credencialRepository.Remove(credencial);
        await unitOfWork.SaveChangesAsync();
    }
}