using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SegurosAhorro;

[Injectable]
public class BorrarSeguroAhorroHandler(ISeguroAhorroRepository SeguroAhorroRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var SeguroAhorro = await SeguroAhorroRepository.GetByIdAsync(id);
        if (SeguroAhorro == null) throw new NotFoundException("Seguro de ahorro no encontrada");

        if (!await tuteladoRepository.CanModifyAsync(SeguroAhorro.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        SeguroAhorroRepository.Remove(SeguroAhorro);
        await unitOfWork.SaveChangesAsync();
    }
}