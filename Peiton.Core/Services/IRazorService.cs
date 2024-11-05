using System.Dynamic;

namespace Peiton.Core;

public interface IRazorService
{
    Task<string> RenderAsync<T>(string templatePath, T data);
    Task<string> RenderTemplateAsync<T>(string template, T data);
}
