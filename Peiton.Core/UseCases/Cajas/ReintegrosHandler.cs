using Peiton.Contracts.Caja;
using Peiton.DependencyInjection;
using System.Text.Json;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class ReintegrosHandler
{
    public async Task<TuteladoReintegroSerializado[]> HandleAsync()
    {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\reintegros.json");
        if (File.Exists(fileName))
        {
            var json = await File.ReadAllTextAsync(fileName);
            var data = JsonSerializer.Deserialize<TuteladoReintegroSerializado[]>(json, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;
            return data;
        }

        return [];
    }

}