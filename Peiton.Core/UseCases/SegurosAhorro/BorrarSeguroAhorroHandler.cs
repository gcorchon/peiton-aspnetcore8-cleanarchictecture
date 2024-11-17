using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SegurosAhorro;

[Injectable]
public class BorrarSeguroAhorroHandler(ISeguroAhorroRepository SeguroAhorroRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var SeguroAhorro = await SeguroAhorroRepository.GetByIdAsync(id);
        if (SeguroAhorro == null) throw new NotFoundException("Seguro de ahorro no encontrada");

        if (!await tuteladoRepository.CanModifyAsync(SeguroAhorro.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");
        SeguroAhorroRepository.Remove(SeguroAhorro);
        await unitOfWork.SaveChangesAsync();
    }
}