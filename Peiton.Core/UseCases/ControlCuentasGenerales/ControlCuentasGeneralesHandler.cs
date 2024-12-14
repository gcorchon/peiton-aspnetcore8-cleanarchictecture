using Peiton.Contracts.ControlCuentasGenerales;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlCuentasGenerales;

[Injectable]
public class ControlCuentasGeneralesHandler(IControlCuentaGeneralRepository controlCuentaGeneralRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<ControlCuentaGeneral[]> HandleAsync(int tuteladoId)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return await controlCuentaGeneralRepository.ObtenerControlCuentasGeneralesAsync(tuteladoId);
    }
}