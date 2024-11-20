using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Inmuebles;

[Injectable]
public class BorrarInmuebleHandler(IInmuebleRepository inmuebleRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var inmueble = await inmuebleRepository.GetByIdAsync(id) ?? throw new NotFoundException("Inmueble no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(inmueble.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        inmuebleRepository.Remove(inmueble);

        await unitOfWork.SaveChangesAsync();
    }
}