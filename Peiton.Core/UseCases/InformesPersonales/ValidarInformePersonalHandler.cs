using Microsoft.AspNetCore.Http;
using Peiton.Contracts.InformesPersonales;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InformesPersonales;

[Injectable]
public class ValidarInformePersonalHandler(IInformePersonalRepository infomePersonalRepository, ITuteladoRepository tuteladoRepository, IIdentityService identityService, IUnitOfWork unitOfWork, IHttpContextAccessor accessor)
{
    public async Task HandleAsync(ValidarInformePersonalRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var informe = new InformePersonal
        {
            Fecha = DateTime.Now,
            TuteladoId = request.TuteladoId,
            IP = accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "",
            UsuarioId = identityService.GetUserId(),
            Informe = await request.Archivo.ToByteArrayAsync()
        };

        infomePersonalRepository.Add(informe);
        await unitOfWork.SaveChangesAsync();
    }
}