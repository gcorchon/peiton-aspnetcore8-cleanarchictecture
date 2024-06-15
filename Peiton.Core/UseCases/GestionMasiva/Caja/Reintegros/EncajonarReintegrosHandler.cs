using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using System.Text.Json;

namespace Peiton.Core.UseCases.GestionMasiva.CajaMasiva;

[Injectable]
public class EncajonarReintegrosHandler(ICajaRepository cajaRepository, IUnityOfWork unityOfWork, IIdentityService identityService)
{
    public async Task HandleAsync()
    {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\reintegros.json");
        if (File.Exists(fileName))
        {
            var json = await File.ReadAllTextAsync(fileName);
            var data = JsonSerializer.Deserialize<TuteladoReintegroSerializado[]>(json, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;
            var now = DateTime.Now;
            cajaRepository.AddRange(from element in data
                                    select new Caja()
                                    {
                                        TuteladoId = element.Tutelado.Id,
                                        Importe = element.Importe,
                                        UsuarioId = identityService.GetUserId()!.Value,
                                        Tipo = 2,
                                        FechaAutorizacion = now,
                                        FechaPago = now,
                                        Concepto = "Reintegro",
                                        Pendiente = false,
                                        Observaciones = null,
                                        Anticipo = false,
                                        Recepcion = 1
                                    }
            );

            await unityOfWork.SaveChangesAsync();
        }
    }
}