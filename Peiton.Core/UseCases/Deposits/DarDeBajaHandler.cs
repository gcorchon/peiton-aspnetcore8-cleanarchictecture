using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Deposits;

[Injectable]
public class DarDeBajaHandler(IDepositRepository depositRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var deposit = await depositRepository.GetByIdAsync(id) ?? throw new NotFoundException("Cuenta no encontrada");
        if (!await tuteladoRepository.CanModifyAsync(deposit.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        if (deposit.Baja) return;
        deposit.Baja = true;
        deposit.FechaBaja = DateTime.Now;
        await unitOfWork.SaveChangesAsync();
    }
}