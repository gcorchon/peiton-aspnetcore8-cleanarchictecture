using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SueldosPensiones;

[Injectable]
public class SueldosPensionesHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<SueldoPension[]> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId);
        if (tutelado == null) throw new EntityNotFoundException("Tutelado no encontrado");
        return tutelado.SueldosPensiones.ToArray();
    }
}