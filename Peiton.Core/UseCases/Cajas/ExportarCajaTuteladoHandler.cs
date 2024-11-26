using Peiton.Contracts.Caja;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class ExportarCajaTuteladoHandler(IVwCajaRepository vwCajaRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<byte[]> HandleAsync(int tuteladoId, CajaTuteladoFilter filter)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var caja = await vwCajaRepository.ObtenerCajaTuteladoAsync(1, Int32.MaxValue, tuteladoId, filter);

        var excel = new ExcelBuilder();
        excel.AddSheet("Caja");
        excel.Prepare([typeof(DateTime), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal)]);
        excel.AddRow(["Fecha Autorizacion", "Fecha Pago", "Método", "Concepto", "Tipo", "Anticipo", "Importe", "Saldo"]);
        excel.AddRows(caja.Select(c => new object?[]{
            c.FechaAutorizacion.Date,
            c.FechaPago?.Date,
            c.MetodoPago?.Descripcion,
            c.Concepto,
            c.TipoPago?.Descripcion,
            c.Anticipo ? "Si" : "No",
            c.Importe,
            c.Balance
        }));

        return await excel.SaveAsync();
    }
}