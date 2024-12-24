
namespace Peiton.Core;

public interface IWordService
{
    Task<byte[]> RenderRazorAsync<T>(string docxPath, T data);
    Task<byte[]> RenderAsync(string docxPath, Dictionary<string, string> data);
    Task<byte[]> RenderAsync<T>(string docxPath, Dictionary<string, string> data, T model);


    /// <summary>
    /// Crea un documento de Word a partir de una View de Razor. El documento base que usa está en App_Data\Plantillas\template_vacia.docx
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="razorViewPath">Ruta a la vista</param>
    /// <param name="data">Modelo de datos</param>
    /// <returns></returns>
    Task<byte[]> RenderRazorViewAsync<T>(string razorViewPath, T data);


    Task<byte[]> ConcatAsync(byte[] document1, byte[] document2);
}
