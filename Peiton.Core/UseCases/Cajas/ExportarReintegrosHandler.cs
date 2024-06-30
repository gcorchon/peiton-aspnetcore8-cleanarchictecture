using Peiton.Contracts.Caja;
using Peiton.Contracts.Excel;
using Peiton.Core.Services;
using Peiton.DependencyInjection;
using System.Text.Json;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class ExportarReintegrosHandler(IExcelService excelService)
{
    public async Task<byte[]> HandleAsync()
    {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\reintegros.json");
        if (!File.Exists(fileName)) throw new ArgumentException("No se han guardado reintegros");

        var json = await File.ReadAllTextAsync(fileName);
        var data = JsonSerializer.Deserialize<TuteladoReintegroSerializado[]>(json, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;

        var vm = from item in data
                 let cuenta = item.Tutelado.Cuentas.FirstOrDefault(c => c.Id == item.Cuenta)
                 select new ReintegroExcelListItem()
                 {
                     Importe = item.Importe,
                     NombreCompleto = item.Tutelado.NombreCompleto,
                     Numero = cuenta?.Iban,
                     Saldo = cuenta?.Saldo
                 };

        var columns = new ColumnaExcel[]
        {
            new ("Tutelado", "NombreCompleto"),
            new ("Cuenta de cargo", "Numero"),
            new ("Saldo", "Saldo"),
            new ("Importe", "Importe")
        };

        return excelService.Export(vm, columns);
    }
}

