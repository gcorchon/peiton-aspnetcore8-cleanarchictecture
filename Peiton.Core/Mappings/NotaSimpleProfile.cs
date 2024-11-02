using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class NotaSimpleProfile : Profile
{
    public NotaSimpleProfile()
    {
        CreateMap<Ent.NotaSimple, VM.Inmuebles.NotaSimpleListItem>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(a => a.Id))
            .ForMember(vm => vm.Causa, opt => opt.MapFrom(a => a.CausaNotaSimple.Descripcion))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario != null ? a.Usuario.NombreCompleto : null))
            .ForMember(vm => vm.Texto, opt => opt.MapFrom(a => a.Descripcion))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Tutelado.NombreCompleto))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble != null ? a.Inmueble.DireccionCompleta : null))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Finalizado ? "Finalizado" : "Pendiente"));
    }
}