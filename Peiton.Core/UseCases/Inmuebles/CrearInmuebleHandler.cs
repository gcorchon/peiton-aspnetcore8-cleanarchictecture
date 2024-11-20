using AutoMapper;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Inmuebles;

[Injectable]
public class CrearInmuebleHandler(IMapper mapper, IInmuebleRepository inmuebleRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearInmuebleRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var inmueble = mapper.Map(request, new Inmueble());
        inmuebleRepository.Add(inmueble);
        await unitOfWork.SaveChangesAsync();
    }
}