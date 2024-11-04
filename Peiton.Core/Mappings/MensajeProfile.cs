using AutoMapper;
using Newtonsoft.Json;
using Peiton.Contracts.Mensajes;
using Peiton.Core.Entities;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class MensajeProfile : Profile
{
    public MensajeProfile()
    {
        CreateMap<Ent.Mensaje, VM.Mensajes.MensajeListItem>()
            .ForMember(vm => vm.Remitente, opt => opt.MapFrom(m => m.UsuarioDe))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(m => ObtenerEstado(m)));

        CreateMap<Ent.Mensaje, VM.Mensajes.MensajeViewModel>()
            .ForMember(vm => vm.Para, opt => opt.MapFrom(m => JsonConvert.DeserializeObject<IEnumerable<DestinatarioMensaje>>(m.Para).Select(u => u.Nombre)))
            .ForMember(vm => vm.ConCopia, opt => opt.MapFrom(m => JsonConvert.DeserializeObject<IEnumerable<DestinatarioMensaje>>(m.ConCopia).Select(u => u.Nombre)));
    }

    private string ObtenerEstado(Mensaje mensaje)
    {
        if (mensaje.Archivado) return "Archivado";
        return !mensaje.Leido ? "Pendiente" : "Leido";
    }
}