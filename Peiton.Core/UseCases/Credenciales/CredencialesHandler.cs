using Peiton.Contracts.Credenciales;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales;

[Injectable]
public class CredencialesHandler(ICredencialRepository credencialRepository)
{
    public async Task<Credencial[]> HandleAsync(int tuteladoId)
    {
        return await credencialRepository.ObtenerCredencialesAsync(tuteladoId);
    }
}