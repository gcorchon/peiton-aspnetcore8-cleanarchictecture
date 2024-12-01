using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Archivos;
using Peiton.Core.Utils;
using Peiton.Core.Exceptions;
using AutoMapper;

namespace Peiton.Core.UseCases.Archivos;

[Injectable]
public class ActualizarArchivoHandler(IMapper mapper, IArchivoRepository archivoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarArchivoRequest request)
    {
        var archivo = await archivoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Archivo no encontrado");

        if (!await tuteladoRepository.CanModifyAsync(archivo.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        mapper.Map(request, archivo);

        await unitOfWork.SaveChangesAsync();
    }
}
