using Peiton.Contracts.Caja;
using Peiton.DependencyInjection;
using System.Text.Json;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class GuardarReintegrosHandler
{
    public async Task HandleAsync(TuteladoReintegroSerializado[] data)
    {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\reintegros.json");
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;
        await File.WriteAllTextAsync(fileName, json);
    }
}