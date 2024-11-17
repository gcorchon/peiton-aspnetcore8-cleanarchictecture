using AutoMapper;
using Peiton.Contracts.Prestamos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Prestamos;

[Injectable]
public class ActualizarPrestamoManualHandler(IMapper mapper, IPrestamoRepository prestamoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, PrestamoViewModel request)
    {
        var prestamo = await prestamoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Préstamo no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(prestamo.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para modificar los datos del tutelado");
        mapper.Map(request, prestamo);
        await unitOfWork.SaveChangesAsync();
    }
}