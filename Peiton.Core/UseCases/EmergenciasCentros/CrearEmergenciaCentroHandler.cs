using AutoMapper;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.UseCases.Seguimientos;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;
using Peiton.Contracts.Seguimientos;
using Peiton.Core.Services;
using Peiton.Contracts.EmergenciasCentros;
using Peiton.Configuration;
using Microsoft.Extensions.Options;

namespace Peiton.Core.UseCases.EmergenciasCentros;

[Injectable]
public class CrearEmergenciaCentroHandler(IMapper mapper, IEmergenciaCentroRepository emergenciaCentroRepository, ITuteladoRepository tuteladoRepository, IUsuarioRepository usuarioRepository,
                                    IComunicacionesService comunicacionesService, CrearSeguimientoHandler crearSeguimientoHandler, IUnitOfWork unitOfWork,
                                    IOptions<AppSettings> appSettings)
{
    private static readonly int[] categoriasNotificacion = [ 1, 3, 4, 7, 14, 17 ];
    public async Task HandleAsync(CrearEmergenciaCentroRequest request)
    {
        if(!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        
        var emergenciaCentro = mapper.Map(request, new EmergenciaCentro());
        emergenciaCentroRepository.Add(emergenciaCentro);
        await unitOfWork.SaveChangesAsync();
        
        var emergenciaCentroId = emergenciaCentro.Id;
        unitOfWork.Clear();

        var newEmergencia = await emergenciaCentroRepository.GetByIdAsync(emergenciaCentroId) ?? throw new NotFoundException("Emergencia no encontrada");

        List<string> lines = [$"Motivo: {newEmergencia.MotivoEmergenciaCentro.Descripcion}"];

        lines.AddRange(["", "", request.Descripcion]);

        await crearSeguimientoHandler.HandleAsync(new CrearSeguimientoRequest(){
            TuteladoId = request.TuteladoId,
            CategoriaAgendaId = 7,
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

        if(appSettings.Value.Cliente == "AMTA"){
            userIds.Add(121); //Elvira Cortón Mauriz
        }
        
        int[]? groupIds = categoriasNotificacion.Contains(request.MotivoEmergenciaCentroId) ? [17, 16, 14] : null;

        await comunicacionesService.EnviarMensajeAsync(new (){
            Subject = $"Emergencia Centro: {tutelado.NombreCompleto}",
            UserIds = userIds,
            GroupIds = groupIds,
            Body = $"<div>{string.Join("<br />", lines)}</div>",
            //CssClass = "naranja",       // En el momento de la reprogramación en la versión antigua de Peiton se marcan como naranjas estos mensajes      
        });
    }
}