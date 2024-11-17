using AutoMapper;
using Peiton.Contracts.Mensajes;
using Peiton.Contracts.Senalamientos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Senalamientos;

[Injectable]
public class ActualizarSenalamientoHandler(ISenalamientoRepository senalamientoRepository, IUnitOfWork unitOfWork, IMapper mapper, IUsuarioRepository usuarioRepository, IComunicacionesService comunicacionesService, IAbogadoRepository abogadoRepository)
{
    public async Task HandleAsync(int id, GuardarSenalamientoRequest request)
    {
        var senalamiento = await senalamientoRepository.GetByIdAsync(id);

        if (senalamiento == null) throw new NotFoundException("No existe el señalamiento");

        mapper.Map(request, senalamiento);
        await unitOfWork.SaveChangesAsync();

        if (senalamiento.AbogadoAsistenteId == null) return;

        var abogado = await abogadoRepository.GetByIdAsync(senalamiento.AbogadoAsistenteId.Value);

        var usuario = await usuarioRepository.ObtenerUsuarioAsync(abogado!.Nombre);

        if (usuario == null) return;


        await comunicacionesService.EnviarMensajeAsync(new Whasapeiton()
        {
            UserIds = [usuario.Id],
            Subject = "Nuevo señalamiento",
            Body = string.Format(@"<p>Nuevo señalamiento asignado:</p>
                                        <div>
                                        <ul>
                                        <li>Tutelado: {0}</li>
                                        <li>Procedimiento: {1}</li>
                                        <li>Juzgado: {2}</li>
                                        <li>Fecha: {3:dd/MM/yyyy}</li>
                                        <li>Hora: {4:HH:mm}</li>
                                        </ul>
                                        <p>{5}</p></div>
                                    ", senalamiento.Tutelado, senalamiento.Procedimiento,
                                        senalamiento.Juzgado?.Descripcion, senalamiento.Fecha, senalamiento.Fecha,
                                        senalamiento.Descripcion)
        });
    }
}