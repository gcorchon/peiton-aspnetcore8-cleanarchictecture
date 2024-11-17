using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tributos;

[Injectable]
public class TributosHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<TributoTutelado[]> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId);
        if (tutelado == null) throw new NotFoundException("Tutelado no encontrado");
        return tutelado.TributosTutelados.ToArray();
    }
}