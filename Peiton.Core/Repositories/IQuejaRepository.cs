using Peiton.Contracts.Quejas;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IQuejaRepository : IRepository<Queja>
{
    Task<int> ContarQuejasAsync(QuejasFilter filter);
    Task<List<Queja>> ObtenerQuejasAsync(int page, int total, QuejasFilter filter);
    Task<string> ObtenerSiguienteNumeroExpedienteAsync(int quejaTipoId);
}
