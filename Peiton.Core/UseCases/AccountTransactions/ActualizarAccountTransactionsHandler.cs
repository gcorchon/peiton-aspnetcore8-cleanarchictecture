using Peiton.Contracts.AccountTransactions;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AccountTransactions;

[Injectable]
public class ActualizarAccountTransactionsHandler(IAccountTransactionRepository accountTransactionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(ActualizarAccountTransactionsRequest request)
    {
        AccountTransaction[] accountTransactions = await accountTransactionRepository.ObtenerAccountTransactionsAsync(request.AccountTransactionIds);

        if (!accountTransactions.Any()) return;

        var testAccountTransaction = accountTransactions[0];

        //Comprobar si todos los movimientos pertenecen a la misma cuenta, si no es así alguien está intentando hacer algo raro
        var allTransactionsFromTheSameAccount = !accountTransactions.Any(act => act.AccountId != testAccountTransaction.AccountId);

        if (!allTransactionsFromTheSameAccount) throw new UnauthorizedAccessException("Intento de actualización de movimientos de diferentes cuentas");

        var tuteladoId = testAccountTransaction.Account.Credencial.TuteladoId;

        if (!await tuteladoRepository.CanModifyAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        foreach (var accountTransaction in accountTransactions)
        {
            accountTransaction.CategoriaId = request.CategoriaId;
        }

        await unitOfWork.SaveChangesAsync();
    }
}