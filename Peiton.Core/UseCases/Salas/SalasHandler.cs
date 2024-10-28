using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Salas;

[Injectable]
public class SalasHandler(ISalaRepository salaRepository)
{
    public async Task<Sala[]> HandleAsync()
    {
        return await salaRepository.GetAllAsync(s => s.Descripcion, "asc");
    }
}