using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Objetivos;

[Injectable]
public class ObjetivosHandler(ITuteladoObjetivoRepository tuteladoObjetivoRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<TuteladoObjetivo[]> HandleAsync(int tuteladoId, int tipoObjetivoId)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para ver los datos del tutelado");
        return await tuteladoObjetivoRepository.ObtenerObjetivosAsync(tuteladoId, tipoObjetivoId);
    }
}