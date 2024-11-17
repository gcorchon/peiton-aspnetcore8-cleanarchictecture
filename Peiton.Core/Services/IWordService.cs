using System.Dynamic;

namespace Peiton.Core;

public interface IWordService
{
    Task<byte[]> RenderRazorAsync<T>(string templatePath, T data);

    Task<byte[]> RenderAsync(string docxPath, Dictionary<string, string> data);
}
