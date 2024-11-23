using Peiton.Contracts.AccountTransactions;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AccountTransactions;

[Injectable]
public class ExportAccountTransactionsHandler(IAccountTransactionRepository accountTransactionRepository)
{
    public async Task<byte[]> HandleAsync(int accountId, AccountTransactionsFilter filter)
    {
        var accountTransactions = await accountTransactionRepository.ObtenerAccountTransactionsAsync(1, Int32.MaxValue, accountId, filter);

        using var excel = new ExcelBuilder();
        excel.AddSheet("Movimientos");
        excel.Prepare([typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime), typeof(decimal), typeof(decimal), typeof(string)]);
        excel.AddRow(["Descripción", "Referencia", "Beneficiario", "Pagador", "Fecha de operación", "Fecha de valor", "Importe", "Balance", "Categoría"]);
        excel.AddRows(accountTransactions.Select(accountTransaction =>
            new object?[]{
                accountTransaction.Description,
                accountTransaction.Reference,
                accountTransaction.Payee,
                accountTransaction.Payer,
                accountTransaction.OperationDate,
                accountTransaction.ValueDate,
                accountTransaction.Quantity,
                accountTransaction.Balance,
                accountTransaction.Categoria?.Descripcion
            }
        ));

        return await excel.SaveAsync();

    }
}