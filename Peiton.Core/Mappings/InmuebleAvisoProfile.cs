using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class InmuebleAvisoProfile : Profile
{
    public InmuebleAvisoProfile()
    {
        CreateMap<Ent.InmuebleAviso, VM.Inmuebles.InmuebleAvisoListItem>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(c => c.Inmueble.Tutelado.NombreCompleto))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(c => c.Inmueble.DireccionCompleta))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(c => c.Usuario.NombreCompleto))
            .ForMember(vm => vm.TipoAviso, opt => opt.MapFrom(a => a.InmuebleTiposAvisos.Any() ? a.InmuebleTiposAvisos.First().TipoAviso.Descripcion : null))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Resuelto ? "Finalizado" : a.FechaFinalizacion.HasValue ? "Pendiente de pago" : a.EnTramite ? "En trámite" : "Pendiente"));

        CreateMap<Ent.InmuebleAviso, VM.Inmuebles.InmuebleAvisoViewModel>()
            .ForMember(vm => vm.Usuario, opt => opt.MapFrom(c => c.Usuario.NombreCompleto))
            .ForMember(vm => vm.Ocupacion, opt => opt.MapFrom(c => c.Ocupacion != null ? c.Ocupacion.Descripcion : null))
            .ForMember(vm => vm.TiposAviso, opt => opt.MapFrom(c => c.InmuebleTiposAvisos))
            .ForMember(vm => vm.Costes, opt => opt.MapFrom(c => c.InmuebleAvisosCostes));
    }
}