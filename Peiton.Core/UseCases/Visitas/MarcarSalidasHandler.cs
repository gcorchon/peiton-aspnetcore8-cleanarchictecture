using Peiton.Contracts.Visitas;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Visitas;

[Injectable]
public class MarcarSalidasHandler(IRegistroEntradaRepository registroEntradaRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(MarcarSalidasRequest request)
    {
        foreach (int id in request.Ids)
        {
            var registroEntrada = await registroEntradaRepository.GetByIdAsync(id);
            if (registroEntrada == null || registroEntrada.HoraSalida != null) throw new ArgumentException("Registro de entrada no válido");

            registroEntrada.HoraSalida = request.Hora;
        }

        await unityOfWork.SaveChangesAsync();


    }

}
