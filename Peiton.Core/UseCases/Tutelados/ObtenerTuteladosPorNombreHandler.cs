using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tutelados;

[Injectable]
public class ObtenerTuteladosPorNombreHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<List<Tutelado>> HandleAsync(string query, int total = 10)
    {
        return await tuteladoRepository.ObtenerTuteladosPorNombreAsync(query, total);
    }
}