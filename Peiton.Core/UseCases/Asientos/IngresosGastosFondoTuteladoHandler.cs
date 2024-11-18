using Peiton.Contracts.Asientos;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Asientos;

[Injectable]
public class IngresosGastosFondoTuteladoHandler(IAsientoRepository asientoRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<IngresosGastos> HandleAsync(int tuteladoId)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver los datos del tutelado");
        return await asientoRepository.ObtenerIngresosYGastosFondoTuteladoAsync(tuteladoId);
    }
}