using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InformesPersonalesPIA;

[Injectable]
public class InformesPersonalesPIAHandler(IInformePersonalPIARepository informePersonalPIARepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<InformePersonalPIA>> HandleAsync(int tuteladoId, Pagination pagination)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var items = await informePersonalPIARepository.ObtenerInformesPersonalesPIAAsync(pagination.Page, pagination.Total, tuteladoId);
        var total = await informePersonalPIARepository.ContarInformesPersonalesPIAAsync(tuteladoId);

        return new PaginatedData<InformePersonalPIA>()
        {
            Items = items,
            Total = total
        };
    }
}