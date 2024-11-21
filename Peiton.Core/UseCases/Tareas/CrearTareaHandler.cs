using AutoMapper;
using Peiton.Contracts.Tareas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tareas;

[Injectable]
public class CrearTareaHandler(IMapper mapper, IIdentityService identityService, ITuteladoRepository tuteladoRepository, ITareaRepository tareaRepository,
                               IUnitOfWork unitOfWork, TareasHelper tareasHelper)
{
    public async Task HandleAsync(CrearTareaRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var tarea = mapper.Map(request, new Tarea());

        tarea.UsuarioSolicitanteId = identityService.GetUserId();
        tarea.Fecha = DateTime.Now;

        await tareasHelper.CargarAlertasAsync(tarea, request.Alertas);

        tareaRepository.Add(tarea);

        await unitOfWork.SaveChangesAsync();

        unitOfWork.Clear(); //Dejar de trackear las entidades para que tenga que volver a leer todo de base de datos ya que le entidad Tarea no tiene cargadas las propiedades de navegación

        if (request.UsuarioDistribuidorId.HasValue)
        {
            Console.WriteLine("Debería Enviar mensaje al Distribuidor");
            await tareasHelper.EnviarNuevaTareaADistribuidorAsync(tarea.Id);
        }

        if (request.UsuarioGestorId.HasValue)
        {
            Console.WriteLine("Debería Enviar mensaje al Gestor");
            await tareasHelper.EnviarNuevaTareaAGestorAsync(tarea.Id);
        }

        await tareasHelper.EnviarAlertasAsync(tarea.Id, request.Alertas);
    }
}