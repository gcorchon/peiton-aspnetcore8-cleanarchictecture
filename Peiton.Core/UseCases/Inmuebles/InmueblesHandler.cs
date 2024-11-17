using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Inmuebles;

[Injectable]
public class InmueblesHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<Inmueble[]> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        return tutelado.Inmuebles.ToArray();
    }
}