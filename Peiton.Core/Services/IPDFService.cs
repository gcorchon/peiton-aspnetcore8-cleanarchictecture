using System.Dynamic;

namespace Peiton.Core;

public interface IPDFService
{
    Task<byte[]> RenderAsync(string html);
    Task<byte[]> RenderAsync<T>(string templatePath, T data);
}
