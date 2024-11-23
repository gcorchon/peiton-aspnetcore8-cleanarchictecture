using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Shares;

[Injectable]
public class DarDeBajaHandler(IShareRepository shareRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var share = await shareRepository.GetByIdAsync(id) ?? throw new NotFoundException("Cuenta de valores no encontrada");
        if (!await tuteladoRepository.CanModifyAsync(share.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        if (share.Baja) return;
        share.Baja = true;
        share.FechaBaja = DateTime.Now;
        await unitOfWork.SaveChangesAsync();
    }
}