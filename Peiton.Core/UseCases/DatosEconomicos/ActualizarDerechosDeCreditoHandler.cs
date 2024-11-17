using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.DatosEconomicos;

[Injectable]
public class ActualizarDerechosDeCreditoHandler(IDatosEconomicosRepository datosEconomicosRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, string? derechosDeCredito)
    {
        var datosEconomicos = await datosEconomicosRepository.GetAsync(d => d.TuteladoId == id);
        if (datosEconomicos == null) throw new NotFoundException("Datos económicos no encontrados");
        datosEconomicos.DerechosDeCredito = string.IsNullOrWhiteSpace(derechosDeCredito) ? null : derechosDeCredito.Trim();
        await unitOfWork.SaveChangesAsync();
    }
}