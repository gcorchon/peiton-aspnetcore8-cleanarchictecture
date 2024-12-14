using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlRendiciones;

[Injectable]
public class ObtenerRetribucionContinuadaHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<bool> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        return tutelado.RetribucionContinuada;
    }
}