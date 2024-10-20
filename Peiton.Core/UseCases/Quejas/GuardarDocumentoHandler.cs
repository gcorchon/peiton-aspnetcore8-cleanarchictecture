using Microsoft.AspNetCore.Http;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Quejas;

[Injectable]
public class GuardarDocumentoHandler
{
    public async Task<string> HandleAsync(IFormFile file)
    {
        var filename = DateTime.Now.Ticks.ToString() + "_" + file.FileName;
        var directory = Path.Combine("App_Data/Quejas/", DateTime.Now.ToString("yyyy/MM/dd"));

        if(!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var filePath = Path.Combine(directory, filename );

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return filename;
    }
}
