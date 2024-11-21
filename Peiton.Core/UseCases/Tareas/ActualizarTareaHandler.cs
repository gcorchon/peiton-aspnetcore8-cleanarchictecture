using AutoMapper;
using Peiton.Contracts.Tareas;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tareas;

[Injectable]
public class ActualizarTareaHandler(IMapper mapper, ITareaRepository agendaRepository, ITuteladoRepository tuteladoRepository,
                                          IUnitOfWork unitOfWork, TareasHelper tareasHelper)
{
    public async Task HandleAsync(int id, ActualizarTareaRequest request)
    {
        var tarea = await agendaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Tarea no encontrada");
        if (!await tuteladoRepository.CanModifyAsync(tarea.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var distribuidorAnterior = tarea.UsuarioDistribuidorId;
        var gestorAnterior = tarea.UsuarioGestorId;
        var estadoAnterior = tarea.TareaEstadoId;

        var haCambiadoComentarioDistribuidor = !string.IsNullOrWhiteSpace(request.ComentariosDistribuidor) && tarea.ComentariosDistribuidor != request.ComentariosDistribuidor;
        var haCambiadoComentarioGestor = !string.IsNullOrWhiteSpace(request.ComentariosGestor) && tarea.ComentariosGestor != request.ComentariosGestor;
        var haCambiadoAFinalizado = request.TareaEstadoId == 3 && tarea.TareaEstadoId != 3;

        mapper.Map(request, tarea);

        if (estadoAnterior != 3 && request.TareaEstadoId == 3)
        {
            tarea.FechaCierre = DateTime.Now;
        }
        else if (request.TareaEstadoId != 3)
        {
            tarea.FechaCierre = null;
        }

        tarea.Fecha = DateTime.Now;

        await tareasHelper.CargarAlertasAsync(tarea, request.Alertas);

        await unitOfWork.SaveChangesAsync();

        unitOfWork.Clear();

        if (request.UsuarioDistribuidorId.HasValue && request.UsuarioDistribuidorId != distribuidorAnterior)
        {
            await tareasHelper.EnviarNuevaTareaADistribuidorAsync(id);
        }

        if (request.UsuarioGestorId.HasValue && request.UsuarioGestorId != gestorAnterior)
        {
            await tareasHelper.EnviarNuevaTareaAGestorAsync(id);
        }

        if (haCambiadoAFinalizado)
        {
            await tareasHelper.ComunicarFinalizacionTareaAsync(id);
        }

        if (haCambiadoComentarioGestor || haCambiadoComentarioDistribuidor)
        {
            await tareasHelper.ComunicarCambiosEnComentariosAsync(id, haCambiadoComentarioGestor, haCambiadoComentarioDistribuidor);
        }

        await tareasHelper.EnviarAlertasAsync(id, request.Alertas);
    }
}