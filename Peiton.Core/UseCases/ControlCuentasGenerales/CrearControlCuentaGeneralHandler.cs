using AutoMapper;
using Peiton.Contracts.ControlCuentasGenerales;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlCuentasGenerales;

[Injectable]
public class CrearControlCuentaGeneralHandler(IMapper mapper, IControlCuentaGeneralRepository controlCuentaGeneralRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearControlCuentaGeneralRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        var controlCuentaGeneral = mapper.Map(request, new ControlCuentaGeneral());
        controlCuentaGeneralRepository.Add(controlCuentaGeneral);
        await unitOfWork.SaveChangesAsync();
    }
}