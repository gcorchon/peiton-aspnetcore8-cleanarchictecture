using AutoMapper;

using Peiton.Contracts.Inmuebles;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Inmuebles;

[Injectable]
public class ActualizarInmuebleHandler(IMapper mapper, IInmuebleRepository inmuebleRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, InmuebleViewModel request)
    {
        var inmueble = await inmuebleRepository.GetByIdAsync(id) ?? throw new NotFoundException("Inmueble no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(inmueble.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        mapper.Map(request, inmueble);

        await unitOfWork.SaveChangesAsync();
    }
}