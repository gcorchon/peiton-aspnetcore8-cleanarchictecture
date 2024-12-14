using AutoMapper;
using Peiton.Contracts.ControlRendiciones;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlRendiciones;

[Injectable]
public class ActualizarControlRendicionHandler(IMapper mapper, IControlRendicionRepository controlRendicionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarControlRendicionRequest request)
    {
        var controlRendicion = await controlRendicionRepository.GetByIdAsync(id) ?? throw new NotFoundException("Control de Rendicion no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(controlRendicion.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        mapper.Map(request, controlRendicion);
        await unitOfWork.SaveChangesAsync();
    }
}