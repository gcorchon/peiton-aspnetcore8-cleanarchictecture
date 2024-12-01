using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Archivos;
using Peiton.Core.Entities;
using Peiton.Core.Utils;
using AutoMapper;

namespace Peiton.Core.UseCases.Archivos;

[Injectable]
public class CrearArchivoHandler(IMapper mapper, IArchivoRepository archivoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearArchivoRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var directory = "App_Data/Archivos/" + DateTime.Now.ToString("yyyy/MM/dd");

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var fileName = $"{request.TuteladoId}_{DateTime.Now.Ticks}_{request.Archivo.FileName}";
        var filePath = Path.Combine(directory, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.Archivo.CopyToAsync(stream);
        }

        var archivo = mapper.Map(request, new Archivo()
        {
            ContentType = MimeTypeHelper.GetMimeType(filePath),
            OriginalFileName = request.Archivo.FileName,
            FileName = fileName
        });

        archivoRepository.Add(archivo);

        await unitOfWork.SaveChangesAsync();
    }
}
