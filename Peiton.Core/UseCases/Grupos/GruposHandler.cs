
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Grupos;

[Injectable]
public class GruposHandler(IGrupoRepository grupoRepository)
{
    public async Task<Grupo[]> HandleAsync()
    {
        return await grupoRepository.ObtenerGruposConUsuariosAsync();
    }
}