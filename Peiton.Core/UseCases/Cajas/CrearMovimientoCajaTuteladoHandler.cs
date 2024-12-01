using AutoMapper;
using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class CrearMovimientoCajaTuteladoHandler(IMapper mapper, ICajaRepository cajaRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearMovimientoCajaTuteladoRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var caja = mapper.Map(request, new Caja());
        cajaRepository.Add(caja);
        await unitOfWork.SaveChangesAsync();
    }
}