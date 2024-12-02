using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InformesPersonales;

[Injectable]
public class InformesPersonalesHandler(IInformePersonalRepository informePersonalRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<InformePersonal>> HandleAsync(int tuteladoId, Pagination pagination)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var items = await informePersonalRepository.ObtenerInformesPersonalesAsync(pagination.Page, pagination.Total, tuteladoId);
        var total = await informePersonalRepository.ContarInformesPersonalesAsync(tuteladoId);

        return new PaginatedData<InformePersonal>()
        {
            Items = items,
            Total = total
        };
    }
}