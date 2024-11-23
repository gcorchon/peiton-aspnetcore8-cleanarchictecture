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
            .ForMember(vm => vm.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(i => !string.IsNullOrWhiteSpace(i.DireccionCompleta) ? i.DireccionCompleta.Trim() : null));

        CreateMap<Ent.Inmueble, VM.Inmuebles.InmuebleListItem>()
            .ForMember(vm => vm.TipoInmueble, opt => opt.MapFrom(i => i.TipoInmueble.Descripcion));

        CreateMap<Ent.Inmueble, VM.Inmuebles.InmuebleViewModel>().ReverseMap();
        CreateMap<VM.Inmuebles.CrearInmuebleRequest, Ent.Inmueble>();
    }
}