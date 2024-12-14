using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlCuentasGenerales;

[Injectable]
public class ControlCuentaGeneralHandler(IControlCuentaGeneralRepository controlCuentaGeneralRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<ControlCuentaGeneral> HandleAsync(int id)
    {
        var controlCuentaGeneral = await controlCuentaGeneralRepository.GetByIdAsync(id) ?? throw new NotFoundException("Control de CuentaGeneral no encontrado");
        if (!await tuteladoRepository.CanViewAsync(controlCuentaGeneral.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return controlCuentaGeneral;
    }
}