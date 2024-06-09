using Peiton.Core.Entities;

using Peiton.Contracts.Capitulo;

namespace Peiton.Core.Repositories
{
    public interface ICapituloRepository : IRepository<Capitulo>
	{
        IAsyncEnumerable<CapituloViewModel> ObtenerCapitulosAsync(CapituloFilter filter);
    }
}