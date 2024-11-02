using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class InmuebleAutorizacionProfile : Profile
{
    public InmuebleAutorizacionProfile()
    {
        CreateMap<Ent.InmuebleAutorizacion, VM.Inmuebles.InmuebleAutorizacionListItem>()
                    .ForMember(vm => vm.Id, opt => opt.MapFrom(a => a.Id))
                    .ForMember(vm => vm.TipoAviso, opt => opt.MapFrom(a => a.InmuebleMotivoAutorizacion.InmuebleTipoAutorizacion.Descripcion))
                    .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario.Firma))
                    .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble.DireccionCompleta))
                    .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Inmueble.Tutelado.NombreCompleto))
                    .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Firme ? "Firme" : (a.Presentado ? "Presentado" : (a.Autorizado ? "Autorizado" : "Pendiente"))));

        CreateMap<Ent.InmuebleAutorizacion, VM.Inmuebles.InmuebleAutorizacionViewModel>()
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(a => a.InmuebleMotivoAutorizacion.InmuebleTipoAutorizacion.Descripcion))
            .ForMember(vm => vm.Motivo, opt => opt.MapFrom(a => a.InmuebleMotivoAutorizacion.Descripcion))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario.NombreCompleto))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble.DireccionCompleta))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Inmueble.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Dni, opt => opt.MapFrom(a => a.Inmueble.Tutelado.DNI));
    }
}