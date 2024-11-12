using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class InmuebleProfile : Profile
{
    public InmuebleProfile()
    {
        CreateMap<Ent.Inmueble, VM.Inmuebles.InmuebleInfo>();
        CreateMap<Ent.Inmueble, VM.Inmuebles.InmuebleSolicitudAlquilerVentaInfo>();
        CreateMap<Ent.Inmueble, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, opt => opt.MapFrom(i => i.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(i => !string.IsNullOrWhiteSpace(i.DireccionCompleta) ? i.DireccionCompleta.Trim() : null));
    }
}