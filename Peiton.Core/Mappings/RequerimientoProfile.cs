using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class RequerimientoProfile : Profile
{
    public RequerimientoProfile()
    {
        CreateMap<Ent.Requerimiento, VM.Requerimientos.RequerimientoListItem>()
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(r => r.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Contestado, opt => opt.MapFrom(r => r.Contestado ? "Contestado" : "Pendiente"))
            .ForMember(vm => vm.Detalle, opt => opt.MapFrom(r => r.RequerimientoDetalle != null ? r.RequerimientoDetalle!.Descripcion : null))
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(r => r.RequerimientoTipo != null ? r.RequerimientoTipo!.Descripcion : null));


        CreateMap<Ent.Requerimiento, VM.Requerimientos.RequerimientoViewModel>();
    }
}