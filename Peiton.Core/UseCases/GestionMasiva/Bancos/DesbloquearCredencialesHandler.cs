using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva.Bancos
{
    [Injectable]
    public class DesbloquearCredencialesHandler(ICredencialRepository credencialRepository)
    {
        public async Task HandleAsync()
        {
            await credencialRepository.DesbloquearCredenciales();
        }
    }
}
