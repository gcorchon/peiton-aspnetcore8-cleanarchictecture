﻿using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InmuebleSolicitudesAlquilerVenta;

[Injectable]
public class CrearSolicitudAlquilerVentaHandler(IInmuebleRepository inmuebleRepository, IUnityOfWork unityOfWork, IIdentityService identityService)
{
    public async Task HandleAsync(int inmuebleId, CrearInmuebleAutorizacionRequest request)
    {
        var inmueble = await inmuebleRepository.GetByIdAsync(inmuebleId);
        if (inmueble == null) throw new EntityNotFoundException("Inmueble no encontrado");

        inmueble.InmueblesAutorizaciones.Add(new InmuebleAutorizacion()
        {
            UsuarioId = identityService.GetUserId(),
            InmuebleId = inmuebleId,
            InmuebleMotivoAutorizacionId = request.MotivoId,
            Descripcion = request.Descripcion,
            Autorizado = false,
            Presentado = false,
            Firme = false,
            Fecha = DateTime.Now,
            Archivo = false
        });

        await unityOfWork.SaveChangesAsync();

    }

}
