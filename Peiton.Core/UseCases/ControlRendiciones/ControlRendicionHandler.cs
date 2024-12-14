using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlRendiciones;

[Injectable]
public class ControlRendicionHandler(IControlRendicionRepository controlRendicionRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<ControlRendicion> HandleAsync(int id)
    {
        var controlRendicion = await controlRendicionRepository.GetByIdAsync(id) ?? throw new NotFoundException("Control de Rendicion no encontrado");
        if (!await tuteladoRepository.CanViewAsync(controlRendicion.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return controlRendicion;
    }
}