using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Accounts;

[Injectable]
public class DarDeBajaHandler(IAccountRepository accountRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var account = await accountRepository.GetByIdAsync(id) ?? throw new NotFoundException("Cuenta no encontrada");
        if (!await tuteladoRepository.CanModifyAsync(account.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        if (account.Baja) return;
        account.Baja = true;
        account.FechaBaja = DateTime.Now;
        await unitOfWork.SaveChangesAsync();
    }
}