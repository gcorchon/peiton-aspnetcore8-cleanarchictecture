using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SueldosPensiones;

[Injectable]
public class BorrarSueldoPensionHandler(ISueldoPensionRepository sueldoPensionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var sueldoPension = await sueldoPensionRepository.GetByIdAsync(id);
        if (sueldoPension == null) throw new NotFoundException("Sueldo o pensión no encontrada");

        if (!await tuteladoRepository.CanModifyAsync(sueldoPension.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        sueldoPensionRepository.Remove(sueldoPension);
        await unitOfWork.SaveChangesAsync();
    }
}