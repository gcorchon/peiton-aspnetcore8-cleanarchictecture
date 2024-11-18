using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IProductoManualRepository : IRepository<ProductoManual>
{
    Task<ProductoManual[]> ObtenerProductosManualesAsync(int tuteladoId);
}
