using AutoMapper;
using Peiton.Contracts.Emergencias;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.UseCases.Seguimientos;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;
using Peiton.Contracts.Seguimientos;
using Peiton.Core.Services;

namespace Peiton.Core.UseCases.Emergencias;

[Injectable]
public class CrearEmergenciaHandler(IMapper mapper, IEmergenciaRepository emergenciaRepository, ITuteladoRepository tuteladoRepository, IUsuarioRepository usuarioRepository,
                                    IComunicacionesService comunicacionesService, CrearSeguimientoHandler crearSeguimientoHandler, IUnitOfWork unitOfWork)
{
    private static readonly int[] categoriasNotificacion = [ 1, 3, 4, 7, 14, 17 ];
    public async Task HandleAsync(CrearEmergenciaRequest request)
    {
        if(!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        
        var emergencia = mapper.Map(request, new Emergencia());
        emergenciaRepository.Add(emergencia);
        await unitOfWork.SaveChangesAsync();
        
        var emergenciaId = emergencia.Id;
        unitOfWork.Clear();

        var newEmergencia = await emergenciaRepository.GetByIdAsync(emergenciaId) ?? throw new NotFoundException("Emergencia no encontrada");

        List<string> lines = [$"Motivo: {newEmergencia.MotivoEmergencia.Descripcion}"];
        
        if(newEmergencia.EmergenciaLlamada != null){
            lines.AddRange(["", $"Llamada: {newEmergencia.EmergenciaLlamada.Descripcion}"]);
        }

        lines.AddRange(["", "", request.Descripcion]);

        await crearSeguimientoHandler.HandleAsync(new CrearSeguimientoRequest(){
            TuteladoId = request.TuteladoId,
            CategoriaAgendaId = 5,
            Descripcion =  string.Join(Environment.NewLine, lines),
            FechaActuacion =  request.Fecha,
            Alertas = []
        });
        
        var tutelado = newEmergencia.Tutelado;
        List<int> userIds = [];
        
        if(tutelado.Abogado != null){
            var abogado = await usuarioRepository.ObtenerUsuarioAsync(tutelado.Abogado.Nombre);
            if(abogado != null) userIds.Add(abogado.Id);
        }

        if(tutelado.TrabajadorSocial != null){
            var trabajador = await usuarioRepository.ObtenerUsuarioAsync(tutelado.TrabajadorSocial.Nombre);
            if(trabajador != null) userIds.Add(trabajador.Id);
        }
        
        int[]? groupIds = categoriasNotificacion.Contains(request.MotivoEmergenciaId) ? [17, 16, 14] : null;

        await comunicacionesService.EnviarMensajeAsync(new (){
            Subject = $"Emergencia Social 112: {tutelado.NombreCompleto}",
            UserIds = userIds,
            GroupIds = groupIds,
            Body = $"<div>{string.Join("<br />", lines)}</div>",
            CssClass = "naranja",             
        });
    }
}