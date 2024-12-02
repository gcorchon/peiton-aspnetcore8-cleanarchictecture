using Microsoft.AspNetCore.Http;

namespace Peiton.Core.Utils;

public static class IFormFileExtensions
{
    public static async Task<byte[]> ToByteArrayAsync(this IFormFile formFile)
    {
        using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}