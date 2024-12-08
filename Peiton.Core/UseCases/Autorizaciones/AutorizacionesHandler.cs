using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Autorizaciones;

[Injectable]
public class AutorizacionesHandler(ITuteladoRepository tuteladoRepository)
{
    public async Task<Autorizacion[]> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");        
        return [.. tutelado.Autorizaciones.OrderByDescending(a => a.FechaSolicitud)];
    }
}