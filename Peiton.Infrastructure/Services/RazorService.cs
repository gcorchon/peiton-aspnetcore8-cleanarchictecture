using Microsoft.Extensions.DependencyInjection;
using Peiton.Core;
using Peiton.Core.Services;
using Peiton.DependencyInjection;
using RazorLight;

namespace Peiton.Infrastructure;

[Injectable(typeof(IRazorService), ServiceLifetime.Singleton)]
public class RazorService : IRazorService
{
    private readonly RazorLightEngine _razorEngine;
    private readonly ICryptographyService cryptographyService;
    public RazorService(ICryptographyService cryptographyService)
    {
        _razorEngine = new RazorLightEngineBuilder()
            .UseFileSystemProject(Directory.GetCurrentDirectory())
            .DisableEncoding()
            .UseMemoryCachingProvider()
            .Build();

        this.cryptographyService = cryptographyService;
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

    public async Task<string> RenderTemplateAsync<T>(string templateContent, T model)
    {
        var key = cryptographyService.GetMd5Hash(templateContent);
        var cacheResult = _razorEngine.Handler.Cache.RetrieveTemplate(key);

        if (cacheResult.Success)
        {
            var templatePage = cacheResult.Template.TemplatePageFactory();
            return await _razorEngine.RenderTemplateAsync(templatePage, model);
        }

        return await _razorEngine.CompileRenderStringAsync(key, templateContent, model);
    }
}