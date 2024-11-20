using Peiton.Contracts.Common;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tutelados;

[Injectable]
public class EquipoHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<IEnumerable<ListItem>> HandleAsync(int id)
    {
        return await tuteladoRepository.ObtenerEquipoAsync(id);
    }
}