using AutoMapper;
using Peiton.Contracts.Mensajes;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class ExportarMensajeHandler(IMapper mapper, IMensajeRepository mensajeRepository, IPDFService pdfService)
{
    public async Task<byte[]> HandleAsync(int id)
    {
        var mensaje = await mensajeRepository.GetByIdAsync(id); //Ojo: método sobreescrito en el repositorio
        if (mensaje == null) throw new EntityNotFoundException("Mensaje no encontrado");

        var vm = mapper.Map<MensajeViewModel>(mensaje);
        return await pdfService.RenderAsync("Views\\Mensajes\\mensaje.cshtml", vm);
    }
}