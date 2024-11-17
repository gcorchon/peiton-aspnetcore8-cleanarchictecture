using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class DescargarArchivosFondoSolidarioHandler(IFondoSolidarioRepository fondoSolidarioRepository, DescargarArchivoFondoSolidarioHandler archivoFondoSolidarioHandler, IZipService zipService)
{
    public async Task<ArchivoFondoSolidario> HandleAsync(int id)
    {
        var fondoSolidario = await fondoSolidarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Fondo solidario no encontrado");

        var archivos = new List<ArchivoFondoSolidario>();
        foreach (var tipo in new int[] { 1, 2 })
        {
            try
            {
                var archivo = await archivoFondoSolidarioHandler.HandleAsync(id, tipo);
                archivos.Add(archivo);
            }
            catch (NotFoundException) { }
        }

        if (archivos.Count == 0) throw new NotFoundException("No hay archivos");

        if (archivos.Count == 1) return archivos[0];

        foreach (var archivo in archivos)
        {
            await zipService.AddFromDataAsync(archivo.FileName, archivo.Data);
        }

        var tutelado = fondoSolidario.Tutelado;

        return new ArchivoFondoSolidario()
        {
            Data = zipService.Save(),
            FileName = "Fondo Solidario - " + tutelado.NombreCompleto + " " + tutelado.NumeroExpediente + ".zip",
            MimeType = "application/zip"
        };
    }
}