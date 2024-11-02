using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class InmuebleTasacionProfile : Profile
{
    public InmuebleTasacionProfile()
    {
        CreateMap<Ent.InmuebleTasacion, VM.Inmuebles.InmuebleTasacionListItem>()
                   .ForMember(vm => vm.Id, opt => opt.MapFrom(a => a.Id))
                   .ForMember(vm => vm.TipoTasacion, opt => opt.MapFrom(a => a.InmuebleTipoTasacion.Descripcion))
                   .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario.Firma))
                   .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble.DireccionCompleta))
                   .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Inmueble.Tutelado.NombreCompleto))
                   .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Firme ? "Finalizada" : (a.Autorizado ? "Autorizada" : (a.Presentado ? "Solicitada" : "Pendiente"))));

        CreateMap<Ent.InmuebleTasacion, VM.Inmuebles.InmuebleTasacionViewModel>()
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(a => a.InmuebleTipoTasacion.Descripcion))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario.NombreCompleto))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble.DireccionCompleta))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Inmueble.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Dni, opt => opt.MapFrom(a => a.Inmueble.Tutelado.DNI));
    }
}