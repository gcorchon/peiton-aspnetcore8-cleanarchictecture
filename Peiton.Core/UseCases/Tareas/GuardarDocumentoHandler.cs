using Microsoft.AspNetCore.Http;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tareas;

[Injectable]
public class GuardarDocumentoHandler
{
    public async Task<string> HandleAsync(IFormFile file)
    {
        var filename = DateTime.Now.Ticks.ToString() + "_" + file.FileName;
        var ymd = DateTime.Now.ToString("yyyy/MM/dd");
        var directory = Path.Combine("App_Data/Tareas/", ymd);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var filePath = Path.Combine(directory, filename);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return ymd + "/" + filename;
    }
}