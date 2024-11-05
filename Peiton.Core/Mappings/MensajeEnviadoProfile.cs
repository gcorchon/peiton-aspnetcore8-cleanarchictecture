using AutoMapper;
using Newtonsoft.Json;
using Peiton.Contracts.Mensajes;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class MensajeEnviadoProfile : Profile
{
    public MensajeEnviadoProfile()
    {
        CreateMap<Ent.MensajeEnviado, VM.Mensajes.MensajeEnviadoListItem>()
            .ForMember(vm => vm.Para, opt => opt.MapFrom(m => string.Join(", ", JsonConvert.DeserializeObject<IEnumerable<DestinatarioMensaje>>(m.Para).Select(u => u.Nombre))));

        CreateMap<Ent.MensajeEnviado, VM.Mensajes.MensajeViewModel>()
            .ForMember(vm => vm.Remitente, opt => opt.MapFrom(m => m.UsuarioDe.NombreCompleto))
            .ForMember(vm => vm.Para, opt => opt.MapFrom(m => JsonConvert.DeserializeObject<IEnumerable<DestinatarioMensaje>>(m.Para).Select(u => u.Nombre)))
            .ForMember(vm => vm.ConCopia, opt => opt.MapFrom(m => JsonConvert.DeserializeObject<IEnumerable<DestinatarioMensaje>>(m.ConCopia).Select(u => u.Nombre)));
    }
}