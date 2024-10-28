using Peiton.Contracts.EntidadFinanciera;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionIndividual;

[Injectable]
public class CuentasDeRobotHandler(IEntidadFinancieraRepository entidadFinancieraRepository)
{
    public async Task<EntidadFinancieraViewModel[]> HandleAsync(int tuteladoId)
    {
        return await entidadFinancieraRepository.ObtenerEntidadesConCuentasActivasAsync(tuteladoId);
    }

}
