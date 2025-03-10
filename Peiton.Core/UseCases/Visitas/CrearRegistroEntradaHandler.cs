﻿using AutoMapper;
using Peiton.Contracts.Visitas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.Visitas;

[Injectable]
public class CrearRegistroEntradaHandler(IRegistroEntradaRepository registroEntradaRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearRegistroEntradaRequest request)
    {
        foreach (var visitante in request.Visitantes)
        {
            RegistroEntrada registroEntrada = new()
            {
                Dni = visitante.Dni,
                Nombre = visitante.Nombre,
                Tutelado = visitante.Tutelado,
                Fecha = request.Fecha,
                HoraEntrada = request.HoraEntrada,
                HoraSalida = request.HoraSalida,
                MotivoEntradaId = request.MotivoEntradaId,
                Observaciones = request.Observaciones,
                Personas = request.Visitadas.ToXDocument()!.ToString()
            };

            registroEntradaRepository.Add(registroEntrada);
        }



        await unitOfWork.SaveChangesAsync();
    }
}
