using AutoMapper;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class CrearProductoBancarioHandler(IMapper mapper, ITuteladoRepository tuteladoRepository, IProductoManualRepository productoManualRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearProductoBancarioRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        var productoBancario = mapper.Map(request, new ProductoManual());
        productoManualRepository.Add(productoBancario);
        await unitOfWork.SaveChangesAsync();
    }
}