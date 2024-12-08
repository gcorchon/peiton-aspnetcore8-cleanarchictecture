using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.TuAppoyo;

[Injectable]
public class ConfiguracionTuAppoyoHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<TeAppoyo> HandleAsync(int id)
    {
        if(!await tuteladoRepository.CanViewAsync(id)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        var tutelado = await tuteladoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Tutelado no encontrado");       

        return tutelado.TeAppoyo ?? new TeAppoyo();
    }
}