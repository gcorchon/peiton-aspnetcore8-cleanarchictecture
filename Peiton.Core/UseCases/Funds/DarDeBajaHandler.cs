using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Funds;

[Injectable]
public class DarDeBajaHandler(IFundRepository fundRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var fund = await fundRepository.GetByIdAsync(id) ?? throw new NotFoundException("Fondo no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(fund.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        if (fund.Baja) return;
        fund.Baja = true;
        fund.FechaBaja = DateTime.Now;
        await unitOfWork.SaveChangesAsync();
    }
}