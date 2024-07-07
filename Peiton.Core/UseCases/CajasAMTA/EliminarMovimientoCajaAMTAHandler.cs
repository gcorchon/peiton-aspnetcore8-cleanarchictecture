using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.CajasAMTA;

[Injectable]
public class EliminarMovimientoCajaAMTAHandler(ICajaAMTARepository cajaAMTARepository, ICajaRepository cajaRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id)
    {
        var cajaAMTA = await cajaAMTARepository.GetByIdAsync(id);

        if (cajaAMTA == null) throw new EntityNotFoundException();

        if (cajaAMTA.Caja != null)
        {
            cajaRepository.Remove(cajaAMTA.Caja);
        }

        cajaAMTARepository.Remove(cajaAMTA);

        await unityOfWork.SaveChangesAsync();
    }

}
