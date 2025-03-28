using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class FondoSolidarioHandler(IFondoSolidarioRepository fondoSolidarioRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<FondoSolidario> HandleAsync(int id)
    {
        var fondo = await fondoSolidarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Fondo no encontrado");
        if (!await tuteladoRepository.CanViewAsync(fondo.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return fondo;
    }
}