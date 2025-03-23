using AutoMapper;
using Peiton.Contracts.Account;
using Peiton.Contracts.AccountTransactions;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AccountTransactions;

[Injectable]
public class ExportWordExtractoBancarioHandler(IMapper mapper, ITuteladoRepository tuteladoRepository, IAccountTransactionRepository accountTransactionRepository, ExtractoBancarioHandler extractoBancarioHandler, IWordService wordService)
{
    public async Task<byte[]> HandleAsync(int tuteladoId, DateTime desde, DateTime hasta)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        var extractoBancario = await extractoBancarioHandler.HandleAsync(tuteladoId, desde, hasta);

        var datosExtracto = new ExtractoWordViewModel();
        datosExtracto.Tutelado = tutelado.NombreCompleto!;
        datosExtracto.Intervalo = $"De {desde.ToReadableFormat()} a {hasta.ToReadableFormat()}";

        foreach (var entidad in extractoBancario)
        {
            foreach (var account in entidad.Accounts)
            {
                var accountTransactions = await accountTransactionRepository.ObtenerAccountTransactionsAsync(account.Id, desde, hasta);

                var objAccount = new AccountWithTransactions()
                {
                    Descripcion = $"{entidad.Descripcion} - {account.Text}",
                    Transactions = mapper.Map<IEnumerable<AccountTransactionListItem>>(accountTransactions)
                };

                datosExtracto.Accounts.Add(objAccount);
            }
        }

        return await wordService.RenderRazorAsync("App_Data\\extracto-bancario.docx", datosExtracto);
    }
}