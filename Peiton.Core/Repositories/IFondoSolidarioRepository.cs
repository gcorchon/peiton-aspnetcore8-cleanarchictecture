using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IFondoSolidarioRepository : IRepository<FondoSolidario>
{
    Task<int> ContarFondosSolidariosAsync(int tuteladoId);
    Task<FondoSolidario[]> ObtenerFondosSolidariosAsync(int page, int total, int tuteladoId);

    Task<int> ContarFondosSolidariosAsync(FondosSolidariosFilter filter);
    Task<FondoSolidario[]> ObtenerFondosSolidariosAsync(int page, int total, FondosSolidariosFilter filter);
}
