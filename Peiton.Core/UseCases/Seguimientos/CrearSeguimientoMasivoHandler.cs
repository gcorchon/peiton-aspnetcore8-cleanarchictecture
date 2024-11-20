using AutoMapper;
using Peiton.Contracts.Seguimientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Seguimientos;

[Injectable]
public class CrearSeguimientoMasivoHandler(IMapper mapper, IAgendaRepository agendaRepository, IIdentityService identityService, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearSeguimientoMasivoRequest request)
    {
        var userId = identityService.GetUserId();
        var fecha = DateTime.Now;

        agendaRepository.AddRange(request.TuteladoIds.Select(id => mapper.Map(request, new Agenda() { TuteladoId = id, Fecha = fecha, UsuarioId = userId, Desacuerdo = false })));

        await unitOfWork.SaveChangesAsync();
    }
}