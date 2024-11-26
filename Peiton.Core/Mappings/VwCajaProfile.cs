using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class VwCajaProfile : Profile
{
    public VwCajaProfile()
    {
        CreateMap<Ent.VwCaja, VM.Caja.CajaTuteladoListItem>()
            .ForMember(vm => vm.TipoPago, m => m.MapFrom(o => o.TipoPago != null ? o.TipoPago.Descripcion : null))
            .ForMember(vm => vm.MetodoPago, m => m.MapFrom(o => o.MetodoPago != null ? o.MetodoPago.Descripcion : null));
    }
}