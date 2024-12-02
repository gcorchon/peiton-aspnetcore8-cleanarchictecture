using Microsoft.AspNetCore.Http;
using Peiton.Contracts.InformesPersonalesPIA;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InformesPersonalesPIA;

[Injectable]
public class ValidarInformePersonalPIAHandler(IInformePersonalPIARepository infomePersonalPIARepository, ITuteladoRepository tuteladoRepository, IIdentityService identityService, IUnitOfWork unitOfWork, IHttpContextAccessor accessor)
{
    public async Task HandleAsync(ValidarInformePersonalPIARequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var informe = new InformePersonalPIA
        {
            Fecha = DateTime.Now,
            TuteladoId = request.TuteladoId,
            IP = accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "",
            UsuarioId = identityService.GetUserId(),
            Informe = await request.Archivo.ToByteArrayAsync()
        };

        infomePersonalPIARepository.Add(informe);
        await unitOfWork.SaveChangesAsync();
    }
}