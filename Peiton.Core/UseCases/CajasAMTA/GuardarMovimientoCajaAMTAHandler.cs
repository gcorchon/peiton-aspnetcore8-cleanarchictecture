﻿using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Core.Entities;
using Peiton.Contracts.Caja;

namespace Peiton.Core.UseCases.CajasAMTA;

[Injectable]
public class GuardarMovimientoCajaAMTAHandler(ICajaAMTARepository cajaAMTARepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(GuardarCajaAMTA data)
    {
        var importe = Math.Abs(data.Importe);
        if (data.Tipo == 1) importe *= -1;

        var cajaAMTA = new CajaAMTA()
        {
            Fecha = DateTime.Now,
            Tipo = data.Tipo,
            Concepto = data.Concepto,
            Persona = data.Persona,
            TuteladoId = data.TuteladoId,
            Importe = importe
        };

        cajaAMTARepository.Add(cajaAMTA);
        await unitOfWork.SaveChangesAsync();
    }

}
