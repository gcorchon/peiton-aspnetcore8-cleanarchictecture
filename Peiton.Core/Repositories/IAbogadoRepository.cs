using Peiton.Core.Entities;


namespace Peiton.Core.Repositories;
public interface IAbogadoRepository : IRepository<Abogado>
{
    Task<List<Abogado>> AbogadosParaSenalamientoAsync(string nombre);
}
