using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class PrestamoProfile : Profile
{
    public PrestamoProfile()
    {
        CreateMap<Ent.Prestamo, VM.Prestamos.PrestamoListItem>()
            .ForMember(vm => vm.Manual, opt => opt.MapFrom(p => true))
            .ForMember(vm => vm.TipoPrestamo, opt => opt.MapFrom(p => p.TipoPrestamo.Descripcion))
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(p => p.EntidadFinanciera.Descripcion))
            .ForMember(vm => vm.FechaSaldo, opt => opt.MapFrom(p => p.Fecha));

        CreateMap<Ent.Prestamo, VM.Prestamos.PrestamoViewModel>()
            .ForMember(vm => vm.FechaSaldo, opt => opt.MapFrom(p => p.Fecha));

        CreateMap<VM.Prestamos.CrearPrestamoRequest, Ent.Prestamo>()
            .ForMember(e => e.Fecha, opt => opt.MapFrom(p => p.FechaSaldo));

        CreateMap<VM.Prestamos.PrestamoViewModel, Ent.Prestamo>()
            .ForMember(e => e.Fecha, opt => opt.MapFrom(p => p.FechaSaldo));

    }
}