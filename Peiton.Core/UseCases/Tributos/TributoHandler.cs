using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tributos;

[Injectable]
public class TributoHandler(ITributoTuteladoRepository tributoTuteladoRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<TributoTutelado> HandleAsync(int id)
    {
        var tributo = await tributoTuteladoRepository.GetByIdAsync(id);
        if (tributo == null) throw new NotFoundException("Tributo no encontrado");

        if (!await tuteladoRepository.CanViewAsync(tributo.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        return tributo;
    }
}