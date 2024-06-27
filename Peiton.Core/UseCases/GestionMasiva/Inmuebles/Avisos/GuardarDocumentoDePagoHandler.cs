using AutoMapper;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class GuardarDocumentoDePagoHandler(IInmuebleAvisoRepository inmuebleAvisoRepository, IMapper mapper, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id, GuardarInmuebleAvisoRequest request)
    {
        

        //await unityOfWork.SaveChangesAsync();
    }

}
