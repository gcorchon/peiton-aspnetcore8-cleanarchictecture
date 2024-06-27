using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class ResolverInmuebleAvisoHandler(IInmuebleAvisoRepository inmuebleAvisoRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id)
    {
        var inmuebleAviso = await inmuebleAvisoRepository.GetByIdAsync(id);
        if (inmuebleAviso == null) throw new NotFoundException();

        if (inmuebleAviso.Resuelto) throw new ArgumentException("El aviso ya se encuentra resuelto");

        inmuebleAviso.Resuelto = true;
        inmuebleAviso.EnTramite = false;

        await unityOfWork.SaveChangesAsync();
    }

}
