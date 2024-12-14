using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlCuentasGenerales;

[Injectable]
public class BorrarControlCuentaGeneralHandler(IControlCuentaGeneralRepository controlCuentaGeneralRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var controlCuentaGeneral = await controlCuentaGeneralRepository.GetByIdAsync(id) ?? throw new NotFoundException("Control de CuentaGeneral no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(controlCuentaGeneral.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        controlCuentaGeneralRepository.Remove(controlCuentaGeneral);
        await unitOfWork.SaveChangesAsync();
    }
}