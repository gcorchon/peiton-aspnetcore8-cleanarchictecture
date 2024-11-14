using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.DatosEconomicos;

[Injectable]
public class ActualizarOtrasDeudasHandler(IDatosEconomicosRepository datosEconomicosRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, string? deudas)
    {
        var datosEconomicos = await datosEconomicosRepository.GetAsync(d => d.TuteladoId == id);
        if (datosEconomicos == null) throw new EntityNotFoundException("Datos económicos no encontrados");
        datosEconomicos.OtrasDeudas = string.IsNullOrWhiteSpace(deudas) ? null : deudas.Trim();
        await unitOfWork.SaveChangesAsync();
    }
}