using Peiton.Contracts.AccountTransactions;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AccountTransactions;

[Injectable]
public class AccountTransactionsHandler(IAccountTransactionRepository accountTransactionRepository, IAccountRepository accountRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<AccountTransaction>> HandleAsync(int accountId, AccountTransactionsFilter filter, Pagination pagination)
    {
        var account = await accountRepository.GetByIdAsync(accountId) ?? throw new NotFoundException("Cuenta no encontrada");
        if (!await tuteladoRepository.CanViewAsync(accountId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var items = await accountTransactionRepository.ObtenerAccountTransactionsAsync(pagination.Page, pagination.Total, accountId, filter);
        var total = await accountTransactionRepository.ContarAccountTransactionsAsync(accountId, filter);

        return new PaginatedData<AccountTransaction>()
        {
            Items = items,
            Total = total
        };
    }
}