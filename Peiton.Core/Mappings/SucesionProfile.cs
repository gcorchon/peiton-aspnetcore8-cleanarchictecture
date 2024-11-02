using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class SucesionProfile : Profile
{
    public SucesionProfile()
    {
        CreateMap<Ent.Sucesion, VM.Inmuebles.SucesionListItem>()
                    .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(o => o.Tutelado.NombreCompleto))
                    .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(o => o.Usuario.NombreCompleto))
                    .ForMember(vm => vm.TipoSucesion, opt => opt.MapFrom(o => o.SucesionTipo.Descripcion))
                    .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Firme ? "Firme" : (a.Autorizada ? "Autorizada" : (a.Solicitada ? "Solicitada" : "Pendiente"))));


        CreateMap<Ent.Sucesion, VM.Inmuebles.SucesionViewModel>()
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(o => o.Tutelado.NombreCompleto))
            .ForMember(vm => vm.DNI, opt => opt.MapFrom(o => o.Tutelado.DNI))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(o => o.Usuario.NombreCompleto))
            .ForMember(vm => vm.TipoSucesion, opt => opt.MapFrom(o => o.SucesionTipo.Descripcion))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Firme ? "Firme" : (a.Autorizada ? "Autorizada" : (a.Solicitada ? "Solicitada" : "Pendiente"))));
    }
}