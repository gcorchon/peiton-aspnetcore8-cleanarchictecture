using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AvisoTributarioProfile : Profile
{
    public AvisoTributarioProfile()
    {
        CreateMap<Ent.AvisoTributario, VM.AvisosTributarios.AvisoTributarioViewModel>()
            .ForMember(vm => vm.TipoAvisoTributario, opt => opt.MapFrom(c => c.TipoAvisoTributario.Descripcion))
            .ForMember(vm => vm.Inmueble, opt => opt.MapFrom(c => c.Inmueble != null ? c.Inmueble.DireccionCompleta : null));

        CreateMap<Ent.AvisoTributario, VM.AvisosTributarios.AvisoTributarioListItem>()
            .ForMember(vm => vm.TipoAvisoTributario, opt => opt.MapFrom(c => c.TipoAvisoTributario.Descripcion))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(c => c.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Usuario, opt => opt.MapFrom(c => c.Usuario.NombreCompleto))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(c => c.Resuelto ? "Resuelto" : (c.EnTramite ? "En trámite" : "Pendiente")));
    }
}