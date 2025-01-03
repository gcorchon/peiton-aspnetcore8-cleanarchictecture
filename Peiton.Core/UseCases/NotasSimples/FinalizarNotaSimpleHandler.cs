﻿using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.NotasSimples;

[Injectable]
public class FinalizarNotaSimpleHandler(INotaSimpleRepository notaSimpleRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var notaSimple = await notaSimpleRepository.GetByIdAsync(id);
        if (notaSimple == null) throw new NotFoundException();
        notaSimple.Finalizado = true;
        await unitOfWork.SaveChangesAsync();
    }

}
