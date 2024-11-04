using Microsoft.Extensions.DependencyInjection;
using Peiton.Core;
using Peiton.DependencyInjection;
using RazorLight;

namespace Peiton.Infrastructure;

[Injectable(typeof(IRazorService), ServiceLifetime.Singleton)]
public class RazorService : IRazorService
{
    private readonly RazorLightEngine _razorEngine;

    public RazorService()
    {
        _razorEngine = new RazorLightEngineBuilder()
            .UseFileSystemProject(Directory.GetCurrentDirectory())
            .UseMemoryCachingProvider()
            .Build();
    }

    public async Task<string> RenderAsync<T>(string templatePath, T model)
    {
        //Nota: Para que esto funcione he tenido que tocar el Peiton.Api.csproj y añadir <PreserveCompilationContext>true</PreserveCompilationContext> dentro del PropertyGroup

        if (!File.Exists(templatePath))
            throw new FileNotFoundException("La plantilla no existe en la ruta especificada.", templatePath);

        var templateKey = Path.GetFileName(templatePath);
        var cacheResult = _razorEngine.Handler.Cache.RetrieveTemplate(templateKey);

        if (cacheResult.Success)
        {
            var templatePage = cacheResult.Template.TemplatePageFactory();
            return await _razorEngine.RenderTemplateAsync(templatePage, model);
        }

        var templateContent = await File.ReadAllTextAsync(templatePath);
        var result = await _razorEngine.CompileRenderStringAsync(templateKey, templateContent, model);

        return result;
    }
}