using AutoMapper;
using Peiton.Contracts.Seguimientos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Seguimientos;

[Injectable]
public class ActualizarSeguimientoHandler(IMapper mapper, IAgendaRepository agendaRepository, ITuteladoRepository tuteladoRepository,
                                          IUnitOfWork unitOfWork, AlertasHelper alertasHelper)
{
    public async Task HandleAsync(int id, ActualizarSeguimientoRequest request)
    {
        var seguimiento = await agendaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Entrada de seguimiento no encontrada");
        if (!await tuteladoRepository.CanModifyAsync(seguimiento.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        mapper.Map(request, seguimiento);
        seguimiento.Fecha = DateTime.Now;
        await alertasHelper.CargarAlertasAsync(seguimiento, request.Alertas);
        await unitOfWork.SaveChangesAsync();

        await alertasHelper.EnviarAlertasAsync(seguimiento, request.Alertas);
    }
}