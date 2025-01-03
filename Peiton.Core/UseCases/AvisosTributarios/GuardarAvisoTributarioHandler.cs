﻿using AutoMapper;
using Peiton.Contracts.AvisosTributarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AvisosTributarios;

[Injectable]
public class GuardarAvisoTributarioHandler(IMapper mapper, IAvisoTributarioRepository avisoTributarioRepository, IUnitOfWork unitOfWork, IIdentityService identityService)
{
    public async Task HandleAsync(GuardarAvisoTributarioRequest request)
    {
        var avisoTributario = new AvisoTributario()
        {
            UsuarioId = identityService.GetUserId(),
            TuteladoId = request.TuteladoId,
            EnTramite = false,
            Resuelto = false,
            Fecha = DateTime.Now
        };

        mapper.Map(request, avisoTributario);

        avisoTributarioRepository.Add(avisoTributario);
        await unitOfWork.SaveChangesAsync();
    }

}
