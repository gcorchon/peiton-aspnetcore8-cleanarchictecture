using Peiton.Contracts.Tutelados;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tutelados;

[Injectable]
public class DatosGeneralesHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task HandleAsync(int id)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(id);
    }
}