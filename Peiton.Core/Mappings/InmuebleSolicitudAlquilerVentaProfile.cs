using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class InmuebleSolicitudAlquilerVentaProfile : Profile
{
    public InmuebleSolicitudAlquilerVentaProfile()
    {
        CreateMap<Ent.InmuebleSolicitudAlquilerVenta, VM.Inmuebles.InmuebleSolicitudAlquilerVentaListItem>()
                    .ForMember(vm => vm.Direccion, opt => opt.MapFrom(s => s.Inmueble.DireccionCompleta))
                    .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(s => s.Inmueble.Tutelado.NombreCompleto))
                    .ForMember(vm => vm.Estado, opt => opt.MapFrom(s => s.Estado == 1 ? "Pendiente" : (s.Estado == 2 ? "En trámite" : s.Estado == 3 ? "Finalizado" : null)));

        CreateMap<Ent.InmuebleSolicitudAlquilerVenta, VM.Inmuebles.InmuebleSolicitudAlquilerVentaViewModel>()
            .ForMember(vm => vm.Ocupacion, opt => opt.MapFrom(a => a.Ocupacion != null ? a.Ocupacion.Descripcion : null))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario != null ? a.Usuario.NombreCompleto : null));
    }
}