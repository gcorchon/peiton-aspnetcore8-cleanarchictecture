using Microsoft.AspNetCore.Http;
using Peiton.Contracts.Files;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Vales;

[Injectable]
public class UploadValeHandler(IIdentityService identityService)
{

    public async Task<UploadValeFileResponse> HandleAsync(IFormFile? file)
    {
        if (file == null || file.Length == 0) throw new ArgumentException("Archivo no válido");

        var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + file.FileName;
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\Vales", identityService.GetUserId()!.Value.ToString());

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        var completPath = Path.Combine(filePath, fileName);

        using (var stream = File.Create(completPath))
        {
            await file.CopyToAsync(stream);
        }

        return new UploadValeFileResponse()
        {
            OriginalFileName = file.Name,
            FileName = fileName
        };

    }
}
