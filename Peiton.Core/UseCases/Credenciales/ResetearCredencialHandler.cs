using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales;

[Injectable]
public class ResetearCredencialHandler(ICredencialRepository credencialRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var credencial = await credencialRepository.GetByIdAsync(id) ?? throw new NotFoundException("Credencial no encontrada");
        if (!await tuteladoRepository.CanModifyAsync(credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        credencial.UltimaEjecucion = null;
        credencial.UltimaEjecucionCorrecta = null;
        credencial.Reintentos = 0;
        credencial.ProximaEjecucion = DateTime.Now;

        await unitOfWork.SaveChangesAsync();
    }
}