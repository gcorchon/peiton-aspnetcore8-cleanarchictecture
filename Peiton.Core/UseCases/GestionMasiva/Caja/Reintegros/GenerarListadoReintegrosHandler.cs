using Peiton.Contracts.Caja;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using System.Text.Json;

namespace Peiton.Core.UseCases.GestionMasiva.CajaMasiva;

[Injectable]
public class GenerarListadoReintegrosHandler(ICajaRepository cajaRepository)
{
    public async Task HandleAsync(DateTime fechaDesde, DateTime fechaHasta)
    {
        var vm = await cajaRepository.ObtenerReintegrosParaDocumento(fechaDesde, fechaHasta);
        throw new NotImplementedException();
    }

}