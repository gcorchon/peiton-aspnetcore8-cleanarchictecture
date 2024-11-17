using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.EfectosPublicos;

[Injectable]
public class EfectosPublicosHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<EfectoPublico[]> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId);
        if (tutelado == null) throw new NotFoundException("Tutelado no encontrado");
        return tutelado.EfectosPublicos.ToArray();
    }
}