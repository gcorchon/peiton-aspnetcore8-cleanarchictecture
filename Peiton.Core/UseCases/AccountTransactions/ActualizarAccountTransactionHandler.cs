using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AccountTransactions;

[Injectable]
public class ActualizarAccountTransactionHandler(IAccountTransactionRepository accountTransactionRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, int? categoriaId)
    {
        var accountTransaction = await accountTransactionRepository.GetByIdAsync(id) ?? throw new NotFoundException("Movimiento no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(accountTransaction.Account.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        accountTransaction.CategoriaId = categoriaId;
        await unitOfWork.SaveChangesAsync();
    }
}