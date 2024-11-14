using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.DatosEconomicos;

[Injectable]
public class ActualizarOtrosDatosDeInteresHandler(IDatosEconomicosRepository datosEconomicosRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, string? otrosDatos)
    {
        var datosEconomicos = await datosEconomicosRepository.GetAsync(d => d.TuteladoId == id);
        if (datosEconomicos == null) throw new EntityNotFoundException("Datos económicos no encontrados");
        datosEconomicos.OtrosDatos = string.IsNullOrWhiteSpace(otrosDatos) ? null : otrosDatos.Trim();
        await unitOfWork.SaveChangesAsync();
    }
}