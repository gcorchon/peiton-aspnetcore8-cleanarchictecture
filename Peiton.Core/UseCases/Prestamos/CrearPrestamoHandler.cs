using AutoMapper;
using Peiton.Contracts.Prestamos;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Prestamos;

[Injectable]
public class CrearPrestamoHandler(IMapper mapper, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearPrestamoRequest request)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(request.TuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        var prestamo = mapper.Map(request, new Prestamo());
        tutelado.Prestamos.Add(prestamo);
        await unitOfWork.SaveChangesAsync();
    }
}