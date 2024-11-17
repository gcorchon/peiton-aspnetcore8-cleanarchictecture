using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.DatosEconomicos;

[Injectable]
public class ActualizarOtrosBienesHandler(IDatosEconomicosRepository datosEconomicosRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, string? bienes)
    {
        var datosEconomicos = await datosEconomicosRepository.GetAsync(d => d.TuteladoId == id);
        if (datosEconomicos == null) throw new NotFoundException("Datos económicos no encontrados");
        datosEconomicos.OtrosBienes = string.IsNullOrWhiteSpace(bienes) ? null : bienes.Trim();
        await unitOfWork.SaveChangesAsync();
    }
}