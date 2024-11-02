using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class InmuebleTipoAvisoProfile : Profile
{
    public InmuebleTipoAvisoProfile()
    {
        CreateMap<Ent.InmuebleTipoAviso, VM.Inmuebles.TipoAviso>()
                    .ForMember(vm => vm.Descripcion, opt => opt.MapFrom(c => c.TipoAviso.Descripcion))
                    .ForMember(vm => vm.Importe, opt => opt.MapFrom(c => c.Importe ?? c.TipoAviso.Importe));
    }
}