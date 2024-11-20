using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tributos;

[Injectable]
public class BorrarTributoHandler(ITributoTuteladoRepository tributoTuteladoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var tributoTutelado = await tributoTuteladoRepository.GetByIdAsync(id);
        if (tributoTutelado == null) throw new NotFoundException("Tributo no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(tributoTutelado.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        tributoTuteladoRepository.Remove(tributoTutelado);

        await unitOfWork.SaveChangesAsync();
    }
}