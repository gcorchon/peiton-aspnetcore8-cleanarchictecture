using Peiton.Contracts.AccountTransactions;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AccountTransactions;

[Injectable]
public class ExportExcelExtractoBancarioHandler(IAccountTransactionRepository accountTransactionRepository, ExtractoBancarioHandler extractoBancarioHandler)
{
    public async Task<byte[]> HandleAsync(int tuteladoId, DateTime desde, DateTime hasta)
    {
        var extractoBancario = await extractoBancarioHandler.HandleAsync(tuteladoId, desde, hasta);

        var excel = new ExcelBuilder();
        excel.Prepare([typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime), typeof(decimal), typeof(decimal), typeof(string)]);

        foreach (var entidad in extractoBancario)
        {
            excel.AddSheet(entidad.Descripcion);
            foreach (var account in entidad.Accounts)
            {
                excel.AddRow([account.Text]);
                var accountTransactions = await accountTransactionRepository.ObtenerAccountTransactionsAsync(account.Id, desde, hasta);
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
                excel.AddRow(new string[0]);
            }
        }

        return await excel.SaveAsync();
    }
}