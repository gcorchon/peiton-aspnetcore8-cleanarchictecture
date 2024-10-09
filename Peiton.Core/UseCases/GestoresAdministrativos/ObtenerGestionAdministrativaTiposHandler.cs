using MassTransit.Internals;
using Peiton.Contracts.Common;
using Peiton.Contracts.GestoresAdministrativos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InmuebleAutorizaciones;

[Injectable]
public class ObtenerGestionAdministrativaTiposHandler(IGestionAdministrativaTipoRepository gestionAdministrativaTipoRepository)
{
    public IAsyncEnumerable<GestionAdministrativaTipo> HandleAsync()
    {
        return gestionAdministrativaTipoRepository.GetAllAsync();
    }

}
