using AutoMapper;
using Peiton.Contracts.ControlRendiciones;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlRendiciones;

[Injectable]
public class CrearControlRendicionHandler(IMapper mapper, IControlRendicionRepository controlRendicionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearControlRendicionRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        var controlRendicion = mapper.Map(request, new ControlRendicion());
        controlRendicionRepository.Add(controlRendicion);
        await unitOfWork.SaveChangesAsync();
    }
}