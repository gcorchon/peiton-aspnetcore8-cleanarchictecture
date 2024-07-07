using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
	{
		Task BorrarCategoriaAsync(int id);
    }
}