using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tutelados;

[Injectable]
public class TuteladoHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<Tutelado> HandleAsync(int id)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(id);
        if (tutelado == null) throw new NotFoundException("Tutelado no encontrado");
        return tutelado;
    }
}