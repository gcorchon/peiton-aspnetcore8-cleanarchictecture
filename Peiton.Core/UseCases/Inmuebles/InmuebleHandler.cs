using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Inmuebles;

[Injectable]
public class InmuebleHandler(IInmuebleRepository inmuebleRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<Inmueble> HandleAsync(int id)
    {
        var inmueble = await inmuebleRepository.GetByIdAsync(id) ?? throw new NotFoundException("inmueble no encontrado");
        if (!await tuteladoRepository.CanViewAsync(inmueble.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        return inmueble;
    }
}