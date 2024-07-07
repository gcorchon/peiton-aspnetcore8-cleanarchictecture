using System.IO.Compression;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.Vales;

[Injectable]
public class DownloadValeHandler(IValeRepository valeRepository)
{

    public async Task<byte[]> HandleAsync(int id)
    {
        var vale = await valeRepository.GetByIdAsync(id);

        if (vale == null) throw new EntityNotFoundException($"El vale con Id {id} no existe");

        if (vale.Archivos == null) throw new EntityNotFoundException($"El vale con Id {id} no tiene archivos asociados");

        var archivos = vale.Archivos.Deserialize<string[]>();

        if (archivos!.Length == 0) throw new EntityNotFoundException($"El vale con Id {id} no tiene archivos asociados");

        using (var memoryStream = new MemoryStream())
        {
            using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var archivo in archivos)
                {
                    var completePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\Vales", vale.SolicitanteId.ToString(), archivo);
                    zipArchive.CreateEntryFromFile(completePath, archivo);
                }
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream.ToArray();
        }
    }
}
