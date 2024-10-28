using Peiton.Contracts.Instrucciones;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IInstruccionRepository : IRepository<Instruccion>
{
    Task<InstruccionListItem[]> ObtenerInstruccionesAsync();
}
