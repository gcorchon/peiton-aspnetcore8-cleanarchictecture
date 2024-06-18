using Peiton.Contracts.Consultas;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva.Consultas;

[Injectable]
public class ActualizarConsultaAlmacenadaHandler(IUnityOfWork unityOfWork, IEntityService entityService)
{
    public async Task HandleAsync(int id, ActualizarConsultaRequest data)
    {
        var consultaAlmacenada = await entityService.GetEntityAsync<ConsultaAlmacenada>(id);
        if (consultaAlmacenada == null) throw new NotFoundException();

        consultaAlmacenada.Descripcion = data.Descripcion;
        consultaAlmacenada.Resumen = data.Resumen;
        consultaAlmacenada.CategoriaConsultaId = data.CategoriaId;

        var usuarioIds = data.Usuarios.Where(u => u.Tipo == 1).Select(u => u.Id).ToList();
        var grupoIds = data.Usuarios.Where(u => u.Tipo == 2).Select(u => u.Id).ToList();

        foreach(var usuarioId in usuarioIds)
        {
            if(consultaAlmacenada.Usuarios.SingleOrDefault(u => u.Id == usuarioId) == null)
            {
                var usuario = await entityService.GetEntityAsync<Usuario>(usuarioId);
                if (usuario == null)
                {
                    throw new ArgumentException("Usuario incorrecto");
                }
                consultaAlmacenada.Usuarios.Add(usuario);
            }
        }

        var usuariosAEliminar = consultaAlmacenada.Usuarios.Where(u => !usuarioIds.Contains(u.Id)).ToList();
        
        foreach(var usuario in usuariosAEliminar)
        {
            consultaAlmacenada.Usuarios.Remove(usuario);
        }

        foreach (var grupoId in grupoIds)
        {
            if (consultaAlmacenada.Grupos.SingleOrDefault(u => u.Id == grupoId) == null)
            {
                var grupo = await entityService.GetEntityAsync<Grupo>(grupoId);
                if (grupo == null)
                {
                    throw new ArgumentException("Usuario incorrecto");
                }
                consultaAlmacenada.Grupos.Add(grupo);
            }
        }

        var gruposAEliminar = consultaAlmacenada.Grupos.Where(u => !grupoIds.Contains(u.Id)).ToList();
        foreach (var grupo in gruposAEliminar)
        {
            consultaAlmacenada.Grupos.Remove(grupo);
        }


        await unityOfWork.SaveChangesAsync();
    }

}