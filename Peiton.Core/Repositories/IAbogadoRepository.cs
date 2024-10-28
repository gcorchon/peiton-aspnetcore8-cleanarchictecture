using Peiton.Core.Entities;


namespace Peiton.Core.Repositories;
public interface IAbogadoRepository : IRepository<Abogado>
{
    Task<Abogado[]> AbogadosParaSenalamientoAsync(string nombre);
}
