using AutoMapper;
using Peiton.Contracts.Caja;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class IncidenciaHandler(IMapper mapper, ICajaRepository cajaRepository, ICajaIncidenciaRepository cajaIncidenciaRepository)
{
    public async Task<IncidenciaViewModel> HandleAsync(int id)
    {
        var incidencia = await cajaIncidenciaRepository.GetByIdAsync(id);
        if (incidencia == null) throw new EntityNotFoundException();
        var saldoCaja = await cajaRepository.ObtenerSaldoCajaAsync(incidencia.TuteladoId);
        var vm = mapper.Map(incidencia, new IncidenciaViewModel());
        vm.SaldoCaja = saldoCaja;
        return vm;
    }

}
