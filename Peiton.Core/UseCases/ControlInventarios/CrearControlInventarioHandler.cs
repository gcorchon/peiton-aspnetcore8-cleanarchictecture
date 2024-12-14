using AutoMapper;
using Peiton.Contracts.ControlInventarios;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlInventarios;

[Injectable]
public class CrearControlInventarioHandler(IMapper mapper, IControlInventarioRepository controlInventarioRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearControlInventarioRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        var controlInventario = mapper.Map(request, new ControlInventario());
        controlInventarioRepository.Add(controlInventario);
        await unitOfWork.SaveChangesAsync();
    }
}