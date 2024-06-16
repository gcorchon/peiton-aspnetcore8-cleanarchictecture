using Peiton.Contracts.Bancos;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva.Bancos
{
    [Injectable]
    public class DesbloquearCredencialHandler(ICredencialRepository credencialRepository, IUnityOfWork unityOfWork)
    {
        public async Task HandleAsync(int id)
        {
            var credencial = await credencialRepository.GetByIdAsync(id);

            if(credencial == null) throw new NotFoundException();

            credencial.DatosCorrectos = true;
            credencial.Reintentos = 0;
            credencial.ProximaEjecucion = DateTime.Now;

            await unityOfWork.SaveChangesAsync();
        }
    }

   
    
}
