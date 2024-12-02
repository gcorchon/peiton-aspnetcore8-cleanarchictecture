using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InformesPersonales;

[Injectable]
public class InformePersonalHandler(IInformePersonalRepository informePersonalRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<ArchivoViewModel> HandleAsync(int id)
    {
        var informe = await informePersonalRepository.GetByIdAsync(id) ?? throw new NotFoundException("Informe personal no encontrado");
        if (!await tuteladoRepository.CanViewAsync(informe.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        return new ArchivoViewModel()
        {
            Data = informe.Informe,
            MimeType = "application/pdf",
            FileName = "informe-personal.pdf"
        };
    }
}