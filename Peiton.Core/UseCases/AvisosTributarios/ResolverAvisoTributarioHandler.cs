using Peiton.Contracts.AvisosTributarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AvisosTributarios;

[Injectable]
public class ResolverAvisoTributarioHandler(IAvisoTributarioRepository avisoTributarioRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id, ActualizarAvisoTributarioRequest request)
    {
        var avisoTributario = await avisoTributarioRepository.GetByIdAsync(id);
        if (avisoTributario == null)
        {
            throw new EntityNotFoundException();
        }

        if (avisoTributario.Resuelto)
        {
            throw new ArgumentException("No se puede resolver un aviso ya resuelto");
        }

        avisoTributario.ComentariosDepartamentoTributario = request.ComentariosDepartamentoTributario;
        avisoTributario.EnTramite = request.EnTramite;
        avisoTributario.Resuelto = true;
        avisoTributario.EnTramite = false;
        avisoTributario.FechaResolucion = DateTime.Now;

        await unityOfWork.SaveChangesAsync();
    }

}
