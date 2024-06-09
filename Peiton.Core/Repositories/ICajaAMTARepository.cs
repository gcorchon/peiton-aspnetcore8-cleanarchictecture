using Peiton.Core.Entities;
using Peiton.Contracts.MovimientosPendientesCaja;




namespace Peiton.Core.Repositories
{
    public interface ICajaAMTARepository : IRepository<CajaAMTA>
    {
        Task<int> ContarMovimientosPendientesCajaAsync(MovimientosPendientesCajaFilter filter);
        Task<List<CajaAMTA>> ObtenerMovimientosPendientesCajaAsync(int page, int total, MovimientosPendientesCajaFilter filter);
    }
}