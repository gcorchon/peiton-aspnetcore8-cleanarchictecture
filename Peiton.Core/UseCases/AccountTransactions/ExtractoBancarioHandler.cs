using AutoMapper;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using Peiton.Contracts.AccountTransactions;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AccountTransactions;

[Injectable]
public class ExtractoBancarioHandler(IMapper mapper, ITuteladoRepository tuteladoRepository, IAccountRepository accountRepository)
{
    public async Task<EntidadExtractoViewModel[]> HandleAsync(int tuteladoId, DateTime desde, DateTime hasta)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var accounts = await accountRepository.ObtenerCuentasConMovimientosAsync(tuteladoId, desde, hasta);

        return (from a in accounts
                let entidadFinciaciera = a.Credencial.EntidadFinanciera
                group a by new { entidadFinciaciera.Descripcion, entidadFinciaciera.CssClass } into g
                select new EntidadExtractoViewModel()
                {
                    Descripcion = g.Key.Descripcion,
                    CssClass = g.Key.CssClass,
                    Accounts = mapper.Map<IEnumerable<ListItem>>(g)
                }).ToArray();

    }
}