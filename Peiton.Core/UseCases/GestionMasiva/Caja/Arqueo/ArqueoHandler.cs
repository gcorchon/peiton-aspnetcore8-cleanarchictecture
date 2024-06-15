using Peiton.Contracts.Caja;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class ArqueoHandler(IArqueoRepository arqueoRepository, ICajaRepository cajaRepository, ICajaAMTARepository cajaAMTARepository)
{
    public async Task<ArqueoModel> HandleAsync(DateTime fecha)
    {
        var arqueo = await arqueoRepository.GetAsync(arqueo => arqueo.Fecha == fecha);

        var vm = arqueo?.Datos.Deserialize<ArqueoModel>() ?? new ArqueoModel();

        if (fecha.Date == DateTime.Now.Date)
        {
            vm.SaldoCajaAMTA = await cajaAMTARepository.ObtenerSaldoCajaAMTAAsync();
            vm.SaldoCajaTutelados = await cajaRepository.ObtenerSaldoCajaAsync();
        }

        return vm!;
    }

}
