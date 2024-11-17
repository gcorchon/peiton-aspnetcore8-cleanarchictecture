using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.DatosEconomicos;

[Injectable]
public class ActualizarExentoIRPFHandler(IDatosEconomicosRepository datosEconomicosRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, bool exentoIRPF)
    {
        var datosEconomicos = await datosEconomicosRepository.GetAsync(d => d.TuteladoId == id);
        if (datosEconomicos == null) throw new NotFoundException("Datos económicos no encontrados");
        datosEconomicos.ExentoIRPF = exentoIRPF;
        await unitOfWork.SaveChangesAsync();
    }
}