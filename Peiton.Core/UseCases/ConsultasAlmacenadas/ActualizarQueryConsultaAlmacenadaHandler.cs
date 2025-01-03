﻿using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ConsultasAlmacenadas;

[Injectable]
public class ActualizarQueryConsultaAlmacenadaHandler(IUnitOfWork unitOfWork, IEntityService entityService)
{
    public async Task HandleAsync(int id, string query)
    {
        var consultaAlmacenada = await entityService.GetEntityAsync<ConsultaAlmacenada>(id);
        if (consultaAlmacenada == null) throw new NotFoundException();

        consultaAlmacenada.Query = query;

        await unitOfWork.SaveChangesAsync();
    }

}