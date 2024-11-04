using AutoMapper;
using Peiton.Contracts.Mensajes;
using Peiton.Contracts.Senalamientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Senalamientos;

[Injectable]
public class CrearSenalamientoHandler(ISenalamientoRepository senalamientoRepository, IUnitOfWork unitOfWork, IMapper mapper, IComunicacionesService comunicacionesService, IUsuarioRepository usuarioRepository, IAbogadoRepository abogadoRepository)
{
    public async Task HandleAsync(GuardarSenalamientoRequest request)
    {
        var senalamiento = mapper.Map<Senalamiento>(request);
        senalamientoRepository.Add(senalamiento);
        await unitOfWork.SaveChangesAsync();

        if (senalamiento.AbogadoAsistenteId == null)
            return;

        //He probado de todas las formas habidas y por haber para coger el abogado directamente del objeto Señalamiento
        //que acabo de meter en la base de datos, pero no se actualiza el objeto ni mediante una carga explícita con GetByIdAsync
        //Es posible que no se esté actualizando porque la entidad ya se encuentra en el DbContext
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