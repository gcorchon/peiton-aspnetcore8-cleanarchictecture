using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ITuteladoObjetivoRepository : IRepository<TuteladoObjetivo>
{
    Task<TuteladoObjetivo[]> ObtenerObjetivosAsync(int tuteladoId, int tipoObjetivoId);
}
