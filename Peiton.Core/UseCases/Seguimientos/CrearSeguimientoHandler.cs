using AutoMapper;
using Peiton.Contracts.Seguimientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Seguimientos;

[Injectable]
public class CrearSeguimientoHandler(IMapper mapper, IAgendaRepository agendaRepository, ITuteladoRepository tuteladoRepository,
                                    IIdentityService identityService, IUnitOfWork unitOfWork,
                                    AlertasHelper alertasHelper)
{
    public async Task HandleAsync(CrearSeguimientoRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var seguimiento = mapper.Map(request, new Agenda());
        seguimiento.UsuarioId = identityService.GetUserId();
        seguimiento.Fecha = DateTime.Now;
        await alertasHelper.CargarAlertasAsync(seguimiento, request.Alertas);

        agendaRepository.Add(seguimiento);
        await unitOfWork.SaveChangesAsync();

        await alertasHelper.EnviarAlertasAsync(seguimiento, request.Alertas);
    }
}