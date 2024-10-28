using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionesAdministrativas;

[Injectable]
public class ObtenerGestionAdministrativaTiposHandler(IGestionAdministrativaTipoRepository gestionAdministrativaTipoRepository)
{
    public Task<GestionAdministrativaTipo[]> HandleAsync()
    {
        return gestionAdministrativaTipoRepository.GetAllAsync();
    }

}
