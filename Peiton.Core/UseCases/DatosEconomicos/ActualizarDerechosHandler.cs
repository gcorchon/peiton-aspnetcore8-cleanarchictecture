using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.DatosEconomicos;

[Injectable]
public class ActualizarDerechosHandler(IDatosEconomicosRepository datosEconomicosRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, string? derechos)
    {
        var datosEconomicos = await datosEconomicosRepository.GetAsync(d => d.TuteladoId == id);
        if (datosEconomicos == null) throw new EntityNotFoundException("Datos económicos no encontrados");
        datosEconomicos.Derechos = string.IsNullOrWhiteSpace(derechos) ? null : derechos.Trim();
        await unitOfWork.SaveChangesAsync();
    }
}