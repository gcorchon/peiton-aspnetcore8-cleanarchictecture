using AutoMapper;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class ActualizarProductoBancarioManualHandler(IMapper mapper, IProductoManualRepository productoBancarioRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ProductoBancarioViewModel request)
    {
        var productoBancario = await productoBancarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Préstamo no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(productoBancario.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        mapper.Map(request, productoBancario);
        await unitOfWork.SaveChangesAsync();
    }
}