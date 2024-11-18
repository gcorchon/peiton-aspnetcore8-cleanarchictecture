using AutoMapper;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class ActualizarProductoBancarioManualHandler(IMapper mapper, IProductoManualRepository productoBancarioRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ProductoBancarioViewModel request)
    {
        var productoBancario = await productoBancarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Préstamo no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(productoBancario.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para modificar los datos del tutelado");
        mapper.Map(request, productoBancario);
        await unitOfWork.SaveChangesAsync();
    }
}