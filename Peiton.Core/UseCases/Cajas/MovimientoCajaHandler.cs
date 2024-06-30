using AutoMapper;
using Peiton.Contracts.Caja;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class MovimientoCajaHandler(IMapper mapper, ICajaRepository cajaRepository)
{
    public async Task<CajaViewModel> HandleAsync(int id)
    {
        var movimiento = await cajaRepository.GetByIdAsync(id);
        if (movimiento == null) throw new NotFoundException();
        var saldoCaja = await cajaRepository.ObtenerSaldoCajaAsync(movimiento.TuteladoId);
        var vm = mapper.Map(movimiento, new CajaViewModel());
        vm.SaldoCaja = saldoCaja;
        return vm;
    }

}
