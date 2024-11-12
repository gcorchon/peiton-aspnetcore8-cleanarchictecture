using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class SeguroContratadoProfile : Profile
{
    public SeguroContratadoProfile()
    {
        CreateMap<Ent.SeguroContratado, VM.Inmuebles.SeguroHogar>()
            .ForMember(vm => vm.TipoSeguro, opt => opt.MapFrom(c => c.TipoSeguro != null ? c.TipoSeguro.Descripcion : null))
            .ForMember(vm => vm.Seguro, opt => opt.MapFrom(c => c.Seguro != null ? c.Seguro.Descripcion : null));

        CreateMap<Ent.SeguroContratado, VM.SegurosContratados.SeguroContratadoViewModel>();
    }
}