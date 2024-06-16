using Peiton.Contracts.Bancos;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva.Bancos
{
    [Injectable]
    public class CredencialesBloqueadasHandler (ICredencialRepository credencialRepository)
    {
        public async Task<PaginatedData<Credencial>> HandleAsync(CredencialesBloqueadasFilter filter, Pagination pagination)
        {
            var credenciales = await credencialRepository.ObtenerCredencialesBloqueadasAsync(pagination.Page, pagination.Total, filter);
            var total = await credencialRepository.ContarCredencialesBloqueadasAsync(filter);

            return new PaginatedData<Credencial>()
            {
                Items = credenciales,
                Total = total
            };
        }
    }

   
    
}
