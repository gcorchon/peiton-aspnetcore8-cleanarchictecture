using Peiton.Contracts.Consultas;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ConsultasAlmacenadas;

[Injectable]
public class ActualizarConsultaAlmacenadaHandler(IUnitOfWork unitOfWork, IEntityService entityService)
{
    public async Task HandleAsync(int id, ActualizarConsultaRequest data)
    {
        var consultaAlmacenada = await entityService.GetEntityAsync<ConsultaAlmacenada>(id);
        if (consultaAlmacenada == null) throw new EntityNotFoundException();

        consultaAlmacenada.Descripcion = data.Descripcion;
        consultaAlmacenada.Resumen = data.Resumen;
        consultaAlmacenada.CategoriaConsultaId = data.CategoriaId;

        var usuarioIds = data.Usuarios.Where(u => u.Tipo == 1).Select(u => u.Id);
        var grupoIds = data.Usuarios.Where(u => u.Tipo == 2).Select(u => u.Id);

        consultaAlmacenada.Usuarios.Merge(usuarioIds, u => u.Id, v => entityService.GetEntity<Usuario>(v));
        consultaAlmacenada.Grupos.Merge(grupoIds, g => g.Id, v => entityService.GetEntity<Grupo>(v));

        await unitOfWork.SaveChangesAsync();
    }

}