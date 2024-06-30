using Peiton.Contracts.Capitulo;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Partidas;

[Injectable]
public class CapitulosYPartidasHandler(ICapituloRepository capituloRepository)
{
    public IAsyncEnumerable<CapituloViewModel> HandleAsync(CapituloFilter filter) => capituloRepository.ObtenerCapitulosAsync(filter);

}
